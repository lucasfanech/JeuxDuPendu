using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuxDuPendu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void soloMode_Click(object sender, EventArgs e)
        {
            // show GameForm
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void localMode_Click(object sender, EventArgs e)
        {
            // show GameForm
            GameForm gameFormLocal = new GameForm(1);
            gameFormLocal.Show();
        }

        private void multiMode_Click(object sender, EventArgs e)
        {
            serverForm serverForm = new serverForm();
            serverForm.Show();
        }
    }
}
