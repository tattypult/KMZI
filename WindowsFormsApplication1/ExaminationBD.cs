
using Devart.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public ExaminationBD()
        {
            mes = new Message("");
            sqConnection = new SQLiteConnection(myConnString);
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных SrcIP
        /// </summary>
        async public Task ExaminationSrc()
        {
            Program.message = new Form1();
            sqConnection.Open();
            for (int i = 0; i < Program.message.dataGridView1.Rows.Count-1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(SRC_IP) from FIREWALL where SRC_IP = '" + Program.message.dataGridView1.Rows[i].Cells[0].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    new Message(Program.message.dataGridView1.Rows[i].Cells[0].Value.ToString()).Show();
                }
            }
            sqConnection.Close();
            await Task.Delay(0);

            //foreach (var item in main.FIREWALL)
            //{

            //    for (; i < Program.message.dataGridView1.Rows.Count - 1; i++)
            //    {

            //if (item.SRC_IP == Program.message.dataGridView1.Rows[i].Cells[0].Value.ToString())
            //{
            //    return item.SRC_IP;
            //}
            //}


        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных SrcPort
        /// </summary>
        async public Task ExaminationSrcPort()
        {
            Program.message = new Form1();
            sqConnection.Open();
            for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(SRC_PORT) from FIREWALL where SRC_PORT = '" + Program.message.dataGridView1.Rows[i].Cells[1].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    new Message(Program.message.dataGridView1.Rows[i].Cells[1].Value.ToString()).Show();
                }
            }
            sqConnection.Close();
            await Task.Delay(0);
            //foreach (var item in main.FIREWALL)
            //{
            //    for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
            //    {
            //        if (item.SRC_PORT == Program.message.dataGridView1.Rows[i].Cells[1].Value.ToString())
            //        {
            //            return item.SRC_PORT;
            //        }
            //    }
            //}
            //return null;
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных DstIP
        /// </summary>
        async public Task ExaminationDst()
        {
            Program.message = new Form1();
            sqConnection.Open();
            for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(DST_IP) from FIREWALL where DST_IP = '" + Program.message.dataGridView1.Rows[i].Cells[2].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    new Message(Program.message.dataGridView1.Rows[i].Cells[2].Value.ToString()).Show();
                }
            }
            sqConnection.Close();
            await Task.Delay(0);

            //foreach (var item in main.FIREWALL)
            //{
            //    for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
            //    {
            //        if (item.DST_IP == Program.message.dataGridView1.Rows[i].Cells[2].Value.ToString())
            //        {
            //            return item.DST_IP;
            //        }

            //    }
            //}
            //return null;
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных DstPort
        /// </summary>
        async public Task ExaminationDstPort()
        {
            Program.message = new Form1();
            sqConnection.Open();
            for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
            {
                sqCommand = new SQLiteCommand("SELECT Count(DST_PORT) from FIREWALL where DST_PORT = '" + Program.message.dataGridView1.Rows[i].Cells[3].Value.ToString() + "'", sqConnection);
                int temp = Convert.ToInt32(sqCommand.ExecuteScalar());
                if (temp != 0)
                {
                    new Message(Program.message.dataGridView1.Rows[i].Cells[3].Value.ToString()).Show();
                }
            }
            sqConnection.Close();
            await Task.Delay(0);
            //foreach (var item in main.FIREWALL)
            //{
            //    for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
            //    {
            //        if (item.DST_PORT == Program.message.dataGridView1.Rows[i].Cells[3].Value.ToString())
            //        {
            //            return item.DST_PORT;
            //        }

            //    }
            //}
            //return null;

        }
    }
}
