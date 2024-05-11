using DVLD_Business;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DVLD_Presentation.Global_Classes
{
    public static class clsLogedUser
    {
        public static clsUser CurrentUser;

        public static bool SaveUsernameAndPasswordOnWindowsRegistery(string Username, string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLDCurrentUser";
            string ValueName1 = "Username";
            string ValueName2 = "Password";

            try
            {
                Registry.SetValue(KeyPath, ValueName1, Username, RegistryValueKind.String);
                Registry.SetValue(KeyPath, ValueName2, Password, RegistryValueKind.String);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool DeleteStoredCredentialFromWinRegisteryIfExists()
        {
            string KeyPath = @"SOFTWARE\DVLDCurrentUser";
            string ValueOneName = "Username";
            string ValueTwoName = "Password";

            try
            {
                //Open Base key, here Current_User base key
                using(RegistryKey BaseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    //Open Sub key, keyPath
                    using(RegistryKey SubKey = BaseKey.OpenSubKey(KeyPath, true))
                    {
                        if(SubKey != null)
                        {
                            SubKey.DeleteValue(ValueOneName);
                            SubKey.DeleteValue(ValueTwoName);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"The Key Path {KeyPath} Is Not Exists");
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool GetStoredCredentialFromWindowsRegistery(ref string Username, ref string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLDCurrentUser";
            string ValueName1 = "Username";
            string ValueName2 = "Password";

            try
            {
                Username = (string)Registry.GetValue(KeyPath, ValueName1, Username);
                Password = (string)Registry.GetValue(KeyPath, ValueName2, Password);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool RemeberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                string CurrentDirectory = Directory.GetCurrentDirectory();
                string FilePath = CurrentDirectory + "\\Data.txt";

                //Here to not remember username and password if Remember me box is not checked by passing empty string as a parameter
                if(File.Exists(FilePath) && Username == "")
                {
                    File.Delete(FilePath);
                    return true;
                }

                string DataToSave = Username + "#//#" + Password;

                using(StreamWriter Writer = new StreamWriter(FilePath))
                {
                    Writer.WriteLine(DataToSave);
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured");
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                string CurrentDirectory = Directory.GetCurrentDirectory();
                string FilePath = CurrentDirectory + "\\Data.txt";

                if(File.Exists(FilePath))
                {
                    using(StreamReader Reader = new StreamReader(FilePath))
                    {
                        string Line;
                        while((Line = Reader.ReadLine()) != null)
                        {
                            string[] Result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = Result[0];
                            Password = Result[1];
                        }

                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occured {ex.Message}");
                return false;
            }
        }

    }
}
