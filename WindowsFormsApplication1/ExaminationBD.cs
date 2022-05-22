using System.Linq;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    internal class ExaminationBD
    {
        mainEntities main = new mainEntities();
        FIREWALL fire;
        KASPERSKY kaspersky = new KASPERSKY();
        USB usb = new USB();
        Message mes;
        public ExaminationBD()
        {
            mes = new Message("");

        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных SrcIP
        /// </summary>
        async public Task ExaminationSrc()
        {
            Program.message = new Form1();
            foreach (var item in main.FIREWALL)
            {
                for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.SRC_IP == Program.message.dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        new Message(item.SRC_IP).Show();
                    }

                }
            }
            await Task.Delay(0);

        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных SrcPort
        /// </summary>
        async public Task ExaminationSrcPort()
        {
            Program.message = new Form1();
            foreach (var item in main.FIREWALL)
            {
                for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.SRC_PORT == Program.message.dataGridView1.Rows[i].Cells[1].Value.ToString())
                    {
                        new Message(item.SRC_PORT).Show();
                    }

                }
            }
            await Task.Delay(0);

        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных DstIP
        /// </summary>
        async public Task ExaminationDst()
        {
            Program.message = new Form1();
            foreach (var item in main.FIREWALL)
            {
                for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.DST_IP == Program.message.dataGridView1.Rows[i].Cells[2].Value.ToString())
                    {
                        new Message(item.DST_IP).Show();
                    }

                }
            }
            await Task.Delay(0);
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных DstPort
        /// </summary>
        async public Task ExaminationDstPort()
        {
            Program.message = new Form1();
            foreach (var item in main.FIREWALL)
            {
                for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.DST_PORT == Program.message.dataGridView1.Rows[i].Cells[3].Value.ToString())
                    {
                        new Message(item.DST_PORT).Show();
                    }

                }
            }
            await Task.Delay(0);
        }
    }
}
