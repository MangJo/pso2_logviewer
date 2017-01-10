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
        //Settings appSettings = new Settings();

        public FormMain()
        {
            InitializeComponent();

            //richTextBox1.Font = new Font("Arial", 11f, FontStyle.Regular);
            //richTextBox1.BackColor = Color.AliceBlue;
            Settings.loadSettings();
            loadTxtFilesToListBox(listBox1, Settings.logPathDir, "ChatLog*");
        }

        public void loadTxtFilesToListBox(ListBox list_box_object, string folder, string filename)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(folder);
            FileInfo[] files = dirInfo.GetFiles(filename);
            foreach(FileInfo file in files)
            {
                list_box_object.Items.Add(file.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //experimental 
            string temp = Settings.logPathDir + "\\" + listBox1.SelectedItem;

            //the goal of this portion of code is to apply color to the text
            //according to wether its PUBLIC, GUILD, PARTY or REPLY chats
            //this implementation is so slow :v 
            //kinda want to think another approach.
            //also it skips text lines without date chat type and playername
            //store into a placeholder RTB control
            RichTextBox rtb_temp = new RichTextBox();
            rtb_temp.LoadFile(temp, RichTextBoxStreamType.UnicodePlainText);
            //listBox1.SelectedIndex

            richTextBox1.Clear();
            richTextBox1.BackColor = Color.Black;
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
            }
        }
    }
}
