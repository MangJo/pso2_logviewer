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
                loadTxtFilesToDGV_List(dataGridView1, Settings.logPathDir, "ChatLog*");
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

        public void loadTxtFilesToDGV_List(DataGridView data_grid_view, string folder, string filename)
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

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            if (Settings.saveSettings(Settings.selectFolder()))
            {
                refreshContents();
            }
        }

        private void loadChatTextContents()
        {
            //Experimental: UNSTABLE/BAD IMPLEMENTATION 
            string temp = Settings.logPathDir + "\\" + dataGridView1.CurrentCell.Value;

            //Create column names
            String[] columnNames = new String[]
            {
                "DateTime", "ChatLine", "ChatType", "PlayerID", "CharName", "Chat"
            };

            //Create DataTable
            DataTable dt = new DataTable();

            //Add columns and apply column names
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
                        //This one is a tricky, there are chat lines that uses newline as in continuation
                        //of previous chat on a new line (hard to explain in words lol)
                        //something like this:
                        //Chat: I'm selling this
                        //      Item for
                        //      500M

                        //Instead of being 1 line:
                        //Chat: I'm selling this Item for 500M
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

            //Coloring the text of the row according to its chat type
            dataGridView2.DefaultCellStyle.BackColor = Color.Black;

            var chatTypeColor = new Dictionary<string, Color>();
            chatTypeColor.Add("PUBLIC", Color.White);
            chatTypeColor.Add("PARTY", Color.Aqua);
            chatTypeColor.Add("GUILD", Color.Orange);
            chatTypeColor.Add("REPLY", Color.Violet);

            colorizeRow_ChatLine(dataGridView2, 2, chatTypeColor);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loadChatTextContents();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           // loadChatTextContents();
        }
    }
}
