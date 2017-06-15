using UnityEngine;
using System.Collections;

public static class Constantes : object {

	// Le nom des scenes
	public const string NAME_SCENE_MENU = "menu";
	public const string NAME_SCENE_LEVEL = "level";
	public const string NAME_ECRAN_LEVELS = "levels";
	public const string NAME_SCENE_LEVELTEST = "levelTest";

	// Boutons
	public const string NAME_BTN_NEXT = "next";

	// Panel
	public const string NAME_PANEL = "Panel";

	// Touches
	public const string key_echap = "escape";
	public const string key_espace = "space";

	// Pièces
	public const string PIECE_TAG = "Piece";
	public const string NAME_WIN_OR1 = "winOr1";
	public const string NAME_WIN_OR2 = "winOr2";
	public const string NAME_WIN_OR3 = "winOr3";

	// Poubelle (script Game)
	public const string NAME_POUBELLE = "poubelle";
	public const string NAME_SCRIPT_GAME = "Game";
	public const string BALL_TAG = "Ball";

	// Titre du level dans le GUI GAGNE
	public const string NAME_TITRE_GUI_WIN = "titreGuiWin";
	public const string NAME_TITRE_GUI_LEVEL = "titreGuiLevel";
	public const string TEXT_TITRE_GUI_WIN = "Gagné !";
	public const string TEXT_TITRE_GUI_LOOSE = "Perdu !";
	public const string TEXT_TITRE_GUI_LEVEL = "Niveau ";

	// Vitesse de la balle
	public const int SPEED_BALL = 5;

	// Nom des pièces sur l'écran Levels
	public const string LEFT_COIN = "leftCoin";
	public const string MIDDLE_COIN = "middleCoin";
	public const string RIGHT_COIN = "rightCoin";
	
	// Canon
	public const int MIN_PUISSANCE_CANON = 200;
	public const int MULT_SPEED_BALL = 2;

	// Boutons selection du level
	public const string NAME_BTN_TEXT = "numMenuLevel";
	public const string NAME_BTN_CADENA = "cadena";
	public const string TAG_COIN = "Coin";
	public const string NAME_BTN_TENTATIVES = "Tentatives";

	// Choix de la langue
	public const string LANGUE = "langue";

	// Choix du son
	public const string BRUITAGE = "bruitage";
	public const string MUSIQUE = "musique";

	// Nom des playPrefs
	public const string NOM_PLAYPREF_TENTATIVES = "Tentatives_";
}
