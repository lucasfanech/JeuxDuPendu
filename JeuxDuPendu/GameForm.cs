using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using JeuxDuPendu.MyControls;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace JeuxDuPendu
{
    public partial class GameForm : Form
    {

        // Initialisation de l'instance de la classe d'affichage du pendu.
        HangmanViewer _HangmanViewer = new HangmanViewer();
        String word = "";
        // appel de la classe RandomWord
        randomWords randomWord = new randomWords();
        int mode = 0;
        int nbPlayers = 1;
        int[] score;
        int currentPlayer = 1;
        int attempts = 0;
        int idPlayer = 0;
        private Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        /// <summary>
        /// Constructeur du formulaire de jeux
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
            InitializeMyComponent();
            StartNewGame();
        }

        public GameForm(int modeInterne)
        {   
            // Mode Multijoueur Local
            if (modeInterne == 1)
            {
                this.mode = 1;
                InitializeComponent();
                InitializeMyComponent();
                StartNewGame();
                nbPlayers = HowManyPlayers();
                // Initalialise début de game
                if (nbPlayers > 0 && nbPlayers < 7)
                {
                    // score for each player
                    score = new int[nbPlayers];
                    // set 0 to each player
                    for (int i = 0; i < nbPlayers; i++)
                    {
                        score[i] = 0;
                    }
                    currentPlayer = 1;
                    this.player.Text = "J"+ currentPlayer.ToString();
                    this.points.Text = score[0].ToString()+" pts";

                    
                }
            }
            else if (modeInterne == 2)
            {
                // Mode Multijoueur en réseau
                this.mode = 2;
                InitializeComponent();
                InitializeMyComponent();
                StartNewGame();
                
                


            }


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
        public void StartNewGame(string selectedWord = null, string player = null)
        {
            if (player != null)
            {
                this.player.Text = "J"+player+"(Online)";
                idPlayer = int.Parse(player);
            }
            else
            {
                this.player.Text = "";
            }
            attempts = 0;
            usedLetters.Text = "";
            randomWord.ClearLettersUsed();
            // Methode de reinitialisation classe d'affichage du pendu.
            _HangmanViewer.Reset();

            // Si aucun mot est défini par le serveur, On recupere un mot aleatoire par défaut ou importé
            if (selectedWord == null) {
                if (defaultWords.Checked)
                {
                    this.word = randomWord.GetRandomWord(0);
                }
                else
                {
                    this.word = randomWord.GetRandomWord(1);
                }
            }
            else
            {
                this.word = selectedWord;
            }
            // TO DO : Difficulté
            // On recupere la première lettre
            char firstLetter = word[0];
            

            // compte le nombre de lettre
            int letterCount = word.Length;
            // lCrypedWord.Text = firstLetter

            // if thread so invoke
            lCrypedWord.Text = new string(firstLetter, 1);
            for (int i = 0; i < letterCount-1; i++)
            {
                // On affiche le mot crypté
                lCrypedWord.Text += "-";
            }
            

            // TO DO : Difficulté
            // Vérifier si la première lettre existe à un autre emplacement

            // on regarde combien de fois la lettre est présente dans le mot
            letterCount = word.Count(c => c == firstLetter);
            int letterPosition;
            // on parcours le mot
            for (int i = 0; i < letterCount; i++)
            {
                // on recupere la position de la lettre
                letterPosition = word.IndexOf(firstLetter);
                // on remplace le tiret par la lettre
                lCrypedWord.Text = lCrypedWord.Text.Remove(letterPosition, 1).Insert(letterPosition, firstLetter.ToString());
                // on remplace la lettre par un tiret
                word = word.Remove(letterPosition, 1).Insert(letterPosition, "-");
            }
            randomWord.AddLetterUsed(firstLetter.ToString());

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
            bool isWin = false;
            // On vérifie que la touche appuyé est une lettre entre a et z
            if (letter >= 'a' && letter <= 'z')
            {
                // On vérifie si la lettre est présente dans la liste des lettres déjà utilisées
                if (randomWord.GetLettersUsed().Contains(letter.ToString()))
                {
                    // Si oui, on affiche un message d'erreur
                    MessageBox.Show("Vous avez déjà utilisé cette lettre", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    attempts++;
                    // Sinon, on ajoute la lettre à la liste des lettres déjà utilisées
                    randomWord.AddLetterUsed(letter.ToString());
                    // Afficher la liste des lettres déjà utilisées
                    usedLetters.Text = "Lettres utilisées: " + randomWord.GetLettersUsed().Aggregate((i, j) => i + ", " + j);


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
                        // on verifie si le mot est trouvé
                        if (lCrypedWord.Text == lCrypedWord.Text.Replace("-", ""))
                        {
                            // on affiche un message de victoire
                            MessageBox.Show("Vous avez gagné en "+ attempts+" essais!");
                            // On envoie au serveur qu'on a gagné 
                            if (mode == 2)
                            {
                                send("/win " + idPlayer + " " + attempts);
                            }
                            // on relance une nouvelle partie
                            StartNewGame();

                            
                        }

                        // Ajout des points
                        if (mode == 1)
                        {
                            // si letter est une voyelle + 1 point à score[currentPlayer - 1]
                            if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u' || letter == 'y')
                            {
                                score[currentPlayer - 1] += 1;
                                sortie.Text += currentPlayer + " a gagné " + 1 + " points en trouvant la lettre " + letter + "\n";
                            }
                            // si letter est une consonne + 2 points à score[currentPlayer - 1]
                            else
                            {
                                score[currentPlayer - 1] += 2;
                                sortie.Text += currentPlayer + " a gagné " + 2 + " points en trouvant la lettre " + letter + "\n";
                            }

                            isWin = true;
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
                            // On envoie au serveur qu'on a perdu
                            if (mode == 2)
                            {
                                send("/loose " + idPlayer);
                            }
                            StartNewGame();
                        }
                    }

                    if (mode == 1)
                    {
                        if (!isWin)
                        {
                            // Joueur suivant
                            if (currentPlayer < nbPlayers)
                            { currentPlayer++; }
                            else { currentPlayer = 1; }
                        }
                        
                        this.player.Text = "J" + currentPlayer.ToString();
                        this.points.Text = score[currentPlayer - 1].ToString();
                        // Recap du score
                        for (int i = 0; i < nbPlayers; i++)
                        {
                            sortie.Text += "J" + (i + 1) + " : " + score[i] + " pts | ";

                        }
                        sortie.Text += "\n";

                    }



                }
            }
            
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void importedWords_CheckedChanged(object sender, EventArgs e)
        {
            if (importedWords.Checked)
            {
                defaultWords.Checked = false;
            }
            else
            {
                defaultWords.Checked = true;
            }
        }

        private void defaultWords_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultWords.Checked){
                importedWords.Checked = false;
            }
            else {
                importedWords.Checked = true;
            }
        }



        // Multiplayer
        // HowManyPlayer

        private int HowManyPlayers()
        {
            {
                

                // On demande au joueur combien de joueurs vont jouer
                int nbPlayers = 0;

                // InputBox
                // On demande au joueur combien de joueurs vont jouer
                nbPlayers = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Combien de joueurs vont jouer ?", "Nombre de joueurs", "1", -1, -1));
                

                // On vérifie que le nombre de joueurs est compris entre 2 et 6
                if (nbPlayers < 2 || nbPlayers > 6)
                {
                    // Si ce n'est pas le cas, on affiche un message d'erreur
                    MessageBox.Show("Le nombre de joueurs doit être compris entre 1 et 4", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // On relance la méthode
                    HowManyPlayers();
                }
                else
                {
                    MessageBox.Show("Lancement de la partie avec " + nbPlayers + " joueurs");
                   
                }
                return nbPlayers;
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void setSocket(Socket s)
        {
            ClientSocket = s;
           
        }
        private void send(string texte) {

            byte[] buffer = Encoding.ASCII.GetBytes(texte);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);

        }

        // On Form close

        private void GameForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (mode == 2)
            {
                // On envoie un message au serveur pour lui dire que le client se déconnecte
                send("exit");
                // On ferme la connexion
                ClientSocket.Shutdown(SocketShutdown.Both);
                ClientSocket.Close();
                Environment.Exit(0);
            }
            
        }
    }
}
