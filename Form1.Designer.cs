
namespace Client
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
            client = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            textBox3 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            connect_btn = new System.Windows.Forms.Button();
            textBox4 = new System.Windows.Forms.RichTextBox();
            SuspendLayout();
            // 
            // client
            // 
            client.AutoSize = true;
            client.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            client.ForeColor = System.Drawing.SystemColors.HotTrack;
            client.Location = new System.Drawing.Point(16, 17);
            client.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            client.Name = "client";
            client.Size = new System.Drawing.Size(94, 41);
            client.TabIndex = 0;
            client.Text = "Client";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(28, 519);
            textBox1.Margin = new System.Windows.Forms.Padding(1);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(611, 82);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(571, 613);
            button1.Margin = new System.Windows.Forms.Padding(1);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(68, 26);
            button1.TabIndex = 2;
            button1.Text = "Send\r\n";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            button2.Location = new System.Drawing.Point(547, 82);
            button2.Margin = new System.Windows.Forms.Padding(1);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(73, 34);
            button2.TabIndex = 3;
            button2.Text = "Rekey\r\n";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(16, 100);
            label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 20);
            label1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(28, 492);
            label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(70, 20);
            label2.TabIndex = 5;
            label2.Text = "Message:";
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(67, 84);
            textBox2.Margin = new System.Windows.Forms.Padding(1);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(115, 27);
            textBox2.TabIndex = 6;
            textBox2.Text = "127.0.0.1";
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(239, 86);
            textBox3.Margin = new System.Windows.Forms.Padding(1);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(115, 27);
            textBox3.TabIndex = 7;
            textBox3.Text = "8090";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(195, 86);
            label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 20);
            label3.TabIndex = 8;
            label3.Text = "Port:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(24, 87);
            label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(43, 20);
            label4.TabIndex = 9;
            label4.Text = "Host:\r\n";
            // 
            // connect_btn
            // 
            connect_btn.Location = new System.Drawing.Point(369, 84);
            connect_btn.Margin = new System.Windows.Forms.Padding(1);
            connect_btn.Name = "connect_btn";
            connect_btn.Size = new System.Drawing.Size(68, 26);
            connect_btn.TabIndex = 10;
            connect_btn.Text = "Connect\r\n\r\n";
            connect_btn.UseVisualStyleBackColor = true;
            connect_btn.Click += button3_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(28, 146);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(611, 322);
            textBox4.TabIndex = 11;
            textBox4.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(701, 690);
            Controls.Add(textBox4);
            Controls.Add(connect_btn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(client);
            Margin = new System.Windows.Forms.Padding(1);
            Name = "Form1";
            Text = "te";
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.RichTextBox textBox4;
    }
}

