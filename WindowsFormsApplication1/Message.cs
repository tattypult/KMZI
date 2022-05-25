using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
        }

        private void Message_Load(object sender, EventArgs e)
        {
            label1.Text = "У вас новое сообщение!";
            this.StartPosition = FormStartPosition.Manual;
            var wArea = Screen.PrimaryScreen.WorkingArea;
            this.Left = wArea.Width + wArea.Left - this.Width;
            this.Top = wArea.Height + wArea.Top - this.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var journal = Application.OpenForms["Journal"];
            if (journal!=null)
            {
                journal.Close();
                this.Close();
                new Journal().ShowDialog();
            }
            else
            {
                this.Close();
                new Journal().ShowDialog();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
