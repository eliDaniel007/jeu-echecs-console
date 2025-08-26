using System;

namespace JeuEchecs
{
    public class JeuEchecs
    {
        private Echiquier echiquier;
        private bool tourBlanc;
        private bool partieTerminee;
        
        public JeuEchecs()
        {
            echiquier = new Echiquier();
            tourBlanc = true; // Les blancs commencent
            partieTerminee = false;
        }
        
        public void Demarrer()
        {
            while (!partieTerminee)
            {
                echiquier.Afficher();
                AfficherTour();
                
                if (tourBlanc)
                {
                    Console.WriteLine("♔ Tour des BLANCS ♔");
                }
                else
                {
                    Console.WriteLine("♛ Tour des NOIRS ♛");
                }
                
                if (!DemanderCoup())
                {
                    break; // Sortir si l'utilisateur veut quitter
                }
                
                // Vérifier si la partie est terminée
                if (echiquier.EstEchecEtMat(tourBlanc))
                {
                    echiquier.Afficher();
                    if (tourBlanc)
                    {
                        Console.WriteLine("♛ Les NOIRS ont gagné ! ♛");
                    }
                    else
                    {
                        Console.WriteLine("♔ Les BLANCS ont gagné ! ♔");
                    }
                    partieTerminee = true;
                }
                else if (echiquier.EstPat(tourBlanc))
                {
                    echiquier.Afficher();
                    Console.WriteLine("♟️ Match nul par pat ! ♟️");
                    partieTerminee = true;
                }
                else
                {
                    tourBlanc = !tourBlanc; // Changer de tour
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine("Merci d'avoir joué ! Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
        
        private void AfficherTour()
        {
            Console.WriteLine($"\n=== Tour {echiquier.NombreCoups + 1} ===");
        }
        
        private bool DemanderCoup()
        {
            Console.Write("Entrez votre coup (ex: e2e4) ou 'q' pour quitter: ");
            string input = Console.ReadLine()?.Trim().ToLower();
            
            if (input == "q" || input == "quit")
            {
                return false;
            }
            
            if (input.Length != 4)
            {
                Console.WriteLine("❌ Format invalide ! Utilisez le format 'e2e4'");
                return false;
            }
            
            try
            {
                int colonneDepart = input[0] - 'a';
                int ligneDepart = 8 - (input[1] - '0');
                int colonneArrivee = input[2] - 'a';
                int ligneArrivee = 8 - (input[3] - '0');
                
                if (echiquier.EstCoupValide(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee, tourBlanc))
                {
                    echiquier.JouerCoup(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee);
                    return true;
                }
                else
                {
                    Console.WriteLine("❌ Coup invalide ! Vérifiez les règles d'échecs.");
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("❌ Coordonnées invalides ! Utilisez a-h et 1-8");
                return false;
            }
        }
    }
}
