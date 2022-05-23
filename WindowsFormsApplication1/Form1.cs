using Devart.Data.SQLite;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using TableDependency.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string path = "C:\\Users\\user\\Desktop\\WindowsFormsApplication1\\WindowsFormsApplication1\\data.txt";
        string[] str;
        string[] line;
        ExaminationBD examinationBD;
        double[] size = new double[4];
        mainEntities main;
        Thread thread;
        //string connectionString = "Data Source=DB.db;";

        public Form1()
        {
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
            var outer = Task.Factory.StartNew(() =>
              {
                  examinationBD.ExaminationSrcPort();
                  examinationBD.ExaminationSrc();
                  examinationBD.ExaminationDstPort();
                  examinationBD.ExaminationDst();
              });

        }
        async private void button2_Click(object sender, EventArgs e)
        {


            //Написать проверку каждого столбца и проверки добавления новых данных
            thread = new Thread(async () =>
            {
                while (true)
                {
                    On_ChangedAsync();
                    await Task.Delay(10000);
                }
            });
            thread.Start();
            await Task.Delay(0);
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
