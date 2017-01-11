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
            
            refreshContents();
        }

        private void refreshContents()
        {
            if(Settings.loadSettings())
            {
                labelCurrentFolder.Text = Settings.logPathDir;
                loadTxtFilesToListBox(listBox1, Settings.logPathDir, "ChatLog*");
                statusStrip1.Items[0].Text = "Found " + listBox1.Items.Count + " text files.";
            }
            else
            {
               if( Settings.saveSettings(Settings.selectFolder()))
                {
                    refreshContents();
                }
            }

        }

        public void loadTxtFilesToListBox(ListBox list_box_object, string folder, string filename)
        {
            if (list_box_object.Items.Count >= 0)
            {
                list_box_object.Items.Clear();
                DirectoryInfo dirInfo = new DirectoryInfo(folder);
                FileInfo[] files = dirInfo.GetFiles(filename);
                foreach (FileInfo file in files)
                {
                    list_box_object.Items.Add(file.Name);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EXPERIMENTAL 
            string temp = Settings.logPathDir + "\\" + listBox1.SelectedItem;

            //The code's GOAL in this part is to LOAD the contents of the text
            //file into a container such as RICHTEXTBOX or DATAGRIDVIEW for
            //this app's purpose.

            //The CURRENT implementation right now delivers the desired output
            //BUT it is slow as it updates the view of the RTB every appended line
            //AND IS not feasible for other intended features like FILTERING,
            //SEARCHING, etc,.

            //You might want to try to use DATAGRIDVIEW
            //but please make a BRANCH off from the git.

            //store into a placeholder RTB control
            RichTextBox rtb_temp = new RichTextBox();
            rtb_temp.LoadFile(temp, RichTextBoxStreamType.UnicodePlainText);
            //listBox1.SelectedIndex

            richTextBox1.Clear();
            richTextBox1.BackColor = Color.FromArgb(30,25,25);
            foreach (string line_of_text in rtb_temp.Lines)
            {
                //MessageBox.Show(line_of_text);
                if (line_of_text.Contains("PUBLIC"))
                {
                    // MessageBox.Show("found public" + line_of_text.Length);
                    
                    richTextBox1.SelectionColor = Color.White;
                    richTextBox1.AppendText(line_of_text);
                    richTextBox1.AppendText("\n");
                }
                else if (line_of_text.Contains("PARTY"))
                {
                    richTextBox1.SelectionColor = Color.Aqua;
                    richTextBox1.AppendText(line_of_text);
                    richTextBox1.AppendText("\n");
                }
                else if (line_of_text.Contains("GUILD"))
                {
                    richTextBox1.SelectionColor = Color.Orange;
                    richTextBox1.AppendText(line_of_text);
                    richTextBox1.AppendText("\n");
                }
                else if (line_of_text.Contains("REPLY"))
                {
                    richTextBox1.SelectionColor = Color.Violet;
                    richTextBox1.AppendText(line_of_text);
                    richTextBox1.AppendText("\n");
                }
                else
                {
                    richTextBox1.SelectionColor = Color.White;
                    richTextBox1.AppendText(line_of_text);
                    richTextBox1.AppendText("\n");
                }
            }
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            if (Settings.saveSettings(Settings.selectFolder()))
            {
                refreshContents();
            }
        }


    }
}
