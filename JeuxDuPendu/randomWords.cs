using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuxDuPendu
{
    
    internal class randomWords
    {
        
        private string[] allLines;
        private string[] tempWords;
        private string[] words = new string[1];
        private string[] defaultWords;
        private List<string> lettersUsed = new List<string>();
        private Random random = new Random();

        public randomWords()
        {
            // Ajout de Mots par défaut dans le tableau defaultWords
            defaultWords = new string[10] { "pomme", "orange", "fraise", "banane", "poire", "ananas", "melon", "peche", "abricot", "kiwi" };
            // Convert defaultWords UpperCase to LowerCase
            for (int i = 0; i < defaultWords.Length; i++)
            {
                defaultWords[i] = defaultWords[i].ToLower();
                // convert accentuation
                defaultWords[i] = defaultWords[i].Replace("é", "e");
                defaultWords[i] = defaultWords[i].Replace("è", "e");
                defaultWords[i] = defaultWords[i].Replace("ê", "e");
                defaultWords[i] = defaultWords[i].Replace("à", "a");
                defaultWords[i] = defaultWords[i].Replace("â", "a");
                defaultWords[i] = defaultWords[i].Replace("î", "i");
                defaultWords[i] = defaultWords[i].Replace("ï", "i");
                defaultWords[i] = defaultWords[i].Replace("ô", "o");
                defaultWords[i] = defaultWords[i].Replace("ö", "o");
                defaultWords[i] = defaultWords[i].Replace("ù", "u");
                defaultWords[i] = defaultWords[i].Replace("û", "u");
                defaultWords[i] = defaultWords[i].Replace("ü", "u");
                defaultWords[i] = defaultWords[i].Replace("ç", "c");

            }
            

            // get Ressources path
            string workingDirectory = Environment.CurrentDirectory;
            string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @"JeuxDuPendu\Resources\Pendu.txt");
            // read all lines from path
            allLines = File.ReadAllLines(path);
            // for each line
            foreach (string line in allLines)
            {
                // split line by space
                tempWords = line.Split(' ');
                // for each word in tempWords check if word > 4 and < 11 and contains only letters from a-z
                foreach (string wordC in tempWords)
                {
                    if (wordC.Length > 4 && wordC.Length < 11 && wordC.All(char.IsLetter))
                    {
                        if (wordC != null)
                        {
                            if (words.Contains(wordC))
                            {
                                // do nothing
                            }
                            else
                            {
                                // convert wordC to lower case
                                string word = wordC.ToLower();
                                // convert accentuation
                                word = word.Replace("é", "e");
                                word = word.Replace("è", "e");
                                word = word.Replace("ê", "e");
                                word = word.Replace("à", "a");
                                word = word.Replace("â", "a");
                                word = word.Replace("î", "i");
                                word = word.Replace("ï", "i");
                                word = word.Replace("ô", "o");
                                word = word.Replace("ö", "o");
                                word = word.Replace("ù", "u");
                                word = word.Replace("û", "u");
                                word = word.Replace("ü", "u");
                                word = word.Replace("ç", "c");
                                
                                // add word to words
                                words = words.Concat(new string[] { word }).ToArray();
                            }
                        }
                        



                    }
                }
            }
        }
        public string GetRandomWord(int option)
        {
            if (option == 0)
            {
                return defaultWords[random.Next(0, defaultWords.Length)];
            }
            else
            {
                string getWord = null;
                while (getWord == null)
                {
                    getWord = words[random.Next(words.Length)];
                }
                    
                return getWord;
            }
            
        }

        // getter lettersUsed
        public List<string> GetLettersUsed()
        {
            return lettersUsed;
        }

        // add letter to lettersUsed
        public void AddLetterUsed(string letter)
        {
            lettersUsed.Add(letter);
        }

        // clear lettersUsed
        public void ClearLettersUsed()
        {
            lettersUsed.Clear();
        }

    }


}
