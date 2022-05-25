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
        int count = 0;
        long ID = 0;
        double[] size = new double[4];
        string datetime = null;

        ExaminationBD examinationBD;
        mainEntities main;
        System.Timers.Timer timer = new System.Timers.Timer();

        public Form1()
        {
            main = new mainEntities();
            examinationBD = new ExaminationBD();
            InitializeComponent();
            str = File.ReadAllLines(path);
            line = new string[str.Length * 4];
            dataGridView1.Rows.Add(str.Length);
            int t = dataGridView1.RowCount;
            for (int i = 0; i < str.Length; i++)
            {
                line = str[i].Split('^');
                for (int j = 0; j < line.Length; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = line[j];
                }
            }
        }
        /// <summary>
        /// Добавляет запрещенные значения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Проверка и реакция на зименения в базе данных
        /// </summary>
        /// <returns></returns>
        async public Task On_ChangedAsync()
        {
            count = 0;
            long temp = main.FIREWALL.Max(id => id.ID);
            if (ID == temp)
                goto Next;

            ID = temp;
            var p = main.FIREWALL.
                Where(id => id.ID == temp).
                Select(k => new { k.SRC_IP, k.SRC_PORT, k.DST_IP, k.DST_PORT });
            using (StreamWriter stream = new StreamWriter(@"C:\Users\user\Desktop\WFA1\WindowsFormsApplication1\log.txt", true))
            {
                foreach (var item in p)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (item.SRC_IP == dataGridView1.Rows[i].Cells[0].Value.ToString())
                        {
                            stream.Write(await SetDateTime(ID) + " Событие:" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "\n");
                        }
                        if (item.SRC_PORT == dataGridView1.Rows[i].Cells[1].Value.ToString())
                        {
                            stream.Write(await SetDateTime(ID) + " Событие:" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "\n");
                            count++;
                        }
                        if (item.DST_IP == dataGridView1.Rows[i].Cells[2].Value.ToString())
                        {
                            stream.Write(await SetDateTime(ID) + " Событие:" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "\n");
                            count++;
                        }
                        if (item.DST_PORT == dataGridView1.Rows[i].Cells[3].Value.ToString())
                        {
                            stream.Write(await SetDateTime(ID) + " Событие:" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "\n");
                            count++;
                        }
                    }
                }
            };
            if (count > 0)
                new Message().ShowDialog();
            Next: { }
        }

        private async Task<string> SetDateTime(long ID)
        {
            foreach (var item in main.FIREWALL.
                Where(x => x.ID == ID).
                Select(l => new { l.DATE, l.TIME }))
            {
                datetime = " Дата: " + item.DATE + " Время: " + item.TIME;
            }
            await Task.Delay(0);
            return datetime;
        }

        /// <summary>
        /// Проверить всю базу данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void button2_Click(object sender, EventArgs e)
        {
            count = await examinationBD.ExaminationSrc(new StreamWriter(@"C:\Users\user\Desktop\WFA1\WindowsFormsApplication1\log.txt", true));
            count = await examinationBD.ExaminationSrcPort(new StreamWriter(@"C:\Users\user\Desktop\WFA1\WindowsFormsApplication1\log.txt", true));
            count = await examinationBD.ExaminationDstPort(new StreamWriter(@"C:\Users\user\Desktop\WFA1\WindowsFormsApplication1\log.txt", true));
            count = await examinationBD.ExaminationDst(new StreamWriter(@"C:\Users\user\Desktop\WFA1\WindowsFormsApplication1\log.txt", true));
            count = await examinationBD.ExaminationINFO(new StreamWriter(@"C:\Users\user\Desktop\WFA1\WindowsFormsApplication1\log.txt", true));
            count = await examinationBD.ExaminationCODE(new StreamWriter(@"C:\Users\user\Desktop\WFA1\WindowsFormsApplication1\log.txt", true));
            count = await examinationBD.ExaminationNAME_OF_USB(new StreamWriter(@"C:\Users\user\Desktop\WFA1\WindowsFormsApplication1\log.txt", true));
            if (count > 0)
            {
                new Message().ShowDialog();
            }
        }
        /// <summary>
        /// Метод, вызывающийся через 1 сек и проверяющий базу данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void button4_Click_1(object sender, EventArgs e)
        {
            timer.Interval = 5000;
            timer.Elapsed += Timer;
            timer.Start();
            await Task.Delay(0);
        }
        async private void Timer(object sender, System.Timers.ElapsedEventArgs e)
        {
            await On_ChangedAsync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer.Stop();
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
