using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashupgaming
{
    internal class Utils
    {
        public static char RecupererSaisie(string prompt, params char[] caracteresAutorises)
        {
            Console.WriteLine(prompt);
            while (true)
            {
                char input = Console.ReadKey(true).KeyChar;
                if (caracteresAutorises.Contains(input))
                {
                    return input;
                }
            }
        }
        //public void ChoixDeFinDePartie()         //À COPIER+COLLER !!!!
        //{
        //                         Console.WriteLine("////////////////////////////////");
        //    char userInput = Utils.RecupererSaisie("[Q]uitter ? [B]ack ? [R]ejouer ?", 'q', 'b', 'r');
        //                         Console.WriteLine("////////////////////////////////");

        //    rejouer = userInput == 'r';                                            
        //    retour = userInput == 'b';
            
        //    if (userInput == 'q')                                                  
        //    {
        //        return;
        //    }

        //    Console.Clear();                                                       
        //}
        //public void MenuFin()                   //À COPIER+COLLER !!!!
        //{
            
        //                            Console.WriteLine("///////////////////////");
        //    char userInput = Utils.RecupererSaisie("[Q]uitter ? [R]ejouer ?", 'q', 'r');
        //                            Console.WriteLine("///////////////////////");
 
        //    rejouer = userInput == 'r';
        //    if (userInput == 'q')
        //    {
        //        return;
        //    }

        //    Console.Clear();
        
        //}
    }
}
