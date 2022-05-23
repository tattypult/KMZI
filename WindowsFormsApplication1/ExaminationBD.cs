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
         public void ExaminationSrc()
        {
            Program.message = new Form1();
            foreach (var item in main.FIREWALL)
            {
                for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.SRC_IP == Program.message.dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        var outer = Task.Factory.StartNew(() => new Message(item.SRC_IP).Show());
                        outer.Wait();

                    }

                }
            }
        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных SrcPort
        /// </summary>
         public void ExaminationSrcPort()
        {
            Program.message = new Form1();
            foreach (var item in main.FIREWALL)
            {
                for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.SRC_PORT == Program.message.dataGridView1.Rows[i].Cells[1].Value.ToString())
                    {
                        var outer = Task.Factory.StartNew(() => new Message(item.SRC_PORT).Show());
                        outer.Wait();
                    }

                }
            }

        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных DstIP
        /// </summary>
         public void ExaminationDst()
        {
            Program.message = new Form1();
            foreach (var item in main.FIREWALL)
            {
                for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.DST_IP == Program.message.dataGridView1.Rows[i].Cells[2].Value.ToString())
                    {
                        var outer = Task.Factory.StartNew(() => new Message(item.DST_IP).Show());
                        outer.Wait();
                    }

                }
            }

        }
        /// <summary>
        /// Проверка базы данных на наличие запрещенных DstPort
        /// </summary>
        public void ExaminationDstPort()
        {
            Program.message = new Form1();
            foreach (var item in main.FIREWALL)
            {
                for (int i = 0; i < Program.message.dataGridView1.Rows.Count - 1; i++)
                {
                    if (item.DST_PORT == Program.message.dataGridView1.Rows[i].Cells[3].Value.ToString())
                    {
                        var outer = Task.Factory.StartNew(() => new Message(item.DST_PORT).Show());
                        outer.Wait();
                    }

                }
            }

        }
    }
}
