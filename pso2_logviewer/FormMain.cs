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
        DataTable dt_txtfiles = new DataTable();

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
                //loadTxtFilesToDGV_List(dataGridView1, Settings.logPathDir, "ChatLog*");
                
                dt_txtfiles = loadTxtFiles_as_dataTable(Settings.logPathDir, "ChatLog*");
                dataGridView1.DataSource = dt_txtfiles;

                statusStrip1.Items[0].Text = "Found " + dataGridView1.RowCount + " text files.";
            }
            else
            {
               if( Settings.saveSettings(Settings.selectFolder()))
                {
                    refreshContents();
                }
            }

        }

        private void loadTxtFilesToDGV_List(DataGridView data_grid_view, string folder, string filename)
        {
            if (data_grid_view.RowCount >= 0)
            {
                data_grid_view.Rows.Clear();
                DirectoryInfo dirInfo = new DirectoryInfo(folder);
                FileInfo[] files = dirInfo.GetFiles(filename);
                foreach (FileInfo file in files)
                {
                    data_grid_view.Rows.Add(file.Name);
                }
            }
        }

        //EXPERIMENTAL: Load Text files list into a DataTable
        private DataTable loadTxtFiles_as_dataTable(string folder, string filename)
        {
            DataTable dt = new DataTable("txtFilesList");

            dt.Columns.Add("Logs");

            DirectoryInfo dirInfo = new DirectoryInfo(folder);
            FileInfo[] files = dirInfo.GetFiles(filename);
            foreach (FileInfo file in files)
            {
                DataRow dr = dt.NewRow();
                dr[0] = file.Name;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            if (Settings.saveSettings(Settings.selectFolder()))
            {
                refreshContents();
            }
        }

        private void loadChatTextContents()
        {
            //Experimental Implementation
            string temp = Settings.logPathDir + "\\" + dataGridView1.CurrentCell.Value;

            if (File.Exists(temp) == false)
            {
                MessageBox.Show("Ooops, it seems this log file doesn't exist, another app might removed it from the directory","No file found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Create column names
            String[] columnNames = new String[]
            {
                "DateTime", "ChatLine", "ChatType", "PlayerID", "CharName", "Chat"
            };

            //Create DataTable
            DataTable dt = new DataTable();

            //Add columns and apply column names. Code Refactor as addColumnNamesToDataTable(DataTable data_table, String[] column_names)
            foreach (string column_name in columnNames)
            {
                dt.Columns.Add(column_name);
            }

            //After adding the columns, next is to load the text file
            //and insert it's contents into DataTable

            //Open the text file; read file line by line; detect the delimiter in this case the TAB
            //Use a Data Row to hold all the data read from each line.
            //After insertion of data into Data Row, append the Data Row into the DataTable
            //Repeat until the End Of Stream
            //Display DataTable on DataGridView Control
            using (StreamReader sr = new StreamReader(temp))
            {
                //Opens the file until the end of stream
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split('\t');

                    DataRow dr = dt.NewRow();

                    //Put the values on the respective column
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (values.Length > 1)
                            dr[i] = values[i];
                        //This one is a tricky, there are text lines that uses newline as in continuation
                        //of previous chat on a new line (hard to explain in words lol)
                        //something like this:
                        //Chat: I'm selling this
                        //      Item for
                        //      500M

                        //Instead of being 1 line:
                        //Chat: I'm selling this Item for 500M
                        //[5] is the index number for chat column, [0] is the newline text
                        //it is originally for datetime column
                        else
                        {
                            dr[5] = values[0];
                        }
                    }
                    dt.Rows.Add(dr);
                }
                dataGridView2.DataSource = dt;
                //dataGridView2.Refresh();
            }
        }

        private void colorizeRow_ChatLine(DataGridView dgv, int colIndex, Dictionary<string, Color> chat_type_color)
        {
            Color colorizer_temp = new Color();
            //Selects a row
            for (int ctr = 0; ctr < dgv.Rows.Count; ctr++)
            {
                //Get the chat type from the dgv
                var str_msg = dgv[colIndex, ctr].Value.ToString();

                
                //Loop through the dictionary that holds key value pair CHAT_TYPE:COLOR in this case.
                foreach (var chat_type in chat_type_color)
                {
                    //If it found a match, place the color on a var then break out of loop.
                    if (str_msg == chat_type.Key)
                    {
                        colorizer_temp = chat_type_color[chat_type.Key];
                        break;
                    }
                    //this is for the continuation of in-game chat multi-line (I'd say its bad implementation)
                    if (str_msg == "")
                    {
                        break;
                    }
                    //if it did not found any matching key, continue to the next key until it finds one
                    else
                    {
                        continue;
                    }
                }

                //Colorize the text on the selected row
                dgv.Rows[ctr].DefaultCellStyle.ForeColor = colorizer_temp;
            }
        }

        private void applyTextColorOnDGV()
        {
            //Coloring the text of the row according to its chat type
            dataGridView2.DefaultCellStyle.BackColor = Color.Black;

            var chatTypeColor = new Dictionary<string, Color>();
            chatTypeColor.Add("PUBLIC", Color.White);
            chatTypeColor.Add("PARTY", Color.Aqua);
            chatTypeColor.Add("GUILD", Color.Orange);
            chatTypeColor.Add("REPLY", Color.Violet);

            colorizeRow_ChatLine(dataGridView2, 2, chatTypeColor);
        }

        //you may want to add code for storing and loading checked values on an XML file
        private void HideUnhide_DGVColumns_by_checkBox(CheckBox check_box, DataGridView dgv, int column_index)
        {
            if(dgv.ColumnCount == 0)
            {
                return;
            }

            if (check_box.Checked == true)
            {
                dgv.Columns[column_index].Visible = true;
            } else
            {
                dgv.Columns[column_index].Visible = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loadChatTextContents();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           // loadChatTextContents();
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            applyTextColorOnDGV();
        }

        //EXPERIMENTAL
        private void doSearch(DataTable data_table, DataGridView dgv, string column_name, string search_text)
        {
            if (data_table != null)
            {
                DataView local_dv = new DataView(data_table);
                local_dv.RowFilter = column_name + " like '%" + search_text + "%'";
                dgv.DataSource = local_dv;
            }
            else
            {
                MessageBox.Show("No results found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region CHECKBOXES
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            HideUnhide_DGVColumns_by_checkBox(checkBox1, dataGridView2, 0);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            HideUnhide_DGVColumns_by_checkBox(checkBox2, dataGridView2, 1);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            HideUnhide_DGVColumns_by_checkBox(checkBox3, dataGridView2, 2);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            HideUnhide_DGVColumns_by_checkBox(checkBox4, dataGridView2, 3);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            HideUnhide_DGVColumns_by_checkBox(checkBox5, dataGridView2, 4);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            HideUnhide_DGVColumns_by_checkBox(checkBox6, dataGridView2, 5);
        }
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            doSearch(dt_txtfiles, dataGridView1, "Logs", textBox1.Text);
            statusStrip1.Items[0].Text = "Found " + dataGridView1.RowCount + " text files.";
        }
    }
}
