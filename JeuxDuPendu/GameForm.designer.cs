namespace JeuxDuPendu
{
    partial class GameForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bReset = new System.Windows.Forms.Button();
            this.lCrypedWord = new System.Windows.Forms.Label();
            this.usedLetters = new System.Windows.Forms.Label();
            this.defaultWords = new System.Windows.Forms.CheckBox();
            this.importedWords = new System.Windows.Forms.CheckBox();
            this.player = new System.Windows.Forms.Label();
            this.points = new System.Windows.Forms.Label();
            this.sortie = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(139, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 366);
            this.panel1.TabIndex = 0;
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(261, 495);
            this.bReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(120, 43);
            this.bReset.TabIndex = 1;
            this.bReset.Text = "Nouvelle partie";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            this.bReset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bReset_KeyPress);
            // 
            // lCrypedWord
            // 
            this.lCrypedWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCrypedWord.Location = new System.Drawing.Point(153, 398);
            this.lCrypedWord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lCrypedWord.Name = "lCrypedWord";
            this.lCrypedWord.Size = new System.Drawing.Size(340, 48);
            this.lCrypedWord.TabIndex = 2;
            this.lCrypedWord.Text = "--";
            this.lCrypedWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usedLetters
            // 
            this.usedLetters.AutoSize = true;
            this.usedLetters.Location = new System.Drawing.Point(244, 446);
            this.usedLetters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usedLetters.Name = "usedLetters";
            this.usedLetters.Size = new System.Drawing.Size(0, 16);
            this.usedLetters.TabIndex = 3;
            // 
            // defaultWords
            // 
            this.defaultWords.AutoSize = true;
            this.defaultWords.Location = new System.Drawing.Point(132, 479);
            this.defaultWords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.defaultWords.Name = "defaultWords";
            this.defaultWords.Size = new System.Drawing.Size(121, 20);
            this.defaultWords.TabIndex = 4;
            this.defaultWords.Text = "Mots par défaut";
            this.defaultWords.UseVisualStyleBackColor = true;
            this.defaultWords.CheckedChanged += new System.EventHandler(this.defaultWords_CheckedChanged);
            // 
            // importedWords
            // 
            this.importedWords.AutoSize = true;
            this.importedWords.Checked = true;
            this.importedWords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.importedWords.Location = new System.Drawing.Point(132, 507);
            this.importedWords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.importedWords.Name = "importedWords";
            this.importedWords.Size = new System.Drawing.Size(113, 20);
            this.importedWords.TabIndex = 5;
            this.importedWords.Text = "Mots importés";
            this.importedWords.UseVisualStyleBackColor = true;
            this.importedWords.CheckedChanged += new System.EventHandler(this.importedWords_CheckedChanged);
            // 
            // player
            // 
            this.player.AutoSize = true;
            this.player.Location = new System.Drawing.Point(17, 398);
            this.player.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(0, 16);
            this.player.TabIndex = 6;
            // 
            // points
            // 
            this.points.AutoSize = true;
            this.points.Location = new System.Drawing.Point(17, 468);
            this.points.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.points.Name = "points";
            this.points.Size = new System.Drawing.Size(0, 16);
            this.points.TabIndex = 7;
            // 
            // sortie
            // 
            this.sortie.Location = new System.Drawing.Point(132, 560);
            this.sortie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sortie.Name = "sortie";
            this.sortie.ReadOnly = true;
            this.sortie.Size = new System.Drawing.Size(389, 98);
            this.sortie.TabIndex = 8;
            this.sortie.Text = "";
            this.sortie.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 673);
            this.Controls.Add(this.sortie);
            this.Controls.Add(this.points);
            this.Controls.Add(this.player);
            this.Controls.Add(this.importedWords);
            this.Controls.Add(this.defaultWords);
            this.Controls.Add(this.usedLetters);
            this.Controls.Add(this.lCrypedWord);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GameForm";
            this.Text = "Jeux du pendu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing_1);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Label lCrypedWord;
        private System.Windows.Forms.Label usedLetters;
        private System.Windows.Forms.CheckBox defaultWords;
        private System.Windows.Forms.CheckBox importedWords;
        private System.Windows.Forms.Label player;
        private System.Windows.Forms.Label points;
        private System.Windows.Forms.RichTextBox sortie;
    }
}

