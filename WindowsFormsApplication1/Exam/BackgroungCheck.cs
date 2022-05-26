using Devart.Data.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class BackgroungCheck
    {
        long IDF = 0;
        long IDK = 0;
        long IDU = 0;
        int count = 0;
        string datetime = null;
        mainEntities main = new mainEntities();
        object locker = new object();
        string myConnString = "Data Source=DB.db;";
        SQLiteConnection sQLite;
        SQLiteCommand sqCommand;
        public BackgroungCheck()
        {
            sQLite = new SQLiteConnection(myConnString);
        }
        public void Update(string basa)
        {
            sqCommand = new SQLiteCommand("Update " + basa, sQLite);
        }
        /// <summary>
        /// Проверка и реакция на зименения в базе данных
        /// </summary>
        /// <returns></returns>
        async public Task<int> OnChangedFIREWALLAsync(DataGridView dataGridView1)
        {
            //sQLite.Open();
            //Update("FIREWALL");
            //sqCommand.ExecuteNonQuery();
            long temp = main.FIREWALL.Max(id => id.ID);
            if (IDF == temp)
            {
                count = 0;
                goto Next;
            }

            IDF = temp;
            var p = main.FIREWALL.
                Where(id => id.ID == temp).
                Select(k => new { k.SRC_IP, k.SRC_PORT, k.DST_IP, k.DST_PORT });
            foreach (var item in p)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.SRC_IP == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        WriteLog(i, IDF, dataGridView1);
                        count++;
                    }
                    if (item.SRC_PORT == dataGridView1.Rows[i].Cells[1].Value.ToString())
                    {
                        WriteLog(i, IDF, dataGridView1);
                        count++;
                    }
                    if (item.DST_IP == dataGridView1.Rows[i].Cells[2].Value.ToString())
                    {
                        WriteLog(i, IDF, dataGridView1);
                        count++;
                    }
                    if (item.DST_PORT == dataGridView1.Rows[i].Cells[3].Value.ToString())
                    {
                        WriteLog(i, IDF, dataGridView1);
                        count++;
                    }
                }
            }
            await Task.Delay(0);
        Next:
            {
                //sQLite.Close();
                return count;
            }
        }
        /// <summary>
        /// Получение даты и времени из таблицы Firewall
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private async Task<string> SetDateTimeFirewall(long ID)
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
        /// Проверка и реакция на зименения в базе данных
        /// </summary>
        /// <returns></returns>
        async public Task<int> OnChangedKASPERSKYAsync(DataGridView dataGridView1)
        {
            //sQLite.Open();
            //Update("KASPERSKY");
            //sqCommand.ExecuteNonQuery();
            long temp = main.KASPERSKY.Max(id => id.ID);
            if (IDK == temp)
            {
                count = 0;
                goto Next;
            }


            IDK = temp;
            var p = main.KASPERSKY.
                Where(id => id.ID == temp).
                Select(k => new { k.INFO, k.CODE });
            foreach (var item in p)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.INFO == dataGridView1.Rows[i].Cells[4].Value.ToString())
                    {
                        WriteLog(i, IDK, dataGridView1);
                        count++;
                    }
                    if (item.CODE == dataGridView1.Rows[i].Cells[5].Value.ToString())
                    {
                        WriteLog(i, IDK, dataGridView1);
                        count++;
                    }
                }
            }
            await Task.Delay(0);
        Next:
            {
                //sQLite.Close();
                return count;
            }
        }
        /// <summary>
        /// Получение даты и времени из таблицы Kaspersky
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private async Task<string> SetDateTimeKaspersky(long ID)
        {
            foreach (var item in main.KASPERSKY.
                Where(x => x.ID == ID).
                Select(l => new { l.CHISLO, l.MONTH, l.TIME }))
            {
                datetime = " Число: " + item.CHISLO + " Месяц: " + item.MONTH + " Время: " + item.TIME;
            }
            await Task.Delay(0);
            return datetime;
        }
        /// <summary>
        /// Проверка и реакция на зименения в базе данных
        /// </summary>
        /// <returns></returns>
        async public Task<int> OnChangedUSBAsync(DataGridView dataGridView1)
        {
            //sQLite.Open();
            //Update("USB");
            //sqCommand.ExecuteNonQuery();

            long temp = main.USB.Max(id => id.ID);
            if (IDU == temp)
            {
                count = 0;
                goto Next;
            }

            IDU = temp;
            var p = main.USB.
                Where(id => id.ID == temp).
                Select(k => new { k.NAME_OF_USB });

            foreach (var item in p)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.NAME_OF_USB == dataGridView1.Rows[i].Cells[6].Value.ToString())
                    {
                        WriteLog(i, IDU, dataGridView1);
                        count++;
                    }
                }
            }
            await Task.Delay(0);
        Next:
            {
                //sQLite.Close();
                return count;
            }
        }

        /// <summary>
        /// Получение даты и времени из таблицы USB
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private async Task<string> SetDateTimeUsb(long ID)
        {
            foreach (var item in main.USB.
                Where(x => x.ID == ID).
                Select(l => new { l.DATE_AND_TIME }))
            {
                datetime = " Дата и время: " + item.DATE_AND_TIME;
            }
            await Task.Delay(0);
            return datetime;
        }
        /// <summary>
        /// Записывеает событие в лог
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ID"></param>
        public void WriteLog(int i, long ID, DataGridView dataGridView1)
        {
            lock (locker)
            {
                using (StreamWriter stream = new StreamWriter(Path.GetFullPath(@".\log.txt"), true))
                {
                    stream.Write(SetDateTimeUsb(ID) + " Событие DATE_AND_TIME:" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "\n");
                    stream.Close();
                }
            }
        }
    }
}
