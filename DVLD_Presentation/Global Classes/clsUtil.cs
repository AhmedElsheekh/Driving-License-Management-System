using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Presentation.Global_Classes
{
    public static class clsUtil
    {
        public static bool CreateFolderIfNotExists(string FolderPath)
        {
            if (Directory.Exists(FolderPath))
                return true;

            try
            {
                Directory.CreateDirectory(FolderPath);
                return true;
            }
            catch(Exception ex)
            {
                
            }

            return false;
        }

        public static string GenerateGuid()
        {
            Guid NewGuid = Guid.NewGuid();
            return NewGuid.ToString();
        }

        public static string ReplaceFileNameWithGuid(string SourceFile)
        {
            FileInfo Info = new FileInfo(SourceFile);
            string Ext = Info.Extension;

            return GenerateGuid() + Ext;
        }

        public static bool CopyImageFileToDestinationFolder(ref string SourceFile)
        {
            string DestinationFolder = "D:\\MyRealProjects\\DVLDPersonImages\\";

            if (!CreateFolderIfNotExists(DestinationFolder))
                return false;

            string DestinationFile = DestinationFolder + ReplaceFileNameWithGuid(SourceFile);

            try
            {
                File.Copy(SourceFile, DestinationFile);
            }
            catch(Exception ex)
            {
                return false;
            }

            SourceFile = DestinationFile;
            return true;
        }

        public static string ComputeHashForPassword(string Password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] ArrayOfBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));

                return BitConverter.ToString(ArrayOfBytes).Replace("-", "").ToLower();
            }
        }

    }
}
