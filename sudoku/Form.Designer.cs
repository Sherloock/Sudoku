namespace sudoku
{
    partial class Form
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
            this.Split1 = new System.Windows.Forms.SplitContainer();
            this.Split2 = new System.Windows.Forms.SplitContainer();
            this.Game = new System.Windows.Forms.Panel();
            this.Log = new System.Windows.Forms.Panel();
            this.logBox = new System.Windows.Forms.TextBox();
            this.Algos = new System.Windows.Forms.Panel();
            this.SolveBtn = new System.Windows.Forms.Button();
            this.TakeStepBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Split1)).BeginInit();
            this.Split1.Panel1.SuspendLayout();
            this.Split1.Panel2.SuspendLayout();
            this.Split1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split2)).BeginInit();
            this.Split2.Panel1.SuspendLayout();
            this.Split2.Panel2.SuspendLayout();
            this.Split2.SuspendLayout();
            this.Log.SuspendLayout();
            this.Algos.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Split1
            // 
            this.Split1.IsSplitterFixed = true;
            this.Split1.Location = new System.Drawing.Point(0, 27);
            this.Split1.Name = "Split1";
            // 
            // Split1.Panel1
            // 
            this.Split1.Panel1.Controls.Add(this.Split2);
            // 
            // Split1.Panel2
            // 
            this.Split1.Panel2.Controls.Add(this.Algos);
            this.Split1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Algos_Panel_Paint);
            this.Split1.Size = new System.Drawing.Size(734, 652);
            this.Split1.SplitterDistance = 550;
            this.Split1.TabIndex = 1;
            // 
            // Split2
            // 
            this.Split2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split2.IsSplitterFixed = true;
            this.Split2.Location = new System.Drawing.Point(0, 0);
            this.Split2.Margin = new System.Windows.Forms.Padding(0);
            this.Split2.Name = "Split2";
            this.Split2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Split2.Panel1
            // 
            this.Split2.Panel1.Controls.Add(this.Game);
            this.Split2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Panel_Paint);
            // 
            // Split2.Panel2
            // 
            this.Split2.Panel2.Controls.Add(this.Log);
            this.Split2.Size = new System.Drawing.Size(550, 652);
            this.Split2.SplitterDistance = 543;
            this.Split2.TabIndex = 0;
            // 
            // Game
            // 
            this.Game.AutoSize = true;
            this.Game.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Game.Location = new System.Drawing.Point(0, 0);
            this.Game.Name = "Game";
            this.Game.Size = new System.Drawing.Size(550, 543);
            this.Game.TabIndex = 0;
            // 
            // Log
            // 
            this.Log.Controls.Add(this.logBox);
            this.Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log.Location = new System.Drawing.Point(0, 0);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(550, 105);
            this.Log.TabIndex = 0;
            this.Log.Paint += new System.Windows.Forms.PaintEventHandler(this.Log_Paint);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(5, 0);
            this.logBox.Margin = new System.Windows.Forms.Padding(5, 3, 3, 5);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(539, 103);
            this.logBox.TabIndex = 0;
            // 
            // Algos
            // 
            this.Algos.Controls.Add(this.SolveBtn);
            this.Algos.Controls.Add(this.TakeStepBtn);
            this.Algos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Algos.Location = new System.Drawing.Point(0, 0);
            this.Algos.Name = "Algos";
            this.Algos.Size = new System.Drawing.Size(180, 652);
            this.Algos.TabIndex = 0;
            // 
            // SolveBtn
            // 
            this.SolveBtn.Location = new System.Drawing.Point(94, 8);
            this.SolveBtn.Name = "SolveBtn";
            this.SolveBtn.Size = new System.Drawing.Size(75, 23);
            this.SolveBtn.TabIndex = 2;
            this.SolveBtn.Text = "Solve";
            this.SolveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.SolveBtn.UseVisualStyleBackColor = true;
            this.SolveBtn.Click += new System.EventHandler(this.SolveBtn_Clicked);
            // 
            // TakeStepBtn
            // 
            this.TakeStepBtn.Location = new System.Drawing.Point(13, 8);
            this.TakeStepBtn.Name = "TakeStepBtn";
            this.TakeStepBtn.Size = new System.Drawing.Size(75, 23);
            this.TakeStepBtn.TabIndex = 1;
            this.TakeStepBtn.Text = "Take Step";
            this.TakeStepBtn.UseVisualStyleBackColor = true;
            this.TakeStepBtn.Click += new System.EventHandler(this.TakeStepBtn_Clicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 681);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Split1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Sudoku";
            this.Text = "Killer Sodoku";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Split1.Panel1.ResumeLayout(false);
            this.Split1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split1)).EndInit();
            this.Split1.ResumeLayout(false);
            this.Split2.Panel1.ResumeLayout(false);
            this.Split2.Panel1.PerformLayout();
            this.Split2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split2)).EndInit();
            this.Split2.ResumeLayout(false);
            this.Log.ResumeLayout(false);
            this.Log.PerformLayout();
            this.Algos.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer Split1;
        private System.Windows.Forms.SplitContainer Split2;
        private System.Windows.Forms.Panel Game;
        private System.Windows.Forms.Panel Log;
        private System.Windows.Forms.Panel Algos;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button SolveBtn;
        private System.Windows.Forms.Button TakeStepBtn;
    }
}

