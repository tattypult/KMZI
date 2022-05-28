
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class BackgroungCheck
    {
        int count = 0;
        string datetime = null;
        mainEntities main = new mainEntities();
        object locker = new object();

        /// <summary>
        /// Проверка и реакция на зименения в базе данных
        /// </summary>
        /// <returns></returns>
        async public Task<int> OnChangedFIREWALLAsync(DataGridView dataGridView1, long IDF)
        {
            var p = main.FIREWALL.
                Where(id => id.ID == IDF).
                Select(k => new { k.SRC_IP, k.SRC_PORT, k.DST_IP, k.DST_PORT });
            foreach (var item in p)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.SRC_IP == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        WriteLogFirewall(i, IDF, dataGridView1, "SRC_IP", dataGridView1.Rows[i].Cells[0].Value.ToString());
                        count++;
                    }
                    if (item.SRC_PORT == dataGridView1.Rows[i].Cells[1].Value.ToString())
                    {
                        WriteLogFirewall(i, IDF, dataGridView1, "SRC_PORT", dataGridView1.Rows[i].Cells[1].Value.ToString());
                        count++;
                    }
                    if (item.DST_IP == dataGridView1.Rows[i].Cells[2].Value.ToString())
                    {
                        WriteLogFirewall(i, IDF, dataGridView1, "DST_IP", dataGridView1.Rows[i].Cells[2].Value.ToString());
                        count++;
                    }
                    if (item.DST_PORT == dataGridView1.Rows[i].Cells[3].Value.ToString())
                    {
                        WriteLogFirewall(i, IDF, dataGridView1, "DST_PORT", dataGridView1.Rows[i].Cells[3].Value.ToString());
                        count++;
                    }
                }
            }
            await Task.Delay(0);
            return count;
        }
        /// <summary>
        /// Получение даты и времени из таблицы Firewall
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string SetDateTimeFirewall(long ID)
        {
            foreach (var item in main.FIREWALL.
                Where(x => x.ID == ID).
                Select(l => new { l.DATE, l.TIME }))
            {
                datetime = " Дата: " + item.DATE + " Время: " + item.TIME;
                break;
            }
            return datetime;
        }
        /// <summary>
        /// Проверка и реакция на зименения в базе данных
        /// </summary>
        /// <returns></returns>
        async public Task<int> OnChangedKASPERSKYAsync(DataGridView dataGridView1, long IDK)
        {
            var p = main.KASPERSKY.
                Where(id => id.ID == IDK).
                Select(k => new { k.INFO, k.CODE });
            foreach (var item in p)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.INFO == dataGridView1.Rows[i].Cells[4].Value.ToString())
                    {
                        WriteLogKaspersky(i, IDK, dataGridView1, "INFO", dataGridView1.Rows[i].Cells[4].Value.ToString());
                        count++;
                    }
                    if (item.CODE == dataGridView1.Rows[i].Cells[5].Value.ToString())
                    {
                        WriteLogKaspersky(i, IDK, dataGridView1, "CODE", dataGridView1.Rows[i].Cells[5].Value.ToString());
                        count++;
                    }
                }
            }
            await Task.Delay(0);
            return count;
        }
        /// <summary>
        /// Получение даты и времени из таблицы Kaspersky
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string SetDateTimeKaspersky(long ID)
        {
            foreach (var item in main.KASPERSKY.
                Where(x => x.ID == ID).
                Select(l => new { l.CHISLO, l.MONTH, l.TIME }))
            {
                datetime = " Число: " + item.CHISLO + " Месяц: " + item.MONTH + " Время: " + item.TIME;
                break;
            }
            return datetime;
        }
        /// <summary>
        /// Проверка и реакция на зименения в базе данных
        /// </summary>
        /// <returns></returns>
        async public Task<int> OnChangedUSBAsync(DataGridView dataGridView1, long IDU)
        {
            var p = main.USB.
                Where(id => id.ID == IDU).
                Select(k => new { k.NAME_OF_USB });

            foreach (var item in p)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.NAME_OF_USB == dataGridView1.Rows[i].Cells[6].Value.ToString())
                    {
                        WriteLogUSB(i, IDU, dataGridView1);
                        count++;
                    }
                }
            }
            await Task.Delay(0);
            return count;
        }

        /// <summary>
        /// Получение даты и времени из таблицы USB
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string SetDateTimeUsb(long ID)
        {
            foreach (var item in main.USB.
                Where(x => x.ID == ID).
                Select(l => new { l.DATE_AND_TIME }))
            {
                datetime = " Дата и время: " + item.DATE_AND_TIME;
                break;
            }
            return datetime;
        }
        /// <summary>
        /// Записывеает событие в лог USB
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ID"></param>
        public void WriteLogUSB(int i, long ID, DataGridView dataGridView1)
        {
            lock (locker)
            {
                using (StreamWriter stream = new StreamWriter(Path.GetFullPath(@".\log.txt"), true))
                {
                    stream.Write(SetDateTimeUsb(ID) + " Событие NAME_OF_USB:" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "\n");
                    stream.Close();
                }
            }
        }
        /// <summary>
        /// Записывеает событие в лог FIREWALL
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ID"></param>
        public void WriteLogFirewall(int i, long ID, DataGridView dataGridView1, string src, string value)
        {
            lock (locker)
            {
                using (StreamWriter stream = new StreamWriter(Path.GetFullPath(@".\log.txt"), true))
                {
                    stream.Write(SetDateTimeFirewall(ID) + " Событие " + src + ":" + value + "\n");
                    stream.Close();
                }
            }
        }
        /// <summary>
        /// Записывеает событие в лог KASPERSKY
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ID"></param>
        public void WriteLogKaspersky(int i, long ID, DataGridView dataGridView1, string src, string value)
        {
            lock (locker)
            {
                using (StreamWriter stream = new StreamWriter(Path.GetFullPath(@".\log.txt"), true))
                {
                    stream.Write(SetDateTimeKaspersky(ID) + " Событие " + src + ":" + value + "\n");
                    stream.Close();
                }
            }
        }
    }
}
