namespace DynamicDrive
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
            car_tb = new TextBox();
            label1 = new Label();
            carSpd_tb = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox3 = new TextBox();
            engRPM_tb = new TextBox();
            label6 = new Label();
            nowPlayingTB = new TextBox();
            label7 = new Label();
            allNamesTb = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // car_tb
            // 
            car_tb.Location = new Point(12, 309);
            car_tb.Multiline = true;
            car_tb.Name = "car_tb";
            car_tb.Size = new Size(754, 129);
            car_tb.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 291);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 1;
            label1.Text = "Realtime Car Values";
            // 
            // carSpd_tb
            // 
            carSpd_tb.Location = new Point(492, 195);
            carSpd_tb.Name = "carSpd_tb";
            carSpd_tb.Size = new Size(100, 23);
            carSpd_tb.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(648, 195);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(492, 177);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Car Speed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(649, 178);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 5;
            label3.Text = "Raw Car Speed Data";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(649, 248);
            label4.Name = "label4";
            label4.Size = new Size(123, 15);
            label4.TabIndex = 9;
            label4.Text = "Raw Engine RPM Data";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(492, 247);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 8;
            label5.Text = "Engine RPM";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(648, 265);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 7;
            // 
            // engRPM_tb
            // 
            engRPM_tb.Location = new Point(492, 265);
            engRPM_tb.Name = "engRPM_tb";
            engRPM_tb.Size = new Size(100, 23);
            engRPM_tb.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 41);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 11;
            label6.Text = "Now Playing";
            // 
            // nowPlayingTB
            // 
            nowPlayingTB.Location = new Point(22, 59);
            nowPlayingTB.Multiline = true;
            nowPlayingTB.Name = "nowPlayingTB";
            nowPlayingTB.Size = new Size(142, 159);
            nowPlayingTB.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(204, 41);
            label7.Name = "label7";
            label7.Size = new Size(91, 15);
            label7.TabIndex = 13;
            label7.Text = "All Music Tracks";
            // 
            // allNamesTb
            // 
            allNamesTb.Location = new Point(204, 59);
            allNamesTb.Multiline = true;
            allNamesTb.Name = "allNamesTb";
            allNamesTb.Size = new Size(142, 159);
            allNamesTb.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(564, 57);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 14;
            button1.Text = "Add to Playlist";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(564, 99);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 15;
            button2.Text = "Remove";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(allNamesTb);
            Controls.Add(label6);
            Controls.Add(nowPlayingTB);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(engRPM_tb);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(carSpd_tb);
            Controls.Add(label1);
            Controls.Add(car_tb);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox car_tb;
        private Label label1;
        private TextBox carSpd_tb;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox3;
        private TextBox engRPM_tb;
        private Label label6;
        private TextBox nowPlayingTB;
        private Label label7;
        private TextBox allNamesTb;
        private Button button1;
        private Button button2;
    }
}
