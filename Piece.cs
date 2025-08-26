namespace JeuEchecs
{
    public enum TypePiece
    {
        Pion,
        Tour,
        Cavalier,
        Fou,
        Reine,
        Roi
    }
    
    public enum Couleur
    {
        Blanc,
        Noir
    }
    
    public class Piece
    {
        public TypePiece Type { get; private set; }
        public Couleur Couleur { get; private set; }
        public string Symbole { get; private set; }
        
        public Piece(TypePiece type, Couleur couleur)
        {
            Type = type;
            Couleur = couleur;
            Symbole = GetSymbole(type, couleur);
        }
        
        private string GetSymbole(TypePiece type, Couleur couleur)
        {
            string symbole = type switch
            {
                TypePiece.Pion => "♟",
                TypePiece.Tour => "♜",
                TypePiece.Cavalier => "♞",
                TypePiece.Fou => "♝",
                TypePiece.Reine => "♛",
                TypePiece.Roi => "♚",
                _ => "?"
            };
            
            // Les pièces blanches sont affichées normalement, les noires avec un fond sombre
            return symbole;
        }
        
        public override string ToString()
        {
            return $"{Couleur} {Type}";
        }
    }
}
