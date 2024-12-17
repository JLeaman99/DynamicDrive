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
            speedChange_tb = new TextBox();
            button3 = new Button();
            btn_carInit = new Button();
            comboBox1 = new ComboBox();
            label8 = new Label();
            textBox1 = new TextBox();
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
            carSpd_tb.Location = new Point(489, 195);
            carSpd_tb.Name = "carSpd_tb";
            carSpd_tb.Size = new Size(100, 23);
            carSpd_tb.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(645, 195);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(489, 177);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Car Speed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(646, 178);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 5;
            label3.Text = "Raw Car Speed Data";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(646, 248);
            label4.Name = "label4";
            label4.Size = new Size(123, 15);
            label4.TabIndex = 9;
            label4.Text = "Raw Engine RPM Data";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(489, 247);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 8;
            label5.Text = "Engine RPM";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(645, 265);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 7;
            // 
            // engRPM_tb
            // 
            engRPM_tb.Location = new Point(489, 265);
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
            button1.Location = new Point(220, 240);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 14;
            button1.Text = "Add to Playlist";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(220, 269);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 15;
            button2.Text = "Remove";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // speedChange_tb
            // 
            speedChange_tb.Location = new Point(22, 244);
            speedChange_tb.Name = "speedChange_tb";
            speedChange_tb.Size = new Size(100, 23);
            speedChange_tb.TabIndex = 16;
            // 
            // button3
            // 
            button3.Location = new Point(128, 244);
            button3.Name = "button3";
            button3.Size = new Size(75, 44);
            button3.TabIndex = 17;
            button3.Text = "Change Speed";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // btn_carInit
            // 
            btn_carInit.Location = new Point(489, 109);
            btn_carInit.Name = "btn_carInit";
            btn_carInit.Size = new Size(84, 23);
            btn_carInit.TabIndex = 18;
            btn_carInit.Text = "Initalize Car";
            btn_carInit.UseVisualStyleBackColor = true;
            btn_carInit.Click += btn_carInit_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "COM5", "COM6", "COM7" });
            comboBox1.Location = new Point(489, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(84, 23);
            comboBox1.TabIndex = 19;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(489, 23);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 20;
            label8.Text = "COM Interface";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(589, 38);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(209, 94);
            textBox1.TabIndex = 21;
            textBox1.Text = "COM5 is the Top Right USB Port\r\n\r\nCOM6 is the Bottom Right USB Port\r\n\r\nCOM7 is the Left USB3.0 Port";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(label8);
            Controls.Add(comboBox1);
            Controls.Add(btn_carInit);
            Controls.Add(button3);
            Controls.Add(speedChange_tb);
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
        private TextBox speedChange_tb;
        private Button button3;
        private Button btn_carInit;
        private ComboBox comboBox1;
        private Label label8;
        private TextBox textBox1;
    }
}
