using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxDuPendu
{
    
    internal class randomWords
    {
        private string[] words;
        private string[] allWords;
        private List<string> lettersUsed = new List<string>();
        private Random random = new Random();

        public randomWords()
        {
            // get Ressources path
            string workingDirectory = Environment.CurrentDirectory;
            string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @"JeuxDuPendu\Resources\Pendu.txt");
            // read all lines from path
            allWords = File.ReadAllLines(path);
            // parse words[0] 
            words = allWords[0].Split(' ');
        }
        public string GetRandomWord()
        {
            return words[random.Next(words.Length)];
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
