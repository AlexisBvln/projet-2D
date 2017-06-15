using UnityEngine;
using System.Collections;

public static class Global : object {

	public static int levelActive = 0; // le niveau en jeu
	public static int nombreLevel = 15; // le nombre de niveau
	public static string menuPage = "menu"; // la page sur laquelle on veut aller à partir de la scene "level"
	public static int point = 0; // nombre de point d'un niveau
	public static int[] listeScore = new int[nombreLevel + 1]; // tableau des scores
	public static bool isWin = false; // Si on gagne un niveau : TRUE
	public static bool waitForShoot = false; // True si on peu tirer
	public static float canonAngleMin = 0; // Les angles min et max de l'orientation du canon 
	public static float canonAngleMax = 90; // LEFT:180:-180, TOP:90, RIGHT:0, BOTTOM:-90
	public static int langueKey = 0; // Clé de la langue : [0 = fr], [1 = en]
	public static int[] listeTetatives = new int[nombreLevel + 1]; // nombre de tentatives par niveau
}
