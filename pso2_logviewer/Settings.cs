using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Xml;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace pso2_logviewer
{
    static class Settings
    {
        public static string logPathDir { get; set; }

        /*public Settings()
        {
           
        }*/

        private static bool settingsFileExists(string file_name)
        {
            if ( File.Exists(file_name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool loadSettings()
        {
            if (settingsFileExists(Application.UserAppDataPath + "/settings.xml"))
            {
                // Load the settings file (XML File)
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.UserAppDataPath + "/settings.xml");

                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/settings");
                foreach (XmlNode node in nodeList)
                {
                    logPathDir = node.SelectSingleNode("dirpath").InnerText;
                }
                //If the settings was loaded successfully, return true.
                return true;
            }
            else
            {
                //If settings was not loaded, return false.
                MessageBox.Show("Please select the the PSO2 log directory folder.");
                //saveSettings();

                return false;
            }
        }

        public static string selectFolder()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            if (logPathDir != null)
            {
                dialog.InitialDirectory = logPathDir;
            }
            else
            {
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            dialog.IsFolderPicker = true;
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return dialog.FileName;
            }
            else
            {
                return null;
            }
        }

        public static bool saveSettings(string folder_name)
        {

            if (folder_name != null)
            {
                // If there is a folder selected, save the dirPath string in an XML File.
                using (XmlWriter writer = XmlWriter.Create(Application.UserAppDataPath + "/settings.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("settings");

                    writer.WriteElementString("dirpath", folder_name);

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                MessageBox.Show("You have selected : " + folder_name);
                return true;
            }
            else
            {
                //MessageBox.Show("Please select the log folder in order to work properly.");
                return false;
            }
        }
    }
}
