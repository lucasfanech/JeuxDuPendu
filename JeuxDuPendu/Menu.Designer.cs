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
            this.titleGame.Location = new System.Drawing.Point(221, 29);
            this.titleGame.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleGame.Name = "titleGame";
            this.titleGame.Size = new System.Drawing.Size(172, 50);
            this.titleGame.TabIndex = 0;
            this.titleGame.Text = "Jeu du Pendu\r\nToruk Edition";
            // 
            // soloMode
            // 
            this.soloMode.Location = new System.Drawing.Point(211, 251);
            this.soloMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.soloMode.Name = "soloMode";
            this.soloMode.Size = new System.Drawing.Size(182, 27);
            this.soloMode.TabIndex = 1;
            this.soloMode.Text = "Toruk solo";
            this.soloMode.UseVisualStyleBackColor = true;
            this.soloMode.Click += new System.EventHandler(this.soloMode_Click);
            // 
            // localMode
            // 
            this.localMode.Location = new System.Drawing.Point(211, 283);
            this.localMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.localMode.Name = "localMode";
            this.localMode.Size = new System.Drawing.Size(182, 28);
            this.localMode.TabIndex = 2;
            this.localMode.Text = "Mode Multijoueur local";
            this.localMode.UseVisualStyleBackColor = true;
            this.localMode.Click += new System.EventHandler(this.localMode_Click);
            // 
            // multiMode
            // 
            this.multiMode.Location = new System.Drawing.Point(211, 315);
            this.multiMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.multiMode.Name = "multiMode";
            this.multiMode.Size = new System.Drawing.Size(182, 28);
            this.multiMode.TabIndex = 3;
            this.multiMode.Text = "Mode Multijoueur Online";
            this.multiMode.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.multiMode);
            this.Controls.Add(this.localMode);
            this.Controls.Add(this.soloMode);
            this.Controls.Add(this.titleGame);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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