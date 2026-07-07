namespace Section01 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            dtpDate = new DateTimePicker();
            btGet = new Button();
            tbOut = new TextBox();
            nudDay = new NumericUpDown();
            label1 = new Label();
            dtpBirth = new DateTimePicker();
            btBirthCalc = new Button();
            label2 = new Label();
            tbOut2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(31, 22);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(217, 39);
            dtpDate.TabIndex = 0;
            // 
            // btGet
            // 
            btGet.Location = new Point(293, 22);
            btGet.Name = "btGet";
            btGet.Size = new Size(116, 38);
            btGet.TabIndex = 1;
            btGet.Text = "計算";
            btGet.UseVisualStyleBackColor = true;
            btGet.Click += btGet_Click;
            // 
            // tbOut
            // 
            tbOut.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbOut.Location = new Point(104, 247);
            tbOut.Name = "tbOut";
            tbOut.Size = new Size(305, 39);
            tbOut.TabIndex = 2;
            tbOut.TextChanged += tbOut_TextChanged;
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudDay.Location = new Point(128, 94);
            nudDay.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(120, 39);
            nudDay.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(254, 96);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 4;
            label1.Text = "日後";
            // 
            // dtpBirth
            // 
            dtpBirth.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpBirth.Location = new Point(31, 174);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(217, 39);
            dtpBirth.TabIndex = 0;
            // 
            // btBirthCalc
            // 
            btBirthCalc.Location = new Point(293, 174);
            btBirthCalc.Name = "btBirthCalc";
            btBirthCalc.Size = new Size(116, 38);
            btBirthCalc.TabIndex = 1;
            btBirthCalc.Text = "計算";
            btBirthCalc.UseVisualStyleBackColor = true;
            btBirthCalc.Click += btGet_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 151);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 5;
            label2.Text = "生年月日";
            // 
            // tbOut2
            // 
            tbOut2.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbOut2.Location = new Point(104, 292);
            tbOut2.Name = "tbOut2";
            tbOut2.Size = new Size(305, 39);
            tbOut2.TabIndex = 2;
            tbOut2.TextChanged += tbOut_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 264);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 6;
            label3.Text = "年齢";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 309);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 7;
            label4.Text = "経過日数";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 596);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nudDay);
            Controls.Add(tbOut2);
            Controls.Add(tbOut);
            Controls.Add(btBirthCalc);
            Controls.Add(btGet);
            Controls.Add(dtpBirth);
            Controls.Add(dtpDate);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDate;
        private Button btGet;
        private TextBox tbOut;
        private NumericUpDown nudDay;
        private Label label1;
        private DateTimePicker dtpBirth;
        private Button btBirthCalc;
        private Label label2;
        private TextBox tbOut2;
        private Label label3;
        private Label label4;
    }
}
