namespace JeuxDuPendu
{
    partial class serverForm
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
            this.Connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(322, 124);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(174, 23);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Se connecter";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // serverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Connect);
            this.Name = "serverForm";
            this.Text = "serverForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Connect;
    }
}