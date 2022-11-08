using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JeuxDuPendu.MyControls;

namespace JeuxDuPendu
{
    public partial class GameForm : Form
    {

        // Initialisation de l'instance de la classe d'affichage du pendu.
        HangmanViewer _HangmanViewer = new HangmanViewer();
        String word = "";
        /// <summary>
        /// Constructeur du formulaire de jeux
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
            InitializeMyComponent();
            StartNewGame();
        }

        /// <summary>
        /// Initialisations des composant specifique a l'application
        /// </summary>
        private void InitializeMyComponent()
        {
            // On positionne le controle d'affichage du pendu dans panel1 : 
            panel1.Controls.Add(_HangmanViewer);
			
			// à la position 0,0
            _HangmanViewer.Location = new Point(0, 0);
			
			// et de la même taille que panel1
            _HangmanViewer.Size = panel1.Size;
        }

        /// <summary>
        /// Initialise une nouvelle partie
        /// </summary>
        public void StartNewGame()
        {
            // Methode de reinitialisation classe d'affichage du pendu.
            _HangmanViewer.Reset();
            // appel de la classe RandomWord
            RandomWord randomWord = new RandomWord();
            
            // On recupere un mot aleatoire
            this.word = randomWord.GetRandomWord();
            // On recupere la première lettre
            char firstLetter = word[0];
            // compte le nombre de lettre
            int letterCount = word.Length;
            // lCrypedWord.Text = firstLetter
            lCrypedWord.Text = new string(firstLetter, 1);
            for (int i = 0; i < letterCount-1; i++)
            {
                // On affiche le mot crypté
                lCrypedWord.Text += "-";
            }
            
        }


        /// <summary>
        /// Methode appelé lors de l'appui d'un touche du clavier, lorsque le focus est sur le bouton "Nouvelle partie"
        /// </summary>
        private void bReset_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressed(e.KeyChar);
        }

        /// <summary>
        /// Methode appelé lors de l'appui d'un touche du clavier, lorsque le focus est sur le forulaire
        /// </summary>
        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressed(e.KeyChar);
        }

        /// <summary>
        /// Methode appelé lors de l'appui sur le bouton "Nouvelle partie"
        /// </summary>
        private void bReset_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void KeyPressed(char letter)
        {
            // On verifie si la lettre est présente dans le mot
            if (word.Contains(letter))
            {
                // on regarde combien de fois la lettre est présente dans le mot
                int letterCount = word.Count(c => c == letter);
                int letterPosition;
                // on parcours le mot
                for (int i = 0; i < letterCount; i++)
                {
                    // on recupere la position de la lettre
                    letterPosition = word.IndexOf(letter);
                    // on remplace le tiret par la lettre
                    lCrypedWord.Text = lCrypedWord.Text.Remove(letterPosition, 1).Insert(letterPosition, letter.ToString());
                    // on remplace la lettre par un tiret
                    word = word.Remove(letterPosition, 1).Insert(letterPosition, "-");
                }
            }
            else
            {
                // On avance le pendu d'une etape
                _HangmanViewer.MoveNextStep();

                // Si le pendu est complet, le joueur à perdu.
                if (_HangmanViewer.IsGameOver)
                {
                    MessageBox.Show("Vous avez perdu !");
                    StartNewGame();
                }
            }
            
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }

}
