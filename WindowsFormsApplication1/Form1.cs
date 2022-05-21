using Devart.Data.SQLite;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        mainEntities main = new mainEntities();
        FIREWALL fire;
        KASPERSKY kaspersky = new KASPERSKY();
        USB usb = new USB();
        string path = "C:\\Users\\user\\Desktop\\WindowsFormsApplication1\\WindowsFormsApplication1\\data.txt";

        string[] s;
        string[] s2;
        public Form1()
        {
            InitializeComponent();
            s = File.ReadAllLines(path);
            s2 = new string[s.Length * 4];
            dataGridView1.Rows.Add(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                s2 = s[i].Split('^');
                for (int j = 0; j < s2.Length; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = s2[j];
                }
            }

            fire = new FIREWALL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter str = new StreamWriter(path, false))
            {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (j != dataGridView1.Columns.Count - 1)
                            str.Write(dataGridView1.Rows[i].Cells[j].Value + "^");
                        else
                            str.Write(dataGridView1.Rows[i].Cells[j].Value);
                    }
                    if (i != dataGridView1.Rows.Count - 2)
                        str.Write("\n");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string mySelectQuery = "SELECT SRC_IP FROM FIREWALL";
            //string myConnString = "DataSource=DB.db;";
            //SQLiteConnection sqConnection = new SQLiteConnection(myConnString);
            //SQLiteCommand sqCommand = new SQLiteCommand(mySelectQuery, sqConnection);
            //sqConnection.Open();
            //SQLiteDataReader sqReader = sqCommand.ExecuteReader();
            //var enumer= sqReader.;
            //for (int i = 0; sqReader.Read(); i++)
            //{

            //    if (enumer == listBox1.Items[3])
            //        MessageBox.Show("Alarm Пиздец");
            //}
            //sqReader.Close();
            //// always call Close when done reading.
            //sqConnection.Close();

            //Написать проверку каждого столбца и проверки добавления новых данных

            //foreach (var item in main.FIREWALL)
            //{
            //    Parallel.Invoke(
            //        () =>
            //        {
            //            for (int i = 0; i < listBox1.Items.Count; i++)
            //            {
            //                if (item.SRC_IP == listBox1.Items[3].ToString())
            //                {
            //                    MessageBox.Show("Alarm Пизда");
            //                }
            //            }
            //        },
            //        () =>
            //        {
            //            for (int i = 0; i < listBox1.Items.Count; i++)
            //            {
            //                if (item.SRC_PORT == listBox1.Items[3].ToString())
            //                {
            //                    MessageBox.Show("Alarm Пизда");
            //                }
            //            }
            //        },
            //         () =>
            //        {
            //            for (int i = 0; i < listBox1.Items.Count; i++)
            //            {
            //                if (item.DST_IP == listBox1.Items[3].ToString())
            //                {
            //                    MessageBox.Show("Alarm Пизда");
            //                }
            //            }
            //        },
            //        () =>
            //        {
            //            for (int i = 0; i < listBox1.Items.Count; i++)
            //            {
            //                if (item.DST_PORT == listBox1.Items[3].ToString())
            //                {
            //                    MessageBox.Show("Alarm Пизда");
            //                }
            //            }
            //        });
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
