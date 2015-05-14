using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagedCallStack
{
    public partial class managedCallStack : Form
    {
        public managedCallStack()
        {
            InitializeComponent();
        }

        private async void managedCallStack_Load(object sender, EventArgs e)
        {
            processes.DisplayMember = "ProcessName";
            processes.ValueMember = "Id";

            var result = await Utils.GetManagedProcesses();
            processes.DataSource = result.Where(item => item.ProcessName != Process.GetCurrentProcess().ProcessName)
                .Select(item => new ManagedProcess { Processname = item.ProcessName, Id = item.Id }).ToList();
        }


        private async void processes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var processId = Convert.ToInt32(((ManagedProcess)processes.SelectedItem).Id);
            try
            {
                var threads = await Utils.GetClrThreads(processId);
                threadsGrid.DataSource = threads.Select(t =>
                        new ManagedThread
                        {
                            Id = t.OSThreadId,
                            ManagedThreadId = t.ManagedThreadId,
                            GC = t.GcMode,
                            IsItFinalizer = t.IsFinalizer.ToString(),
                            Exception = (t.CurrentException != null ? t.CurrentException.ToString() + " " + t.CurrentException.Message : string.Empty)
                        }).ToList();
            }
            catch (Exception ex)
            {
                threadsGrid.DataSource = null;
                Console.WriteLine(ex.Message);
            }
        }

        private async void threadsGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (threadsGrid.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = this.threadsGrid.SelectedRows[0];
                    var processId = Convert.ToInt32(((ManagedProcess)processes.SelectedItem).Id);
                    var threadId = Convert.ToInt32(row.Cells[0].Value);
                    var callstack = await Utils.GetCallStack(processId, threadId);
                    callStack.Text = callstack;
                    var stackitems = await Utils.GetStackObjects(processId, threadId);
                    var items = stackitems.Select(root => new
                    {
                        Name = root,
                        RootType = root.Type.Name,
                    }).ToList();
                    stackObjects.DataSource = items;
                }
            }
            catch(Exception ex)
            {
                callStack.Text = string.Empty;
                stackObjects.DataSource = null;
                Console.WriteLine(ex);
            }
            
        }

        private async void refershToolStripMenuItem_Click(object sender, EventArgs e)
        {

            processes.DisplayMember = "ProcessName";
            processes.ValueMember = "Id";

            var result = await Utils.GetManagedProcesses();
            processes.DataSource = result.Where(item => item.ProcessName != Process.GetCurrentProcess().ProcessName)
                .Select(item => new ManagedProcess { Processname = item.ProcessName, Id = item.Id }).ToList();
        }
    }
}
