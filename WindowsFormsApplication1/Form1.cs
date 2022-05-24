using Devart.Data.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string path = @"C:\Users\Admin\Desktop\WFA1\WindowsFormsApplication1\data.txt";
        string[] str;
        string[] line;
        double[] size = new double[4];
        string connectionString = "Data Source=DB.db;";
        string query = "SELECT MAX(ID) From FIREWALL";
        //string query = "select SRC_IP,SRC_PORT,DST_IP,DST_PORT from FIREWALL";

        ExaminationBD examinationBD;
        mainEntities main;
        Thread thread;
        List<string> list;
        SQLiteDataAdapter adapter;
        SQLiteConnection sqConnection;
        SQLiteCommand sqCommand;
        SQLiteDataSet litedataset;
        SQLiteDataReader sqlreader;


        public Form1()
        {
            litedataset = new SQLiteDataSet();
            sqConnection = new SQLiteConnection(connectionString);
            sqCommand = new SQLiteCommand(query, sqConnection);
            adapter = new SQLiteDataAdapter(sqCommand);

            main = new mainEntities();
            examinationBD = new ExaminationBD();
            InitializeComponent();
            str = File.ReadAllLines(path);
            line = new string[str.Length * 4];
            dataGridView1.Rows.Add(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                line = str[i].Split('^');
                for (int j = 0; j < line.Length; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = line[j];
                }
            }
            list = new List<string>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter str = new StreamWriter(path, false))
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
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
        public void On_ChangedAsync()
        {
            sqConnection.Open();
            int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
            sqlreader = sqCommand.ExecuteReader();
            sqlreader.Read();
            textBox1.Text = ((int)sqlreader["ID"]-1).ToString();
            sqlreader.Close();
            sqConnection.Close();
        }

        public void OnChange()
        {
            for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(SRC_IP) from FIREWALL where SRC_IP = '" + Program.message.dataGridView1.Rows[i].Cells[0].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    new Message(Program.message.dataGridView1.Rows[i].Cells[0].Value.ToString()).Show();
                }
            }
        }
        /// <summary>
        /// При запуске происходит проверка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void button2_Click(object sender, EventArgs e)
        {
            await examinationBD.ExaminationSrc();
            await examinationBD.ExaminationSrcPort();
            await examinationBD.ExaminationDstPort();
            await examinationBD.ExaminationDst();
            On_ChangedAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
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
    //string query = "SELECT SRC_IP,SRC_PORT,DST_IP,DST_PORT FROM FIREWALL";
    //SqlCommand command = new SqlCommand(query);
    //var dep = new SqlDependency(command);
    //SQLiteConnection sql=new SQLiteConnection(connectionString);
    //sql.Open();
}
