using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTree
{
    class ProcessTree
    {
        public ProcessTree(Process process)
        {
            this.Process = process;
            InitChildren();
        }

        // Recurively load children
        void InitChildren()
        {
            this.ChildProcesses = new List<ProcessTree>();

            // retrieve the child processes
            var childProcesses = this.Process.GetChildProcesses();

            // recursively build children
            foreach (var childProcess in childProcesses)
                this.ChildProcesses.Add(new ProcessTree(childProcess));
        }

        public Process Process { get; set; }

        public List<ProcessTree> ChildProcesses { get; set; }

        public int Id { get { return Process.Id; } }

        public string ProcessName { get { return Process.ProcessName; } }

        public long Memory { get { return Process.PrivateMemorySize64; } }

    }
}
