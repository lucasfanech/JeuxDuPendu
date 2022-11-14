namespace JeuxDuPendu
{
    partial class Menu
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
            this.titleGame = new System.Windows.Forms.Label();
            this.soloMode = new System.Windows.Forms.Button();
            this.localMode = new System.Windows.Forms.Button();
            this.multiMode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleGame
            // 
            this.titleGame.AutoSize = true;
            this.titleGame.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleGame.Location = new System.Drawing.Point(295, 36);
            this.titleGame.Name = "titleGame";
            this.titleGame.Size = new System.Drawing.Size(219, 64);
            this.titleGame.TabIndex = 0;
            this.titleGame.Text = "Jeu du Pendu\r\nToruk Edition";
            // 
            // soloMode
            // 
            this.soloMode.Location = new System.Drawing.Point(322, 308);
            this.soloMode.Name = "soloMode";
            this.soloMode.Size = new System.Drawing.Size(159, 33);
            this.soloMode.TabIndex = 1;
            this.soloMode.Text = "Toruk solo";
            this.soloMode.UseVisualStyleBackColor = true;
            this.soloMode.Click += new System.EventHandler(this.soloMode_Click);
            // 
            // localMode
            // 
            this.localMode.Location = new System.Drawing.Point(322, 347);
            this.localMode.Name = "localMode";
            this.localMode.Size = new System.Drawing.Size(159, 35);
            this.localMode.TabIndex = 2;
            this.localMode.Text = "Mode Multijoueur local";
            this.localMode.UseVisualStyleBackColor = true;
            // 
            // multiMode
            // 
            this.multiMode.Location = new System.Drawing.Point(322, 388);
            this.multiMode.Name = "multiMode";
            this.multiMode.Size = new System.Drawing.Size(159, 35);
            this.multiMode.TabIndex = 3;
            this.multiMode.Text = "Mode Multijoueur Online";
            this.multiMode.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.multiMode);
            this.Controls.Add(this.localMode);
            this.Controls.Add(this.soloMode);
            this.Controls.Add(this.titleGame);
            this.Name = "Menu";
            this.Text = "Jeu du Pendu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleGame;
        private System.Windows.Forms.Button soloMode;
        private System.Windows.Forms.Button localMode;
        private System.Windows.Forms.Button multiMode;
    }
}