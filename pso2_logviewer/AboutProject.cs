using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pso2_logviewer
{
    partial class AboutProject : Form
    {
        private StringBuilder productDesc = new StringBuilder();
        //Lazy to do something more efficient than this:
        private void loadProductDesc()
        {
            this.productDesc.Append("Text Log Viewer App for pso2's logs. Useful only if you have over 1,000 text files of the game's log, or if you want to backread chats, read nostalgic moments from chats, search blackmail materials or whatever.\r\n\r\n");
            this.productDesc.Append("The LogViewer only reads chat logs. I planned to add other kinds of logs before but I decided not to because I think the other logs seem to be useless and I stopped\\quit playing the game.\r\n\r\n");
            this.productDesc.Append("The features of this app are simple:\r\n-Colored text according to the chat type.\r\n-You can choose what to display i.e. date, playername, playerID etc.\r\n-Simple search both text list files and log contents.\r\n-You can select a different folder where the logs are stored.\r\n\r\n");
            this.productDesc.Append("This product uses MIT License\r\n\r\n");
            this.productDesc.Append("Created by MangJo\r\nhttps://github.com/MangJo/pso2_logviewer\r\nmangune.jomarc@gmail.com\r\n\r\n");
            this.productDesc.Append("Phantasy Star Online and PSO are either registered trademarks or trademarks of SEGA Corporation.");
        }

        public AboutProject()
        {
            InitializeComponent();
            loadProductDesc();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = this.productDesc.ToString(); //AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
