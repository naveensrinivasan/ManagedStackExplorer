using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagedCallStack
{
    class ManagedThread
    {
        public uint Id { get; set; }
        public int ManagedThreadId { get; set; }
        public Microsoft.Diagnostics.Runtime.GcMode GC { get; set; }
        public string Exception { get; set; }
        public string IsItFinalizer { get; set; }


    }
}
