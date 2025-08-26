# ♔ Jeu d'Échecs Console ♛

## 🎯 Description
Un jeu d'échecs simple et minimaliste développé en C# pour la console Windows. Ce projet démontre l'utilisation des concepts de programmation orientée objet.

## 🚀 Fonctionnalités
- **Plateau 8x8** avec affichage en console
- **Toutes les pièces** d'échecs (Pion, Tour, Cavalier, Fou, Reine, Roi)
- **Règles de base** respectées pour chaque type de pièce
- **Validation des coups** selon les règles d'échecs
- **Détection d'échec** (simplifiée)
- **Interface en français** avec symboles Unicode
- **Système de tours** alternés (Blancs/Noirs)

## 🎮 Comment Jouer
1. **Lancer le jeu** : `dotnet run`
2. **Format des coups** : `e2e4` (départ → arrivée)
3. **Coordonnées** : 
   - Colonnes : a, b, c, d, e, f, g, h
   - Lignes : 1, 2, 3, 4, 5, 6, 7, 8
4. **Quitter** : Tapez `q` ou `quit`

## 🏗️ Architecture Orientée Objet

### Classes Principales
- **`Program.cs`** : Point d'entrée et interface utilisateur
- **`JeuEchecs.cs`** : Logique principale du jeu et gestion des tours
- **`Echiquier.cs`** : Plateau de jeu et validation des mouvements
- **`Piece.cs`** : Représentation des pièces et leurs symboles

### Concepts POO Utilisés
- ✅ **Encapsulation** : Propriétés privées avec getters publics
- ✅ **Héritage** : Structure extensible pour les pièces
- ✅ **Polymorphisme** : Méthodes spécialisées par type de pièce
- ✅ **Séparation des responsabilités** : Chaque classe a un rôle défini

## 🛠️ Technologies
- **Langage** : C# (.NET 6.0)
- **Plateforme** : Console Windows
- **Encodage** : UTF-8 pour les symboles Unicode
- **IDE** : Compatible Visual Studio, VS Code, Rider

## 📁 Structure du Projet
```
INF11107-programmation-oo-1/
├── Program.cs              # Point d'entrée
├── JeuEchecs.cs           # Logique principale
├── Echiquier.cs           # Plateau et règles
├── Piece.cs               # Définition des pièces
├── JeuEchecs.csproj      # Configuration du projet
└── README-JeuEchecs.md   # Documentation
```

## 🚀 Compilation et Exécution

### Prérequis
- .NET 6.0 SDK ou plus récent
- Console Windows compatible UTF-8

### Commandes
```bash
# Restaurer les dépendances
dotnet restore

# Compiler le projet
dotnet build

# Exécuter le jeu
dotnet run

# Créer un exécutable
dotnet publish -c Release
```

## 🎯 Exemples de Coups
- **Ouverture classique** : `e2e4` (Pion blanc e2 → e4)
- **Développement du cavalier** : `b1c3` (Cavalier blanc b1 → c3)
- **Développement du fou** : `c1e3` (Fou blanc c1 → e3)

## 🔍 Règles Implémentées
- **Pions** : Mouvement en avant, prise en diagonale, premier coup 2 cases
- **Tours** : Mouvement horizontal et vertical
- **Cavaliers** : Mouvement en L (2+1 cases)
- **Fous** : Mouvement diagonal
- **Reine** : Combinaison Tour + Fou
- **Roi** : Une case dans toutes les directions

## 🚧 Limitations Actuelles
- Détection d'échec et mat simplifiée
- Pas de détection de pat
- Pas de roque ou de prise en passant
- Pas de promotion des pions
- Pas de sauvegarde de partie

## 🔮 Améliorations Futures
- [ ] Détection complète d'échec et mat
- [ ] Détection de pat
- [ ] Règles spéciales (roque, prise en passant)
- [ ] Promotion des pions
- [ ] Sauvegarde/chargement de parties
- [ ] Interface graphique simple
- [ ] Mode contre IA basique

## 👨‍💻 Auteur
**Étudiant** : [Votre nom]  
**Cours** : INF11107 - Programmation Orientée Objet I  
**Date** : Automne 2023  
**Institution** : [Nom de l'institution]

---

*Ce projet fait partie du portfolio académique pour le cours INF11107 - Programmation Orientée Objet I*
