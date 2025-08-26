using System;

namespace JeuEchecs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "♔ Jeu d'Échecs Console ♛";
            
            Console.WriteLine("♔ ♛ ♔ ♛ ♔ ♛ ♔ ♛ ♔ ♛ ♔ ♛ ♔ ♛ ♔ ♛");
            Console.WriteLine("        JEU D'ÉCHECS CONSOLE");
            Console.WriteLine("♛ ♔ ♛ ♔ ♛ ♔ ♛ ♔ ♛ ♔ ♛ ♔ ♛ ♔ ♛ ♔");
            Console.WriteLine();
            
            JeuEchecs jeu = new JeuEchecs();
            jeu.Demarrer();
        }
    }
}
