using System.Diagnostics;

namespace CourseWork
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
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            button2 = new Button();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 19;
            listBox1.Location = new Point(149, 57);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(264, 270);
            listBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(171, 358);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(209, 26);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(171, 422);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(209, 26);
            textBox2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(699, 103);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(233, 26);
            dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(699, 167);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(233, 26);
            dateTimePicker2.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(697, 452);
            button2.Name = "button2";
            button2.Size = new Size(232, 66);
            button2.TabIndex = 6;
            button2.Text = "calculate";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(689, 316);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(240, 26);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(700, 246);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(233, 26);
            textBox4.TabIndex = 8;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(718, 405);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(81, 23);
            radioButton1.TabIndex = 9;
            radioButton1.TabStop = true;
            radioButton1.Text = "Хвороба";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(837, 405);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(72, 23);
            radioButton2.TabIndex = 10;
            radioButton2.TabStop = true;
            radioButton2.Text = "Декрет";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(697, 166);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(234, 27);
            comboBox1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(577, 253);
            label1.Name = "label1";
            label1.Size = new Size(96, 19);
            label1.TabIndex = 12;
            label1.Text = "Кількість днів:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(656, 109);
            label2.Name = "label2";
            label2.Size = new Size(17, 19);
            label2.TabIndex = 13;
            label2.Text = "З";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(656, 173);
            label3.Name = "label3";
            label3.Size = new Size(27, 19);
            label3.TabIndex = 14;
            label3.Text = "До";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(505, 319);
            label4.Name = "label4";
            label4.Size = new Size(178, 19);
            label4.TabIndex = 15;
            label4.Text = "Загальна сума нарахувань:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(945, 319);
            label5.Name = "label5";
            label5.Size = new Size(33, 19);
            label5.TabIndex = 16;
            label5.Text = "грн.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(89, 361);
            label6.Name = "label6";
            label6.Size = new Size(55, 19);
            label6.TabIndex = 17;
            label6.Text = "Посада";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(51, 429);
            label7.Name = "label7";
            label7.Size = new Size(104, 19);
            label7.TabIndex = 18;
            label7.Text = "Місячка ставка";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(617, 173);
            label8.Name = "label8";
            label8.Size = new Size(66, 19);
            label8.TabIndex = 19;
            label8.Text = "Кількість:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(215, 26);
            label9.Name = "label9";
            label9.Size = new Size(133, 19);
            label9.TabIndex = 20;
            label9.Text = "Список працівників";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(776, 26);
            label10.Name = "label10";
            label10.Size = new Size(82, 19);
            label10.TabIndex = 21;
            label10.Text = "Розрахунок";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(386, 425);
            label11.Name = "label11";
            label11.Size = new Size(33, 19);
            label11.TabIndex = 22;
            label11.Text = "грн.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 569);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(button2);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private ListBox listBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Button button2;
        private TextBox textBox3;
        private TextBox textBox4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
    }
}