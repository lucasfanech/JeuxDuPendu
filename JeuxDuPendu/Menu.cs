﻿using System;
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
    }
}