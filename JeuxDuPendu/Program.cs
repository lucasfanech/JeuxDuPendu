using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace JeuxDuPendu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm());
        }
    }


    //Random world from text file
   public class RandomWord
        {
            private string[] words;
            private Random random = new Random();
    
            public RandomWord()
            {
                words = System.IO.File.ReadAllLines(@.\Ressources\Pendu.txt");
            }
    
            public string GetRandomWord()
            {
                return words[random.Next(words.Length)];
            }
        }
    
    
        

}
