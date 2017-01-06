using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Xml;

namespace pso2_logviewer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            //test case
            //check file if exists
            try
            {
                // StreamReader sr = new StreamReader(Application.UserAppDataPath + "/settings.xml");
                // might use some kind of html like encodings for space or other chars
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.UserAppDataPath + "/settings.xml");

                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/settings");
                string proID = "";
                foreach (XmlNode node in nodeList)
                {
                    proID = node.SelectSingleNode("dirpath").InnerText;
                    MessageBox.Show(proID + " ");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("config.cfg doesn't exists pls locate log directory");
                MessageBox.Show(ex.ToString());
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = Application.UserAppDataPath;
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    // MessageBox.Show(dialog.FileName);
                    // after selecting folder, the app will save the info as an XML data saved into userappDataPath
                    // then loads it
                }
            }  
        }
    }
}
