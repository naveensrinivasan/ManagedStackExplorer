using Microsoft.Diagnostics.Runtime;
using Microsoft.Diagnostics.Runtime.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagedCallStack
{
    static class Utils
    {
        public static bool IsClrProcess(this Process process)
        {
          return  process.Modules.Cast<ProcessModule>().Any(m => m.ModuleName.StartsWith("clr") ||
                    m.ModuleName.StartsWith("mscor"));
        }
        public static async Task<IEnumerable<Process>> GetManagedProcesses()
        {
            return await Task.Run<IEnumerable<Process>>(() =>
                 {
                     var list = new List<Process>();
                     var is64BitProcess = IntPtr.Size == 8;
                     var wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process";
                     using (var searcher = new ManagementObjectSearcher(wmiQueryString))
                     using (var results = searcher.Get())
                     {
                         var query = from p in Process.GetProcesses()
                                     join mo in results.Cast<ManagementObject>()
                                     on p.Id equals (int)(uint)mo["ProcessId"]
                                     
                                     select new
                                     {
                                         Process = p,
                                         Path = (string)mo["ExecutablePath"]
                                     };
                         foreach (var item in query)
                         {
                             try
                             {
                                 var isManaged = new PEFile(item.Path).Header.IsManaged;
                                     if (is64BitProcess)
                                     {
                                         if (!Is64Bit(item.Process.Handle) && item.Process.IsClrProcess())
                                         {
                                             
                                             list.Add(item.Process);
                                         }
                                     }
                                     else if (item.Process.IsClrProcess())
                                     {
                                         list.Add(item.Process);

                                     }
                             }
                             catch { }
                         }
                     }
                     return list;
                 });
        }
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);
        public static bool Is64Bit(IntPtr handle)
        {
            bool retVal;

            IsWow64Process(handle, out retVal);

            return retVal;
        }
        public static async Task<IEnumerable<ClrThread>> GetClrThreads(int processId)
        {
            return await Task.Run<IEnumerable<ClrThread>>(() =>
            {
                var list = new List<ClrThread>();
                using (var process = DataTarget.AttachToProcess(processId, 10000, AttachFlag.NonInvasive))
                {
                    var clr = CreateRuntime(process);
                    list = clr.Threads.Where(t => t.IsAlive).ToList();
                }
                return list;
            });

        }
        static ClrRuntime CreateRuntime(DataTarget dataTarget, string dacLocation = null)
        {
            // Only care about one CLR in this example.
            ClrInfo version = dataTarget.ClrVersions[0];
            if (string.IsNullOrEmpty(dacLocation))
            {
                // TryDownloadDac will also check to see if you have the matching
                // mscordacwks installed locally, so you don't need to also check
                // TryGetDacLocation as well.
                dacLocation = version.TryDownloadDac();
            }

            if (string.IsNullOrEmpty(dacLocation) || !File.Exists(dacLocation))
                throw new FileNotFoundException(string.Format("Could not find .Net Diagnostics Dll {0}", version.DacInfo.FileName));

            return dataTarget.CreateRuntime(dacLocation);
        }
        public static async Task<string> GetCallStack(int processId ,int threadId)
        {
            return await Task.Run<string>(() =>
            {
                var list = new List<ClrThread>();
                var sb = new StringBuilder();
                using (var process = DataTarget.AttachToProcess(processId, 10000, AttachFlag.NonInvasive))
                {
                    var clr = CreateRuntime(process);
                    var thread = clr.Threads.First(t => t.OSThreadId == threadId);
                    foreach (ClrStackFrame frame in thread.StackTrace)
                    {
                       sb.AppendLine(string.Format("{0,16:X} {1,16:X} {2}", frame.StackPointer, 
                           frame.InstructionPointer, frame.DisplayString ));
                    }
                }
                return sb.ToString();
            });

        }
        public static async Task<IEnumerable<ClrRoot>> GetStackObjects(int processId ,int threadId)
        {
            return await Task.Run<IEnumerable<ClrRoot>> (() =>
            {
                var list = new List<ClrRoot>();
                var sb = new StringBuilder();
                using (var process = DataTarget.AttachToProcess(processId, 10000, AttachFlag.NonInvasive))
                {
                    var clr = CreateRuntime(process);
                    var thread = clr.Threads.First(t => t.OSThreadId == threadId);
                   list= thread.EnumerateStackObjects().ToList();
                }
                return list;
            });
        }
    }
}
