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
        long IDF = 0;
        long IDK = 0;
        long IDU = 0;
        long ID1 = 0;
        long ID2 = 0;
        long ID3 = 0;
        string path = Path.GetFullPath(@".\data.txt");
        string[] str;
        string[] line;
        double[] size = new double[4];
        int count = 0;
        string myConnString = "Data Source=DB.db;";

        SQLiteConnection sqConnection;
        SQLiteCommand sqCommand;

        ExaminationBD examinationBD;
        mainEntities main;
        BackgroungCheck backgroung;
        System.Timers.Timer timer = new System.Timers.Timer();

        public Form1()
        {
            sqConnection = new SQLiteConnection(myConnString);
            main = new mainEntities();
            backgroung = new BackgroungCheck();
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
        /// Проверить всю базу данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                count = await examinationBD.ExaminationSrc(new StreamWriter(Path.GetFullPath(@".\log.txt"), true));
                count = await examinationBD.ExaminationSrcPort(new StreamWriter(Path.GetFullPath(@".\log.txt"), true));
                count = await examinationBD.ExaminationDstPort(new StreamWriter(Path.GetFullPath(@".\log.txt"), true));
                count = await examinationBD.ExaminationDst(new StreamWriter(Path.GetFullPath(@".\log.txt"), true));
                count = await examinationBD.ExaminationINFO(new StreamWriter(Path.GetFullPath(@".\log.txt"), true));
                count = await examinationBD.ExaminationCODE(new StreamWriter(Path.GetFullPath(@".\log.txt"), true));
                count = await examinationBD.ExaminationNAME_OF_USB(new StreamWriter(Path.GetFullPath(@".\log.txt"), true));
            }
            catch (Exception)
            {
            }
            if (count > 0)
            {
                new Message().ShowDialog();
            }
        }
        /// <summary>
        /// Запуск и настройка таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void button4_Click_1(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Elapsed += Timer;
            timer.Start();
            await Task.Delay(0);
        }
        /// <summary>
        /// Проверка базы данных на последнюю строчку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void Timer(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                count = 0;
                main.ChangeTracker.Entries().ToList().ForEach(k => k.Reload());
                main.SaveChanges();
                ID1 = main.FIREWALL.Max(id => id.ID);
                ID2 = main.KASPERSKY.Max(id => id.ID);
                ID3 = main.USB.Max(id => id.ID);
                if (IDF == ID1 && IDK == ID2 && IDU == ID3)
                {
                    count = 0;
                    goto Next;
                }
                else
                {
                    IDF = ID1;
                    IDK = ID2;
                    IDU = ID3;
                    count = await backgroung.OnChangedFIREWALLAsync(dataGridView1, IDF);
                    count = await backgroung.OnChangedKASPERSKYAsync(dataGridView1, IDK);
                    count = await backgroung.OnChangedUSBAsync(dataGridView1, IDU);
                }
            }
            catch (Exception)
            {
            }
        Next:
            {
                if (count > 0)
                    new Message().ShowDialog();
            }
        }
        /// <summary>
        /// Таймер стоп
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
        /// <summary>
        /// Кнопка удаления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Добавление нового значения в базу данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            sqConnection.Open();
            sqCommand = new SQLiteCommand("Insert into FIREWALL(SRC_IP) values ('10.33.78.20') ", sqConnection);
            sqCommand.ExecuteNonQuery();
            main.SaveChanges();
            sqConnection.Close();
        }
    }
}
