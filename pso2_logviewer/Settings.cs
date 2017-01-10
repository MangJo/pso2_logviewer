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

        public static void loadSettings()
        {
            if (settingsFileExists(Application.UserAppDataPath + "/settings.xml"))
            {
                // StreamReader sr = new StreamReader(Application.UserAppDataPath + "/settings.xml");
                // might use some kind of html like encodings for space or other chars
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.UserAppDataPath + "/settings.xml");

                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/settings");
                //string proID = "";
                foreach (XmlNode node in nodeList)
                {
                    logPathDir = node.SelectSingleNode("dirpath").InnerText;
                    //test = proID;
                    //MessageBox.Show(test);
                }
                //REFACTOR
            }
            else
            {
                MessageBox.Show("Please select the the PSO2 log directory folder.");
                saveSettings();
            }
        }

        public static void saveSettings()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Application.UserAppDataPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // MessageBox.Show(dialog.FileName);
                // after selecting folder, the app will save the info as an XML data saved into userappDataPath
                // then loads it
                using (XmlWriter writer = XmlWriter.Create(Application.UserAppDataPath + "/settings.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("settings");

                    writer.WriteElementString("dirpath", dialog.FileName);

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    //REFACTOR
                }
                MessageBox.Show("You have selected : " + dialog.FileName);
                loadSettings();
            }
        }
    }
}
