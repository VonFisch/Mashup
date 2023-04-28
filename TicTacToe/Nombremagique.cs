using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashupgaming
{
    internal class Nombremagique
    {
        bool rejouer;
        bool quitgame;

        public void LancerJeu()                     //objet première page avec inscription des noms des joueurs
        {
                do
                {                                               //début de la boucle de jeu
                    Jeu();                                      //jeu
                    MenuFin();
                    

                } while (rejouer);                   //refait la boucle si "rejouer" et pas "retour"
        }




        private void MenuFin()
        {
            //    Console.WriteLine("//////////////////////////");                        //option de fin de jeu
            //    Console.WriteLine("Voulez-vous rejouer ? [y] ");
            //    Console.WriteLine("//////////////////////////");
            //    Console.WriteLine("Quitter le jeu ? [q]");
            //    Console.WriteLine("////////////////////");
            //    Console.WriteLine("");

            //    string userInput = Console.ReadLine().ToLower();                        //initialise chaine de characteres défini par la saisie du joueur

            //    rejouer = userInput == "y";                                             //variable y = true
            //    if (userInput == "q")                                                   //si q, ne retourne rien donc fin du program
            //    {
            //        return;
            //    }

            //    Console.Clear();                                                        //efface l'écran


            Console.WriteLine("////////////////////////////////");
            char userInput = Utils.RecupererSaisie("[Q]uitter ? [B]ack ? [R]ejouer ?", 'q', 'b', 'r');
            Console.WriteLine("////////////////////////////////");

            rejouer = userInput == 'r';                                             //variable y = true
            quitgame = userInput == 'q';                                                   //si q, ne retourne rien donc fin du program

            Console.Clear();                                                        //efface l'écran
        }

        private void Jeu()
        {
            Random rnd = new Random();                                       //défintion de la fonction random
            int le_chiffre = rnd.Next(101);                                 //initialisation de la variable le chiffre et sa définition random de 0 à 100
            int la_reponse = 0;                                            //initiation de la variable réponse
            int compteur = 0;                                             //initialisation de l'objet compteur

            Console.WriteLine("Bonjour, devinez un chiffre entre 0 et 100");

            la_reponse = LireSaisieUtilisateur();                               //défini la variable réponse par la saisie de l'utilisateur

                while (la_reponse != le_chiffre)                            //boucle si la réponse pas = au chiffre ---> nouvel essai
                {
                    if (la_reponse > le_chiffre)                            //écrit le message approprié
                    {
                        Console.WriteLine("Plus petit!");
                    }
                    else
                    {
                        Console.WriteLine("Plus grand!");  //si tout autre, réponse > chiffre
                    }
                    Console.WriteLine("Reessayez :-)");          
                    compteur++;                                  //compteur +1
                    la_reponse = LireSaisieUtilisateur();       //lecture de a saisie de l'utilisateur
                }
                Console.WriteLine("");
                Console.WriteLine($"Felicitation! vous avez réussi en {compteur} tentative"); //si la réponse est bonne, affichage du nombre de tentatives
                Console.WriteLine("");
        }

            private int LireSaisieUtilisateur()
            {
                while (true)
                {
                    string saisie = Console.ReadLine();

                    if (int.TryParse(saisie, out int resultat))      //comparaison de la saisie de l'utilisateur et du chiffre random
                    {
                        return resultat;
                    }
                }
            }
    }
}

