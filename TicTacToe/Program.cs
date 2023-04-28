using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;                //utilise ?
using System.Diagnostics.CodeAnalysis;
using System.Numerics;                            //autorise que les chiffre comme saisie
using System.Runtime.CompilerServices;

namespace Mashupgaming
{
    internal class Program
    {
        
        public static void Main()
        {
            int nbrMgc;
            int tcTCte;
            int userInput;
            bool quitGame = false;

            do
            {
                FrontPage();
            } while (! quitGame);

        }


        private static void FrontPage()
        {   

            Console.WriteLine("/////////////////////////");
            Console.WriteLine("///////MasHuPGaMinG//////");
            Console.WriteLine("/////////////////////////");
            Console.WriteLine("////Choisissez le jeu////");
            Console.WriteLine("/////////////////////////");
            Console.WriteLine("");
            Console.WriteLine("[1]  Nombre Magique");
            Console.WriteLine("[2]  TicTacToe");

            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Nombremagique guesswhatnumber = new Nombremagique();
                guesswhatnumber.LancerJeu();
            }
    ;
            if (userInput == "2")
            {
                Tictactoe morpion = new Tictactoe();
                morpion.LancerJeu();
            }
        }
    }
}