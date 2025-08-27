using System;

namespace JeuEchecs
{
    public class Echiquier
    {
        private Piece[,] plateau;
        public int NombreCoups { get; private set; }

        public Echiquier()
        {
            plateau = new Piece[8, 8];
            InitialiserPlateau();
            NombreCoups = 0;
        }
        
        private void InitialiserPlateau()
        {
            // Pions
            for (int c = 0; c < 8; c++)
            {
                plateau[6, c] = new Piece(TypePiece.Pion, Couleur.Blanc);
                plateau[1, c] = new Piece(TypePiece.Pion, Couleur.Noir);
            }
            
            // Tours
            plateau[7, 0] = new Piece(TypePiece.Tour, Couleur.Blanc);
            plateau[7, 7] = new Piece(TypePiece.Tour, Couleur.Blanc);
            plateau[0, 0] = new Piece(TypePiece.Tour, Couleur.Noir);
            plateau[0, 7] = new Piece(TypePiece.Tour, Couleur.Noir);
            
            // Cavaliers
            plateau[7, 1] = new Piece(TypePiece.Cavalier, Couleur.Blanc);
            plateau[7, 6] = new Piece(TypePiece.Cavalier, Couleur.Blanc);
            plateau[0, 1] = new Piece(TypePiece.Cavalier, Couleur.Noir);
            plateau[0, 6] = new Piece(TypePiece.Cavalier, Couleur.Noir);
            
            // Fous
            plateau[7, 2] = new Piece(TypePiece.Fou, Couleur.Blanc);
            plateau[7, 5] = new Piece(TypePiece.Fou, Couleur.Blanc);
            plateau[0, 2] = new Piece(TypePiece.Fou, Couleur.Noir);
            plateau[0, 5] = new Piece(TypePiece.Fou, Couleur.Noir);
            
            // Reines
            plateau[7, 3] = new Piece(TypePiece.Reine, Couleur.Blanc);
            plateau[0, 3] = new Piece(TypePiece.Reine, Couleur.Noir);
            
            // Rois
            plateau[7, 4] = new Piece(TypePiece.Roi, Couleur.Blanc);
            plateau[0, 4] = new Piece(TypePiece.Roi, Couleur.Noir);
        }

        public void Afficher()
        {
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine("  ─────────────────");

            for (int ligne = 0; ligne < 8; ligne++)
            {
                Console.Write($"{8 - ligne} ");
                for (int colonne = 0; colonne < 8; colonne++)
                {
                    if (plateau[ligne, colonne] == null)
                    {
                        // Alterner les couleurs des cases
                        if ((ligne + colonne) % 2 == 0)
                        {
                            Console.Write("□ ");
                        }
                        else
                        {
                            Console.Write("■ ");
                        }
                    }
                    else
                    {
                        Console.Write(plateau[ligne, colonne].Symbole + " ");
                    }
                }
                Console.WriteLine($" {8 - ligne}");
            }
            
            Console.WriteLine("  ─────────────────");
            Console.WriteLine("  a b c d e f g h");
        }
        
        public bool EstCoupValide(int ligneDepart, int colonneDepart, int ligneArrivee, int colonneArrivee, bool tourBlanc)
        {
            // Vérifier les limites
            if (ligneDepart < 0 || ligneDepart >= 8 || colonneDepart < 0 || colonneDepart >= 8 ||
                ligneArrivee < 0 || ligneArrivee >= 8 || colonneArrivee < 0 || colonneArrivee >= 8)
            {
                return false;
            }
            
            // Vérifier qu'il y a une pièce à la position de départ
            if (plateau[ligneDepart, colonneDepart] == null)
            {
                return false;
            }
            
            // Vérifier que c'est le bon tour
            if (plateau[ligneDepart, colonneDepart].Couleur == Couleur.Blanc != tourBlanc)
            {
                return false;
            }
            
            // Vérifier que la case d'arrivée n'est pas occupée par une pièce de la même couleur
            if (plateau[ligneArrivee, colonneArrivee] != null &&
                plateau[ligneArrivee, colonneArrivee].Couleur == plateau[ligneDepart, colonneDepart].Couleur)
            {
                return false;
            }
            
            // Vérifier la validité du mouvement selon le type de pièce
            return EstMouvementValide(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee);
        }
        
        private bool EstMouvementValide(int ligneDepart, int colonneDepart, int ligneArrivee, int colonneArrivee)
        {
            Piece piece = plateau[ligneDepart, colonneDepart];
            
            switch (piece.Type)
            {
                case TypePiece.Pion:
                    return EstMouvementPionValide(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee, piece.Couleur);
                case TypePiece.Tour:
                    return EstMouvementTourValide(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee);
                case TypePiece.Cavalier:
                    return EstMouvementCavalierValide(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee);
                case TypePiece.Fou:
                    return EstMouvementFouValide(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee);
                case TypePiece.Reine:
                    return EstMouvementReineValide(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee);
                case TypePiece.Roi:
                    return EstMouvementRoiValide(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee);
                default:
                    return false;
            }
        }
        
