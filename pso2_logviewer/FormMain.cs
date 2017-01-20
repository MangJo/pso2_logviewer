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
        //All of the retrieved data are stored in a DataTable object.
        DataTable dt_txtfiles = new DataTable();
        DataTable dt_txtcontents = new DataTable();

        String[] columnNames = new String[] {"DateTime", "ChatLine", "ChatType", "PlayerID", "CharName", "Chat"};

        public FormMain()
        {
            InitializeComponent();
        }

        //Refresh contents particularly on Text files list.
        private void refreshContents()
        {
            if (Settings.loadSettings())
            {
                labelCurrentFolder.Text = Settings.logPathDir;
                //loadTxtFilesToDGV_List(dataGridView1, Settings.logPathDir, "ChatLog*");

                dt_txtfiles = Mastermind.loadTxtFiles_as_dataTable(Settings.logPathDir, "ChatLog*");
                dgv_textList.DataSource = dt_txtfiles;

                statusStrip1.Items[0].Text = "Found " + dgv_textList.RowCount + " text file(s).";
            }
            else
            {
                if (Settings.saveSettings(Settings.selectFolder()))
                {
                    refreshContents();
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

        private DataTable loadChatTextContents()
        {
            //Store logPathDir value in a string variable.
            string text_filename = Settings.logPathDir + "\\" + dgv_textList.CurrentCell.Value;

            //Sanity-check: If the file does not exist, even if it is on the file list.
            if (File.Exists(text_filename) == false)
            {
                MessageBox.Show("Ooops, it seems this log file doesn't exist, another app might removed it from the directory", "No file found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            //Create a local DataTable
            DataTable dt = new DataTable();

            //Add columns and apply column names.
            Mastermind.addColumnNamesToDataTable(dt, columnNames);

            //Open the text file; read text line by line; detect the delimiter, in this case the TAB \t
            //Use a DataRow to hold all the data read from the line.
            //After insertion of data into the DataRow, append the DataRow into the DataTable
            //Repeat until the End Of Stream
            using (StreamReader sr = new StreamReader(text_filename))
            {
                StringBuilder strBuilder = new StringBuilder(); //Holds the text from a linebroke chat (Some chats contain \r\n as in breaking down continuous text with a linebreak)
                string temporary_text = ""; //Holds a copy of text of the Chat's main row and is to be appended with other text from linebreaks.
                int rowIndex = -1; //Tracks the current row in process.
                int noOfNextLines = 0; //Tracks the number of linebreaks from the chat's main row.

                //Opens the file until the end of stream
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split('\t');

                    //If the values.Length is 1, this means it is a linebroke chat.
                    if (values.Length == 1)
                    {
                        strBuilder.Append(" " + values[0]);
                        noOfNextLines++;
                        continue;
                    }
                    else if (noOfNextLines == 2) //The MAXIMUM Linebreak from a multi-line chat is 2. If the count is 2, then append texts into a single line.
                    {
                        dt.Rows[rowIndex].SetField(5, temporary_text + strBuilder.ToString()); //rowIndex hasn't been incremented because it detected a multi-line chat. Therefore, it is still the current row in process.
                        strBuilder.Clear(); //After appending text, clear the contents of the stringbuilder object.
                        noOfNextLines = 0; //Reset to zero.
                       // continue;
                    }

                    DataRow dr = dt.NewRow();
                    rowIndex++;
                    temporary_text = values[5];

                    //Put the values on the respective columns.
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (values.Length > 1)
                            dr[i] = values[i];
                        //This one is tricky, there are text of chat that uses breakline as in continuation
                        //of that chat on a new line.

                        //Something like this:
                        //Chat: I'm selling this one
                        //      Item for
                        //      500M only.

                        //Instead of being 1 line:
                        //Chat: I'm selling this one Item for 500M only.
                        //This problem has been fixed or a work around has been implemented, please see the above comments.
                    }
                    dt.Rows.Add(dr);
                }

                return dt;
                //dataGridView2.DataSource = dt;
                //dataGridView2.Refresh();
                //MessageBox.Show(dataGridView2.RowCount.ToString());
            }
        }
        
        private void applyTextColorOnDGV_contents()
        {
            //Coloring the text of the row according to its chat type.
            dgv_logContents.DefaultCellStyle.BackColor = Color.Black;

            var chatTypeColor = new Dictionary<string, Color>();
            chatTypeColor.Add("PUBLIC", Color.White);
            chatTypeColor.Add("PARTY", Color.Aqua);
            chatTypeColor.Add("GUILD", Color.Orange);
            chatTypeColor.Add("REPLY", Color.Violet);

            Mastermind.colorizeRow_ChatLine(dgv_logContents, 2, chatTypeColor);
        }

        //dataGridView1 is dgv_textList
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dt_txtcontents = loadChatTextContents();
            dgv_logContents.DataSource = dt_txtcontents;
        }

        //dataGridView2 is dgv_logContents
        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            applyTextColorOnDGV_contents();
        }

        #region CHECKBOXES

        //checkBox1 is cb_Date
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Mastermind.HideUnhide_DGVColumns_by_checkBox(cb_Date, dgv_logContents, 0);
        }

        //checkBox2 is cb_lineNo
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Mastermind.HideUnhide_DGVColumns_by_checkBox(cb_lineNo, dgv_logContents, 1);
        }

        //checkBox3 is cb_chatType
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Mastermind.HideUnhide_DGVColumns_by_checkBox(cb_chatType, dgv_logContents, 2);
        }

        //checkBox4 is cb_playerID
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Mastermind.HideUnhide_DGVColumns_by_checkBox(cb_playerID, dgv_logContents, 3);
        }

        //checkBox5 is cb_PCName
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Mastermind.HideUnhide_DGVColumns_by_checkBox(cb_PCName, dgv_logContents, 4);
        }

        //checkBox6 is cb_Chat
        private void cb_Chat_CheckedChanged(object sender, EventArgs e)
        {
            Mastermind.HideUnhide_DGVColumns_by_checkBox(cb_Chat, dgv_logContents, 5);
        }
        #endregion

        //search|filter on text files list.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Mastermind.doSearch(dt_txtfiles, dgv_textList, "Logs", txtBox_TxtFileListFilter.Text);
            statusStrip1.Items[0].Text = "Found " + dgv_textList.RowCount + " text file(s).";
        }

        //search|filter on log contents.
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            search_logContents();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Mastermind.addItemsToComboBoxFilter(comBox_ColNames, columnNames);
            refreshContents();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Enter)
            {
                search_logContents();
            }
        }

        //Used by some events to trigger this function
        private void search_logContents()
        {
            if (comBox_ColNames.Text == "") { return; }
            Mastermind.doSearch(dt_txtcontents, dgv_logContents, comBox_ColNames.Text, txtBox_ContentsFilter.Text);
        }
    }
}
