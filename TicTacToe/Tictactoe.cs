using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashupgaming
{
    internal class Tictactoe
    {
        char[] tab = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //ojet cases cibles
        string nom1;
        string nom2;
        bool rejouer;
        bool retour;
        bool quitGame;


        public void LancerJeu()                     //objet première page avec inscription des noms des joueurs
        {
        
            do
            {
                MenuInscription();                              //affichage du menu 

                Board();                                        //création de l'objet tableau

                do
                {                                               //début de la boucle de jeu
                    Jeu();                                      //jeu

                    ChoixDeFinDePartie();                       //menu à choix multiple


                } while (rejouer && !retour && !quitGame);                   //refait la boucle si "rejouer" et pas "retour"


            } while (retour);                                   //refait la boucle retour


        }

        private void Jeu()
        {
            tab = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Random rnd = new Random();                      //choix du joueur de manière aléatoire
            int player = rnd.Next(1, 3);                    //initiation de l'alternance entre les joueur à chaque tour
            bool etat = true;                               //objet d'opération logique de comparison 
            int victoire = 0;                              //initialisation de la variable "victoire" 0 = continue, pour l'instant


            do                                              //début de boucle du jeu
            {
                Console.Clear();                            //efface la page

                Console.Write($" {nom1}:X         {nom2}:O " + Environment.NewLine);    //écrit les noms inscrits

                if (player % 2 == 0)                                                    //boucle de choix aléatoire du 1er joueur  
                {
                    Console.WriteLine($"Au tour de {nom2}");                            //si joueur 2 lance le jeu
                    etat = true;                                                        //se réfère à la comparaison ? 
                }
                else
                {
                    Console.WriteLine($"Au tour de {nom1}");                            //si joueur 1 lance le jeu
                    etat = false;                                                       //se réfère à la comparaison ?
                }

                Console.WriteLine(Environment.NewLine);                                 //retour à la ligne

                Board();                                                                //tableau 2 dimensions


                int input = LireSaisieUtilisateur(1);                //lecture de la saisie clavier(limitée à 1 charactère) et initialise la variable input 


                if (tab[input] != 'X' && tab[input] != 'O')         //si des chiffres sont entrés écrit X ou O selon joueur
                {


                    if (etat)                                //si joueur ("etat" se réferre au choix aléatoire du joueur)
                    {
                        tab[input] = 'O';                    //écrit O à la place du chiffre correspondant dans le tableau
                    }
                    else
                    {
                        tab[input] = 'X';                    //sinon écrit X par défaut ca que deux joueurs
                    }
                    player++;                                //changement de joueur
                }
                else
                {

                    Console.WriteLine("Sorry! Mauvaise touche! La case est deja prise. Wiederhole!");
                    Console.Write("Relance en cours ");
                    //si la case est déjà prise écrit message avec pseudo temps de chargement
                    Thread.Sleep(1500);
                    Console.Write("-");

                    Thread.Sleep(1500);     //temps d'attente
                    Console.Write("-");     //ajout de la barre de chargement

                    Thread.Sleep(1500);
                    Console.Write("-");

                }

                Console.Clear();            //efface l'écran

                Board();                    //réécrit le tableau avec modifications

                victoire = VerificationVictoire();  //check si une ligne, colonne ou diagonale est remplie 

            } while (victoire != -1 && victoire != 1);     //si pas de victoire (condition pour vitoire) refait la boucle

            string gagnant = TourDuJoueur(etat, nom1, nom2);  //si le dernier joueur a rempli la condition de victoire

            if (victoire == 1)                               //si victoire (=1)  
            {
                Console.WriteLine($"Félicitation {gagnant}"); //écrit félicitations
            }
            else
            {
                Console.WriteLine($"Egalite!");               //tout autre = égalité
            }
        }

        private void MenuInscription()
        {
            Console.WriteLine("TicTacToe");                 //écriture du titre
            Console.WriteLine("Entrez le nom du joueur 1"); //écriture de l'instruction
            nom1 = Console.ReadLine();                      //lecture de l'inscription du joueur
            Console.WriteLine("Entrez le nom du joueur 2"); //écriture de l'instruction
            nom2 = Console.ReadLine();                      //lecture de l'isctription du joueur
        }
        private void Board()                      //graphique et mapping du tableau
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {tab[7]}  |  {tab[8]}  |  {tab[9]}   ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {tab[4]}  |  {tab[5]}  |  {tab[6]}  ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {tab[1]}  |  {tab[2]}  |  {tab[3]}  ");
            Console.WriteLine("     |     |      ");
        }

        private int VerificationVictoire()    //conditions de victoire ou égalité 
        {
            // Victoire verticale (check les cases remplies)
            if (tab[1] == tab[4] && tab[4] == tab[7])
            {
                return 1;
            }
            else if (tab[2] == tab[5] && tab[5] == tab[8])
            {
                return 1;
            }
            else if (tab[3] == tab[6] && tab[6] == tab[9])
            {
                return 1;
            }
            //Victoire horizontale (check les cases remplies)
            else if (tab[1] == tab[2] && tab[2] == tab[3])
            {
                return 1;
            }
            else if (tab[4] == tab[5] && tab[5] == tab[6])                      //check si une ligne/colonne/diagonale est remplie du même charactère (X ou 0)
            {                                                                   //retourne la valeur dans la variable "victoire" 0 = continue le jeu
                return 1;                                                       //                                               1 = victoire 
            }                                                                   //                                              -1 = égalité
            else if (tab[7] == tab[8] && tab[8] == tab[9])
            {
                return 1;
            }
            //Victoire diagonale (check les cases remplies)
            else if (tab[1] == tab[5] && tab[5] == tab[9])
            {
                return 1;
            }
            else if (tab[3] == tab[5] && tab[5] == tab[7])
            {
                return 1;
            }
            //Egalite (check si toutes les cases sont remplies)
            else if (tab[1] != '1' && tab[2] != '2' && tab[3] != '3' && tab[4] != '4' && tab[5] != '5' && tab[6] != '6' && tab[7] != '7' && tab[8] != '8' && tab[9] != '9')
            {
                return -1;
            }
            //continue (tout le reste)
            else
            {
                return 0;
            }
        }

        private string TourDuJoueur(bool etat, string nom1, string nom2) //détermine l'affichage du nom du joueur lors  de son tour
        {
            if (etat)
            {
                return nom2;
            }
            else
            {
                return nom1;
            }

        }

        private int LireSaisieUtilisateur(int maxLength)                             //Saisie du choix de la case avec limite de charactere
        {
            while (true)
            {
                string saisie = Console.ReadLine();                                 //initiation variable "saisie"

                if (saisie.Length > maxLength)                                      //si saisie plus grand que limite --> message
                {
                    Console.WriteLine("Hey! UN seul charactere est permis! ;-)");
                    Thread.Sleep(1500);

                    saisie = saisie.Substring(0, maxLength);                        //détermine la longueur de lecture de la saisie, pour l'instant 0
                }

                if (int.TryParse(saisie, out int resultat))                         //transforme la saisie en X ou O
                {
                    return resultat;                                                //voir resultat plus haut
                }
            }
        }


        private void ChoixDeFinDePartie()
        {
            //Console.WriteLine("//////////////////////////");                        //option de fin de jeu
            //Console.WriteLine("Voulez-vous rejouer ? [y] ");
            //Console.WriteLine("//////////////////////////");
            //Console.WriteLine("Retourner au menu d'inscription ? [r]");
            //Console.WriteLine("/////////////////////////////////////");
            //Console.WriteLine("Quitter ? [q]");
            //Console.WriteLine("/////////////");
            //Console.WriteLine("");

            //string userInput = Console.ReadLine().ToLower();                        //initialise chaine de characteres défini par la saisie du joueur

            //if (userInput.Length > maxLength)                                      //si saisie plus grand que limite --> message
            //{
            //    userInput = userInput.Substring(0, maxLength);                        //détermine la longueur de lecture de la saisie, pour l'instant 0
            //}



                                 Console.WriteLine("////////////////////////////////");
            char userInput = Utils.RecupererSaisie("[Q]uitter ? [B]ack ? [R]ejouer ?", 'q', 'b', 'r');
                                 Console.WriteLine("////////////////////////////////");

            rejouer = userInput == 'r';                                             //variable y = true
            retour = userInput == 'b';                                              //variable b = true
            quitGame = userInput == 'q';                                            

            Console.Clear();                                                        //efface l'écran
        }

        public override string ToString()
        {
            return "Un jeu de morpion";
        }
    }
}
