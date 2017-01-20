using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pso2_logviewer
{
    //I can't think of a better class name LOL, but this class contains simple, generic functions that can be
    //re-used on many forms or controls.
    static class Mastermind
    {
        //Simple filter using DataView. Here, I used only one column name for the query, because it's limited
        //and it is just a small app, I used a ComboBox to contain collections of ColumnNames.
        public static void doSearch(DataTable data_table, DataGridView dgv, string column_name, string search_text)
        {
            if (dgv.RowCount == 0)
            {
                return;
            }
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

        //You may want to add code for storing and loading checked values on an XML file.
        public static void HideUnhide_DGVColumns_by_checkBox(CheckBox check_box, DataGridView dgv, int column_index)
        {
            if (dgv.ColumnCount == 0)
            {
                return;
            }

            if (check_box.Checked == true)
            {
                dgv.Columns[column_index].Visible = true;
            }
            else
            {
                dgv.Columns[column_index].Visible = false;
            }
        }

        public static void colorizeRow_ChatLine(DataGridView dgv, int colIndex, Dictionary<string, Color> chat_type_color)
        {
            Color colorizer_temp = new Color();
            //Selects a row by using a loop.
            for (int ctr = 0; ctr < dgv.Rows.Count; ctr++)
            {
                //Get the chat type text from the DGV
                var str_msg = dgv[colIndex, ctr].Value.ToString();
                
                //Loop through the dictionary that holds key value pair; CHAT_TYPE:COLOR in this case.
                foreach (var chat_type in chat_type_color)
                {
                    //If it found a match, place the color on a var then break out of loop.
                    if (str_msg == chat_type.Key)
                    {
                        colorizer_temp = chat_type_color[chat_type.Key];
                        break;
                    }
                    //if it did not found any matching key, continue to the next key until it finds one
                    else
                    {
                        continue;
                    }
                }

                //Colorize all text on the current row.
                dgv.Rows[ctr].DefaultCellStyle.ForeColor = colorizer_temp;
            }
        }

        //Load Text files list into a DataTable
        public static DataTable loadTxtFiles_as_dataTable(string folder, string filename)
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

        //Old, initial implementation
        public static void loadTxtFilesToDGV_List(DataGridView data_grid_view, string folder, string filename)
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

        public static void addColumnNamesToDataTable(DataTable data_table, String[] column_names)
        {
            foreach (string column_name in column_names)
            {
                data_table.Columns.Add(column_name);
            }
        }

        public static void addItemsToComboBoxFilter(ComboBox combo_box, String[] items)
        {
            foreach (string item in items)
            {
                combo_box.Items.Add(item);
            }
        }
    }
}
