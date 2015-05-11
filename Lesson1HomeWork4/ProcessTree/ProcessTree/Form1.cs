using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;
using System.Collections.Generic;


namespace ProcessTree
{
    public partial class MForm : Form
    {
        List<int> parent;
        List<Process> parentProc;
       
        public MForm()
        {
            
            InitializeComponent();
            Process[] p = Process.GetProcesses();
            parent = new List<int>();
            parentProc = new List<Process>();
            

            foreach (Process el in p)
            {
                if ( GetParentId(el)!=null && !parent.Exists(c => c == GetParentId(el)))
                {
                    try
                    {
                        parent.Add((int)GetParentId(el));
                        parentProc.Add(Process.GetProcessById((int)GetParentId(el)));
                        
                       
                    }
                    catch (Exception ex)
                    {
                    
                    }
                }
            }
          //   MessageBox.Show(parent.Count.ToString());

             foreach (var el in parentProc)
            {
               
                 TreeNode tn = new TreeNode(el.ProcessName);

                 treeView1.Nodes.Add(tn);
                foreach (var e in GetChildProcesses(el))
                {
                    tn.Nodes.Add(e.ProcessName);
                }
               
            }
          //  MessageBox.Show(parentProc.Count.ToString());
           

        }
         public int? GetParentId(Process process)
        {
        // query the management system objects
        string queryText = string.Format("select parentprocessid from win32_process where processid = {0}", process.Id);
        using (var searcher = new ManagementObjectSearcher(queryText))
        {
            foreach (var obj in searcher.Get())
            {
                object data = obj.Properties["parentprocessid"].Value;
                if (data != null)
                    return Convert.ToInt32(data);
            }
        }
        return null;
        }
         public  List<Process> GetChildProcesses(Process process)
         {
             var results = new List<Process>();

             // query the management system objects for any process that has the current
             // process listed as it's parentprocessid
             string queryText = string.Format("select processid from win32_process where parentprocessid = {0}", process.Id);
             using (var searcher = new ManagementObjectSearcher(queryText))
             {
                 foreach (var obj in searcher.Get())
                 {
                     object data = obj.Properties["processid"].Value;
                     if (data != null)
                     {
                         // retrieve the process
                         var childId = Convert.ToInt32(data);
                         var childProcess = Process.GetProcessById(childId);

                         // ensure the current process is still live
                         if (childProcess != null)
                             results.Add(childProcess);
                     }
                 }
             }
             return results;
         }

            
    }
      

}