        private bool EstMouvementPionValide(int ligneDepart, int colonneDepart, int ligneArrivee, int colonneArrivee, Couleur couleur)
        {
            int direction = (couleur == Couleur.Blanc) ? -1 : 1;
            int ligneInitiale = (couleur == Couleur.Blanc) ? 6 : 1;
            
            // Mouvement en avant
            if (colonneDepart == colonneArrivee && ligneArrivee == ligneDepart + direction)
            {
                return plateau[ligneArrivee, colonneArrivee] == null;
            }
            
            // Premier mouvement (2 cases)
            if (colonneDepart == colonneArrivee && ligneDepart == ligneInitiale && 
                ligneArrivee == ligneDepart + 2 * direction)
            {
                return plateau[ligneDepart + direction, colonneDepart] == null && 
                       plateau[ligneArrivee, colonneArrivee] == null;
            }
            
            // Prise en diagonale
            if (Math.Abs(colonneArrivee - colonneDepart) == 1 && ligneArrivee == ligneDepart + direction)
            {
                return plateau[ligneArrivee, colonneArrivee] != null;
            }
            
            return false;
        }
        
        private bool EstMouvementTourValide(int ligneDepart, int colonneDepart, int ligneArrivee, int colonneArrivee)
        {
            if (ligneDepart != ligneArrivee && colonneDepart != colonneArrivee)
                return false;
            
            return !EstCheminBloque(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee);
        }
        
        private bool EstMouvementCavalierValide(int ligneDepart, int colonneDepart, int ligneArrivee, int colonneArrivee)
        {
            int deltaLigne = Math.Abs(ligneArrivee - ligneDepart);
            int deltaColonne = Math.Abs(colonneArrivee - colonneDepart);
            return (deltaLigne == 2 && deltaColonne == 1) || (deltaLigne == 1 && deltaColonne == 2);
        }
        
        private bool EstMouvementFouValide(int ligneDepart, int colonneDepart, int ligneArrivee, int colonneArrivee)
        {
            if (Math.Abs(ligneArrivee - ligneDepart) != Math.Abs(colonneArrivee - colonneDepart))
                return false;
            
            return !EstCheminBloque(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee);
        }
        
        private bool EstMouvementReineValide(int ligneDepart, int colonneDepart, int ligneArrivee, int colonneArrivee)
        {
            // La reine combine les mouvements de la tour et du fou
            if (ligneDepart == ligneArrivee || colonneDepart == colonneArrivee)
            {
                return !EstCheminBloque(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee);
            }
            
            if (Math.Abs(ligneArrivee - ligneDepart) == Math.Abs(colonneArrivee - colonneDepart))
            {
                return !EstCheminBloque(ligneDepart, colonneDepart, ligneArrivee, colonneArrivee);
            }
            
            return false;
        }
        
        private bool EstMouvementRoiValide(int ligneDepart, int colonneDepart, int ligneArrivee, int colonneArrivee)
        {
            int deltaLigne = Math.Abs(ligneArrivee - ligneDepart);
            int deltaColonne = Math.Abs(colonneArrivee - colonneDepart);
            return deltaLigne <= 1 && deltaColonne <= 1;
        }
        
        private bool EstCheminBloque(int ligneDepart, int colonneDepart, int ligneArrivee, int colonneArrivee)
        {
            int deltaLigne = Math.Sign(ligneArrivee - ligneDepart);
            int deltaColonne = Math.Sign(colonneArrivee - colonneDepart);
            
            int ligne = ligneDepart + deltaLigne;
            int colonne = colonneDepart + deltaColonne;
            
            while (ligne != ligneArrivee || colonne != colonneArrivee)
            {
                if (plateau[ligne, colonne] != null)
                    return true;
                
                ligne += deltaLigne;
                colonne += deltaColonne;
            }
            
            return false;
        }
        
        public void JouerCoup(int ligneDepart, int colonneDepart, int ligneArrivee, int colonneArrivee)
        {
            plateau[ligneArrivee, colonneArrivee] = plateau[ligneDepart, colonneDepart];
            plateau[ligneDepart, colonneDepart] = null;
            NombreCoups++;
        }
        
        public bool EstEchecEtMat(bool tourBlanc)
        {
            // Vérification simplifiée - on vérifie juste si le roi est en échec
            return EstEnEchec(tourBlanc);
        }
        
        public bool EstPat(bool tourBlanc)
        {
            // Vérification simplifiée - on retourne false pour l'instant
            return false;
        }
        
        private bool EstEnEchec(bool tourBlanc)
        {
            // Trouver la position du roi
            Couleur couleurRoi = tourBlanc ? Couleur.Blanc : Couleur.Noir;
            int ligneRoi = -1, colonneRoi = -1;
            
            for (int l = 0; l < 8; l++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (plateau[l, c] != null && 
                        plateau[l, c].Type == TypePiece.Roi && 
                        plateau[l, c].Couleur == couleurRoi)
                    {
                        ligneRoi = l;
                        colonneRoi = c;
                        break;
                    }
                }
                if (ligneRoi != -1) break;
            }

            // Vérifier si une pièce adverse peut attaquer le roi
            Couleur couleurAdverse = tourBlanc ? Couleur.Noir : Couleur.Blanc;
            
            for (int l = 0; l < 8; l++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (plateau[l, c] != null && plateau[l, c].Couleur == couleurAdverse)
                    {
                        if (EstMouvementValide(l, c, ligneRoi, colonneRoi))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
