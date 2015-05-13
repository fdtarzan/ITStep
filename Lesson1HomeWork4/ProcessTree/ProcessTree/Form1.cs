using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;
using System.Collections.Generic;


namespace ProcessTree
{
    public partial class MForm : Form
    {
        //List<int> parent;
        List<Process> parentProc;
        List<Process> parentProc1;
        List<Process> parentProc2;
        List<Process> parentProc3;
        Process[] p;
        TreeNode rootNode;

        public MForm()
        {

            InitializeComponent();
            p = Process.GetProcesses();
            // parent = new List<int>();
            parentProc = new List<Process>();
            parentProc1 = new List<Process>();
            parentProc2 = new List<Process>();
            parentProc3 = new List<Process>();


            foreach (Process el in p)
            {
                if (GetParentProcessId(el.Id) == 0)
                {
                   // parentProc.Add(el);
                }
                else
                {
                    if (!parentProc.Exists(c => c.Id == GetParentProcessId(el.Id)))
                    {
                        try
                        {
                            parentProc.Add(Process.GetProcessById(GetParentProcessId(el.Id)));
                        }
                        catch (Exception ex)
                        {
                             // MessageBox.Show(ex.Message);
                        }
                    }
                }
            }

            foreach (Process el in parentProc)
            {
                if (GetParentProcessId(el.Id) == 0)
                {
                    // parentProc.Add(el);
                }
                else
                {
                    if (!parentProc1.Exists(c => c.Id == GetParentProcessId(el.Id)))
                    {
                        try
                        {
                            parentProc1.Add(Process.GetProcessById(GetParentProcessId(el.Id)));
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show(ex.Message);
                        }
                    }
                }
            }

           
                rootNode = new TreeNode("Processes");
                FillTree(parentProc1, rootNode);
                treeView1.Nodes.Add(rootNode);




                //   MessageBox.Show(parent.Count.ToString());

                // foreach (var el in parentProc)
                //{

                //     TreeNode tn = new TreeNode(el.ProcessName);

                //     treeView1.Nodes.Add(tn);
                //    foreach (var e in GetChildProcesses(el))
                //    {
                //        tn.Nodes.Add(e.ProcessName);
                //    }

                //}
                //  MessageBox.Show(parentProc.Count.ToString());


            
        }
        public void FillTree(List<Process> pl, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            foreach (var el in pl)
            {
                if (el.ProcessName != "Idle")
                {
                    aNode = new TreeNode(el.ProcessName);
                    nodeToAddTo.Nodes.Add(aNode);
                    if (GetChildProcesses(el).Count != 0)
                    {
                        FillTree(GetChildProcesses(el), aNode);
                    }
                }
            }
        
        }
        int GetParentProcessId(int Id)
        {
           
                int parentId = 0;
                using (ManagementObject obj = new ManagementObject("win32_process.handle=" + Id.ToString()))
                {
                    try
                    {
                        obj.Get();
                        parentId = Convert.ToInt32(obj["ParentProcessId"]);
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message);
                    }
                }
                return parentId;
           
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
