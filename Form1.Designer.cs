
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.client = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.connect_btn = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // client
            // 
            this.client.AutoSize = true;
            this.client.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.client.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.client.Location = new System.Drawing.Point(35, 34);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(187, 81);
            this.client.TabIndex = 0;
            this.client.Text = "Client";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 628);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(879, 164);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(794, 823);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(773, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 70);
            this.button2.TabIndex = 3;
            this.button2.Text = "Rekey\r\n";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 41);
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 571);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 41);
            this.label2.TabIndex = 5;
            this.label2.Text = "Message:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(143, 173);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(239, 47);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "127.0.0.1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(507, 176);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(239, 47);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "8090";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 41);
            this.label3.TabIndex = 8;
            this.label3.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 41);
            this.label4.TabIndex = 9;
            this.label4.Text = "Host:\r\n";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(784, 172);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(145, 54);
            this.connect_btn.TabIndex = 10;
            this.connect_btn.Text = "Connect\r\n\r\n";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(60, 281);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(869, 233);
            this.textBox4.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 913);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.client);
            this.Name = "Form1";
            this.Text = "te";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label client;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.TextBox textBox4;
    }
}

