namespace PacMan
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.Hero = new System.Windows.Forms.PictureBox();
            this.Food = new System.Windows.Forms.PictureBox();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.TimerMain = new System.Windows.Forms.Timer(this.components);
            this.TimerPacman = new System.Windows.Forms.Timer(this.components);
            this.TimerAnimateGhost = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Hero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Food)).BeginInit();
            this.SuspendLayout();
            // 
            // Hero
            // 
            this.Hero.BackColor = System.Drawing.Color.Yellow;
            this.Hero.Location = new System.Drawing.Point(375, 315);
            this.Hero.Margin = new System.Windows.Forms.Padding(4);
            this.Hero.Name = "Hero";
            this.Hero.Size = new System.Drawing.Size(107, 98);
            this.Hero.TabIndex = 0;
            this.Hero.TabStop = false;
            // 
            // Food
            // 
            this.Food.BackColor = System.Drawing.Color.Lime;
            this.Food.Location = new System.Drawing.Point(664, 223);
            this.Food.Margin = new System.Windows.Forms.Padding(4);
            this.Food.Name = "Food";
            this.Food.Size = new System.Drawing.Size(60, 58);
            this.Food.TabIndex = 1;
            this.Food.TabStop = false;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ScoreLabel.Location = new System.Drawing.Point(16, 28);
            this.ScoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(178, 46);
            this.ScoreLabel.TabIndex = 2;
            this.ScoreLabel.Text = "Score: 0";
            // 
            // TimerMain
            // 
            this.TimerMain.Tick += new System.EventHandler(this.TimerMain_Tick);
            // 
            // TimerPacman
            // 
            this.TimerPacman.Tick += new System.EventHandler(this.TimerPacman_Tick);
            // 
            // TimerAnimateGhost
            // 
            this.TimerAnimateGhost.Tick += new System.EventHandler(this.TimerAnimateGhost_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 764);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.Food);
            this.Controls.Add(this.Hero);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Game";
            this.Text = "Form1";
            
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Hero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Food)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Hero;
        private System.Windows.Forms.PictureBox Food;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Timer TimerMain;
        private System.Windows.Forms.Timer TimerPacman;
        private System.Windows.Forms.Timer TimerAnimateGhost;
    }
}

