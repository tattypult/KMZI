
using Devart.Data.SQLite;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    internal class ExaminationBD
    {
        mainEntities main = new mainEntities();
        Message mes;
        string myConnString = "Data Source=DB.db;";
        SQLiteConnection sqConnection;
        SQLiteCommand sqCommand;
        int count = 0;

        string datetime = null;

        public ExaminationBD()
        {
            mes = new Message();
            sqConnection = new SQLiteConnection(myConnString);
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных SrcIP
        /// </summary>
        async public Task<int> ExaminationSrc(StreamWriter stream)
        {
            Program.message = new Form1();
            main.SaveChanges();
            sqConnection.Open();
            for (int i = 0; i < Program.message.dataGridView1.RowCount - 1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(SRC_IP) from FIREWALL where SRC_IP = '" + Program.message.dataGridView1.Rows[i].Cells[0].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    stream.Write(await SetDateTimeSRCIP(Program.message.dataGridView1.Rows[i].Cells[0].Value.ToString()) + " Событие SRC_IP:" + Program.message.dataGridView1.Rows[i].Cells[0].Value.ToString() + "\n");
                    count++;
                }
            }
            stream.Close();
            sqConnection.Close();
            return count;
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных SrcPort
        /// </summary>
        async public Task<int> ExaminationSrcPort(StreamWriter stream)
        {

            Program.message = new Form1();
            main.SaveChanges();
            sqConnection.Open();
            for (int i = 0; i < Program.message.dataGridView1.RowCount - 1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(SRC_PORT) from FIREWALL where SRC_PORT = '" + Program.message.dataGridView1.Rows[i].Cells[1].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    stream.Write(await SetDateTimeSRCPort(Program.message.dataGridView1.Rows[i].Cells[1].Value.ToString()) + " Событие SRC_PORT:" + Program.message.dataGridView1.Rows[i].Cells[1].Value.ToString() + "\n");
                    count++;
                }
            }
            stream.Close();
            sqConnection.Close();
            await Task.Delay(0);
            return count;
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных DstIP
        /// </summary>
        async public Task<int> ExaminationDst(StreamWriter stream)
        {
            Program.message = new Form1();
            main.SaveChanges();
            sqConnection.Open();
            for (int i = 0; i < Program.message.dataGridView1.RowCount - 1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(DST_IP) from FIREWALL where DST_IP = '" + Program.message.dataGridView1.Rows[i].Cells[2].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    stream.Write(await SetDateTimeDSTIP(Program.message.dataGridView1.Rows[i].Cells[2].Value.ToString()) + " Событие DST_IP:" + Program.message.dataGridView1.Rows[i].Cells[2].Value.ToString() + "\n");
                    count++;
                }
            }
            stream.Close();
            sqConnection.Close();
            await Task.Delay(0);
            return count;
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных DstPort
        /// </summary>
        async public Task<int> ExaminationDstPort(StreamWriter stream)
        {
            Program.message = new Form1();
            sqConnection.Open();
            for (int i = 0; i < Program.message.dataGridView1.RowCount - 1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(DST_PORT) from FIREWALL where DST_PORT = '" + Program.message.dataGridView1.Rows[i].Cells[3].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    stream.Write(await SetDateTimeDSPTort(Program.message.dataGridView1.Rows[i].Cells[3].Value.ToString()) + " Событие DST_PORT:" + Program.message.dataGridView1.Rows[i].Cells[3].Value.ToString() + "\n");
                    count++;
                }
            }
            sqConnection.Close();
            stream.Close();
            await Task.Delay(0);
            return count;
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных INFO
        /// </summary>
        async public Task<int> ExaminationINFO(StreamWriter stream)
        {
            Program.message = new Form1();
            sqConnection.Open();
            for (int i = 0; i < Program.message.dataGridView1.RowCount - 1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(INFO) from KASPERSKY where INFO = '" + Program.message.dataGridView1.Rows[i].Cells[4].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    stream.Write(await SetDateTimeINFO(Program.message.dataGridView1.Rows[i].Cells[4].Value.ToString()) + " Событие INFO:" + Program.message.dataGridView1.Rows[i].Cells[4].Value.ToString() + "\n");
                    count++;
                }
            }
            stream.Close();
            sqConnection.Close();
            return count;
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных CODE
        /// </summary>
        async public Task<int> ExaminationCODE(StreamWriter stream)
        {
            Program.message = new Form1();
            sqConnection.Open();
            for (int i = 0; i < Program.message.dataGridView1.RowCount - 1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(CODE) from KASPERSKY where CODE = '" + Program.message.dataGridView1.Rows[i].Cells[5].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    stream.Write(await SetDateTimeCODE(Program.message.dataGridView1.Rows[i].Cells[5].Value.ToString()) + " Событие CODE:" + Program.message.dataGridView1.Rows[i].Cells[5].Value.ToString() + "\n");
                    count++;
                }
            }
            stream.Close();
            sqConnection.Close();
            return count;
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных NAME_OF_USB
        /// </summary>
        async public Task<int> ExaminationNAME_OF_USB(StreamWriter stream)
        {
            Program.message = new Form1();
            sqConnection.Open();
            for (int i = 0; i < Program.message.dataGridView1.RowCount - 1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(NAME_OF_USB) from USB where NAME_OF_USB = '" + Program.message.dataGridView1.Rows[i].Cells[6].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    stream.Write(await SetDateTimeCODE(Program.message.dataGridView1.Rows[i].Cells[6].Value.ToString()) + " Событие NAME_OF_USB:" + Program.message.dataGridView1.Rows[i].Cells[6].Value.ToString() + "\n");
                    count++;
                }
            }
            stream.Close();
            sqConnection.Close();
            return count;
        }
        /// <summary>
        /// Получение даты и времени события для NAME_OF_USB
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        async private Task<string> SetDateTimeNAME_OF_USB(string str)
        {
            foreach (var item in main.USB.
                Where(x => x.NAME_OF_USB == str).
                Select(l => new { l.DATE_AND_TIME }))
            {
                datetime = " Дата и время: " + item.DATE_AND_TIME;
                break;
            }
            await Task.Delay(0);
            return datetime;
        }
        /// <summary>
        /// Получение даты и времени события для CODE
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        async private Task<string> SetDateTimeCODE(string str)
        {
            foreach (var item in main.KASPERSKY.
                Where(x => x.CODE == str).
                Select(l => new { l.MONTH, l.CHISLO, l.TIME }))
            {
                datetime = " Месяц: " + item.MONTH + " Число: " + item.CHISLO + " Время: " + item.TIME;
                break;
            }
            await Task.Delay(0);
            return datetime;
        }
        /// <summary>
        /// Получение даты и времени события для INFO
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        async private Task<string> SetDateTimeINFO(string str)
        {
            foreach (var item in main.KASPERSKY.
                Where(x => x.INFO == str).
                Select(l => new { l.MONTH, l.CHISLO, l.TIME }))
            {
                datetime = " Месяц: " + item.MONTH + " Число: " + item.CHISLO + " Время: " + item.TIME;
                //break;
            }
            await Task.Delay(0);
            return datetime;
        }

        /// <summary>
        /// Получение даты и времени события для SRC_IP
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public async Task<string> SetDateTimeSRCIP(string str)
        {
            foreach (var item in main.FIREWALL.
                Where(x => x.SRC_IP == str).
                Select(l => new { l.DATE, l.TIME }))
            {
                datetime = " Дата: " + item.DATE + " Время: " + item.TIME;
                //break;
            }
            await Task.Delay(0);
            return datetime;
        }
        /// <summary>
        /// Получение даты и времени события для SRC_PORT
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public async Task<string> SetDateTimeSRCPort(string str)
        {
            foreach (var item in main.FIREWALL.
                Where(x => x.SRC_PORT == str).
                Select(l => new { l.DATE, l.TIME }))
            {
                datetime = " Дата: " + item.DATE + " Время: " + item.TIME;
                /*break*/
                ;
            }
            await Task.Delay(0);
            return datetime;
        }
        /// <summary>
        /// Получение даты и времени события для DST_IP
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public async Task<string> SetDateTimeDSTIP(string str)
        {
            foreach (var item in main.FIREWALL.
                Where(x => x.DST_IP == str).
                Select(l => new { l.DATE, l.TIME }))
            {
                datetime = " Дата: " + item.DATE + " Время: " + item.TIME;
                break;
            }
            await Task.Delay(0);
            return datetime;
        }
        /// <summary>
        /// Получение даты и времени события для DST_PORT
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public async Task<string> SetDateTimeDSPTort(string str)
        {
            foreach (var item in main.FIREWALL.
                Where(x => x.DST_PORT == str).
                Select(l => new { l.DATE, l.TIME }))
            {
                datetime = " Дата: " + item.DATE + " Время: " + item.TIME;
                break;
            }
            await Task.Delay(0);
            return datetime;
        }

    }
}
