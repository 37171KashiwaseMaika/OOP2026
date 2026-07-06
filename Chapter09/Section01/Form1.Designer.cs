namespace Section01 {
    partial class btGet {
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
            button1 = new Button();
            tbOut = new TextBox();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(26, 24);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(221, 39);
            dtpDate.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(287, 23);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 1;
            button1.Text = "取得";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tbOut
            // 
            tbOut.Location = new Point(26, 81);
            tbOut.Name = "tbOut";
            tbOut.Size = new Size(140, 23);
            tbOut.TabIndex = 2;
            // 
            // btGet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 634);
            Controls.Add(tbOut);
            Controls.Add(button1);
            Controls.Add(dtpDate);
            Name = "btGet";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDate;
        private Button button1;
        private TextBox tbOut;
    }
}
