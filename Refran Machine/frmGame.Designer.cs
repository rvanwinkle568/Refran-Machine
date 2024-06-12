namespace Refran_Machine
{
    partial class frmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuAnswers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRefran = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnStartOver = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAnswers,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(458, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuAnswers
            // 
            this.mnuAnswers.Name = "mnuAnswers";
            this.mnuAnswers.Size = new System.Drawing.Size(63, 20);
            this.mnuAnswers.Text = "Answers";
            this.mnuAnswers.Click += new System.EventHandler(this.mnuAnswers_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // lblRefran
            // 
            this.lblRefran.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRefran.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblRefran.Location = new System.Drawing.Point(62, 49);
            this.lblRefran.Name = "lblRefran";
            this.lblRefran.Size = new System.Drawing.Size(289, 45);
            this.lblRefran.TabIndex = 1;
            this.lblRefran.Text = "There are no more Refranes. You are a sociopath";
            this.lblRefran.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(108, 109);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(212, 20);
            this.txtAnswer.TabIndex = 2;
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(349, 109);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(75, 23);
            this.btnAnswer.TabIndex = 3;
            this.btnAnswer.Text = "Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(349, 138);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnStartOver
            // 
            this.btnStartOver.Location = new System.Drawing.Point(173, 152);
            this.btnStartOver.Name = "btnStartOver";
            this.btnStartOver.Size = new System.Drawing.Size(75, 23);
            this.btnStartOver.TabIndex = 5;
            this.btnStartOver.Text = "Start Over";
            this.btnStartOver.UseVisualStyleBackColor = true;
            this.btnStartOver.Click += new System.EventHandler(this.btnStartOver_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(173, 181);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 242);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartOver);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblRefran);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmGame";
            this.Text = "Refran Machine";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAnswers;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.Label lblRefran;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnStartOver;
        private System.Windows.Forms.Button btnClose;
    }
}

