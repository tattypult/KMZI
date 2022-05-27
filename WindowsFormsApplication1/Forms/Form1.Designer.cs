namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SRC_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SRC_Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DST_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DST_Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INFO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME_OF_USB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 294);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 68);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить запрещенный значения";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(629, 294);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 68);
            this.button2.TabIndex = 3;
            this.button2.Text = "Поиск по всей базе данных";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(149, 294);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 68);
            this.button3.TabIndex = 4;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SRC_IP,
            this.SRC_Port,
            this.DST_IP,
            this.DST_Port,
            this.INFO,
            this.CODE,
            this.NAME_OF_USB});
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(931, 287);
            this.dataGridView1.TabIndex = 5;
            // 
            // SRC_IP
            // 
            this.SRC_IP.HeaderText = "SRC";
            this.SRC_IP.MinimumWidth = 6;
            this.SRC_IP.Name = "SRC_IP";
            this.SRC_IP.Width = 125;
            // 
            // SRC_Port
            // 
            this.SRC_Port.HeaderText = "SRCP";
            this.SRC_Port.MinimumWidth = 6;
            this.SRC_Port.Name = "SRC_Port";
            this.SRC_Port.Width = 125;
            // 
            // DST_IP
            // 
            this.DST_IP.HeaderText = "DST";
            this.DST_IP.MinimumWidth = 6;
            this.DST_IP.Name = "DST_IP";
            this.DST_IP.Width = 125;
            // 
            // DST_Port
            // 
            this.DST_Port.HeaderText = "DSTP";
            this.DST_Port.MinimumWidth = 6;
            this.DST_Port.Name = "DST_Port";
            this.DST_Port.Width = 125;
            // 
            // INFO
            // 
            this.INFO.HeaderText = "INFO";
            this.INFO.MinimumWidth = 6;
            this.INFO.Name = "INFO";
            this.INFO.Width = 125;
            // 
            // CODE
            // 
            this.CODE.HeaderText = "CODE";
            this.CODE.MinimumWidth = 6;
            this.CODE.Name = "CODE";
            this.CODE.Width = 125;
            // 
            // NAME_OF_USB
            // 
            this.NAME_OF_USB.HeaderText = "NAME_OF_USB";
            this.NAME_OF_USB.MinimumWidth = 6;
            this.NAME_OF_USB.Name = "NAME_OF_USB";
            this.NAME_OF_USB.Width = 125;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(309, 294);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 68);
            this.button4.TabIndex = 6;
            this.button4.Text = "Запустить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(469, 294);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(143, 68);
            this.button5.TabIndex = 7;
            this.button5.Text = "Остановить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(787, 294);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 68);
            this.button6.TabIndex = 8;
            this.button6.Text = "Добавить значение в бд";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 364);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SRC_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SRC_Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn DST_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DST_Port;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn INFO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME_OF_USB;
        private System.Windows.Forms.Button button6;
    }
}

