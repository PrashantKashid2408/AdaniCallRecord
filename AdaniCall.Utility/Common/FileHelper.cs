using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaniCall.Utility.Common
{
    public class FileHelper 
    {
        private readonly static string _module = "AdaniCall.Utility.Common.FileHelper";
        public static string GetFileName(string ImageName)
        {
            try
            {
                if (ImageName == "")
                    return "";
                else
                {
                    string UploadedFileName = Path.GetFileNameWithoutExtension(ImageName);
                    if (UploadedFileName == "no-logo" || UploadedFileName == "no-banner")
                        return "";
                    else
                        return Path.GetFileName(ImageName);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetFileName(" + ImageName + ")", ex.Source, ex.Message, ex);
            }
            return ImageName;
        }

        public static void MoveFiles(string SourcePath, string DestPath, string DestFileName, string strName = "")
        {
            try
            {
                FileInfo fl = new FileInfo(SourcePath);
                if (fl.Exists)
                {
                    DirectoryInfo drDest = new DirectoryInfo(DestPath);
                    if (!drDest.Exists)
                        drDest.Create();

                    drDest = null;
                    fl.CopyTo(DestPath + DestFileName, true);
                    fl.Delete();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "MoveImages(SourcePath:" + SourcePath + ",DestPath:" + DestPath + ",strName:" + strName + ")", ex.Source, ex.Message, ex);
            }
        }

        public static void DeleteFiles(string DestPath, string strName = "")
        {
            try
            {
                if (strName != "")
                {
                    DirectoryInfo drDest = new DirectoryInfo(DestPath);
                    if (drDest.Exists)
                    {
                        string filesToDelete = "*" + strName + "*";
                        FileInfo[] fileList = drDest.GetFiles(filesToDelete);
                        foreach (FileInfo FileInfo in fileList)
                        {
                            FileInfo.Delete();
                        }
                    }
                    drDest = null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "DeleteFiles(DestPath:" + DestPath + ",strName:" + strName + ")", ex.Source, ex.Message, ex);
            }
        }
    }
}
