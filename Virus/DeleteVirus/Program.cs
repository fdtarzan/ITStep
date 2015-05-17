using JCS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirusForm;

namespace DeleteVirus
{
    class Program
    {
        public static string needPatch = "C:\\Users\\Public\\";
        static void Main(string[] args)
        {
            
            if (OSVersionInfo.Name == "Windows 7" || OSVersionInfo.Name == "Windows Vista")
            {
                //Autorun.SetAutorunValue(true, needPatch + "host.exe"); // добавить в автозагрузку
                Autorun.SetAutorunValue(false, needPatch + "VirusForm.exe");  // убрать из автозагрузки
            }
            else
                if (OSVersionInfo.Name == "Windows XP")
                {
                    needPatch = "C:\\Documents and Settings\\All Users\\";
                    //Autorun.SetAutorunValue(true, needPatch + "host.exe"); // добавить в автозагрузку
                    Autorun.SetAutorunValue(false, needPatch + "VirusForm.exe");  // убрать из автозагрузки
                }
            if (File.Exists(needPatch + "VirusForm.exe"))
            {
                Process[] pr = Process.GetProcessesByName("VirusForm");
                foreach (var item in pr)
                {
                    item.Kill();
                }
                Thread.Sleep(2000);
                try
                {
                    File.Delete(needPatch + "VirusForm.exe");
                    File.Delete(needPatch + "WebCam_Capture.dll");
                   
                }
                catch { }
            }
            SelfDelete();
        }
        public static void SelfDelete()
        {

            string batchCommands = string.Empty;
            string exeFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", string.Empty).Replace("/", "\\");

            batchCommands += "@ECHO OFF\n";                         // Do not show any output
            batchCommands += "ping 127.0.0.1 > nul\n";              // Wait approximately 4 seconds (so that the process is already terminated)
            batchCommands += "echo j | del /F ";                    // Delete the executeable
            batchCommands += exeFileName + "\n";
            batchCommands += "echo j | del deleteMyProgram.bat";    // Delete this bat file

            File.WriteAllText("deleteMyProgram.bat", batchCommands);

            Process.Start("deleteMyProgram.bat");
        }
    }
}
