using Devart.Data.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string path = @"C:\Users\user\Desktop\WFA1\WindowsFormsApplication1\data.txt";
        string[] str;
        string[] line;
        double[] size = new double[4];
        string connectionString = "Data Source=DB.db;";
        string query = "SELECT MAX(ID) From FIREWALL";
        //string query = "select SRC_IP,SRC_PORT,DST_IP,DST_PORT from FIREWALL";

        ExaminationBD examinationBD;
        mainEntities main;
        SQLiteDataAdapter adapter;
        SQLiteConnection sqConnection;
        SQLiteCommand sqCommand;
        SQLiteDataSet litedataset;
        SQLiteDataReader sqlreader;
        System.Timers.Timer timer = new System.Timers.Timer();

        public Form1()
        {
            litedataset = new SQLiteDataSet();
            sqConnection = new SQLiteConnection(connectionString);
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

            timer.Interval = 5000;
            timer.Elapsed += button4_Click_1;
            timer.Start();
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
        async public Task On_ChangedAsync()
        {
            sqConnection.Open();
            sqCommand = new SQLiteCommand(query, sqConnection);
            int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
            var p = main.FIREWALL.Where(id => id.ID == temp).Select(k => new { k.SRC_IP, k.SRC_PORT, k.DST_IP, k.DST_PORT });
            foreach (var item in p)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (item.SRC_IP == dataGridView1.Rows[i].Cells[j].Value.ToString())
                            MessageBox.Show("Появилось новое сообщение");
                        if (item.SRC_PORT == dataGridView1.Rows[i].Cells[j].Value.ToString())
                            MessageBox.Show("Появилось новое сообщение");
                        if (item.DST_IP == dataGridView1.Rows[i].Cells[j].Value.ToString())
                            MessageBox.Show("Появилось новое сообщение");
                        if (item.DST_PORT == dataGridView1.Rows[i].Cells[j].Value.ToString())
                            MessageBox.Show("Появилось новое сообщение");
                    }
                }
            }
            sqConnection.Close();
            await Task.Delay(0);
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
        }

        async private void button4_Click_1(object sender, EventArgs e)
        {
          await On_ChangedAsync();
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
