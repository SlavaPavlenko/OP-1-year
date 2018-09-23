namespace WindowsFormsApp1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EvE = new System.Windows.Forms.Button();
            this.PvE = new System.Windows.Forms.Button();
            this.PvP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.EvE);
            this.panel1.Controls.Add(this.PvE);
            this.panel1.Controls.Add(this.PvP);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 400);
            this.panel1.TabIndex = 1;
            // 
            // EvE
            // 
            this.EvE.Location = new System.Drawing.Point(283, 281);
            this.EvE.Name = "EvE";
            this.EvE.Size = new System.Drawing.Size(150, 80);
            this.EvE.TabIndex = 2;
            this.EvE.Text = "EvE";
            this.EvE.UseVisualStyleBackColor = true;
            this.EvE.Click += new System.EventHandler(this.EvE_Click_1);
            // 
            // PvE
            // 
            this.PvE.Location = new System.Drawing.Point(420, 157);
            this.PvE.Name = "PvE";
            this.PvE.Size = new System.Drawing.Size(150, 80);
            this.PvE.TabIndex = 1;
            this.PvE.Text = "PvE";
            this.PvE.UseVisualStyleBackColor = true;
            this.PvE.Click += new System.EventHandler(this.PvE_Click);
            // 
            // PvP
            // 
            this.PvP.Location = new System.Drawing.Point(149, 157);
            this.PvP.Name = "PvP";
            this.PvP.Size = new System.Drawing.Size(150, 80);
            this.PvP.TabIndex = 0;
            this.PvP.Text = "PvP";
            this.PvP.UseVisualStyleBackColor = true;
            this.PvP.Click += new System.EventHandler(this.PvP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Игра";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button PvE;
        private System.Windows.Forms.Button PvP;
        private System.Windows.Forms.Button EvE;
    }
}

