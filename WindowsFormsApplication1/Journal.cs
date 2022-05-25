using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Journal : Form
    {
        string[] str;
        string path = @"C:\Users\user\Desktop\WFA1\WindowsFormsApplication1\log.txt";
        public Journal()
        {
            str = File.ReadAllLines(path);
            InitializeComponent();
            for (int i = 0; i < str.Length; i++)
            {
                listBox1.Items.Add(str[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
