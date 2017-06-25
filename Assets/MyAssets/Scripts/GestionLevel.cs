using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionLevel : MonoBehaviour
{

    public GameObject piecePrefab;
    public GameObject poubellePrefab;
    public GameObject basketPrefab;
    public GameObject grueOnPrefab;
    public GameObject grue2OnPrefab;
    public GameObject grueOffPrefab;
    public GameObject ballPrefab;
    public GameObject canonPrefab;

    public static GameObject panel;

    public int levelTestActive;

    /******************************************************************************
	 * START
	 *****************************************************************************/
    void Awake()
    {

        Global.point = 0;
        Global.isWin = false;

        // Cache le panel au démarage
        panel = GameObject.Find(Constantes.NAME_PANEL);
        if (panel != null)
            panel.SetActive(false);

        // Affiche les Objets du niveau
        chargeLevel();

        Global.waitForShoot = true;
    }

    /******************************************************************************
	 * UPDATE
	 *****************************************************************************/
    void Update()
    {
        // Quand on clique sur ECHAP, on revient à l'écran des levels
        if (Input.GetKey(Constantes.key_echap))
        {
            Global.menuPage = Constantes.NAME_ECRAN_LEVELS;
            SceneManager.LoadScene(Constantes.NAME_SCENE_MENU);
        }

        // Si on appui sur barre d'espace, on relance le jeu
        if (Input.GetKey(Constantes.key_espace))
        {
            restartLevel();
        }
    }

    /******************************************************************************
	 * AUTRES FONCTIONS
	 *****************************************************************************/
    // Quand on clique sur le bouton "NEXT"
    public void nextLevel()
    {
        Global.levelActive++;
        SceneManager.LoadScene(Constantes.NAME_SCENE_LEVEL);
    }

    // Quand on clique sur le bouton restart level
    public void RelanceJeu()
    {
        if (SceneManager.GetActiveScene().name.Equals(Constantes.NAME_SCENE_LEVELTEST))
        {
            SceneManager.LoadScene(Constantes.NAME_SCENE_LEVELTEST);
        }
        else
        {
            SceneManager.LoadScene(Constantes.NAME_SCENE_LEVEL);
        }
    }

    // Quand on clique sur le bouton pour revenir sur la sélection de level
    public void afficheLevels()
    {
        Global.menuPage = Constantes.NAME_ECRAN_LEVELS;
        SceneManager.LoadScene(Constantes.NAME_SCENE_MENU);
    }

    public static void SaveLevel(int numLevel, int score)
    {
        // Si le score est meilleur que celui en sauvegarde, on enregistre
        if (score > Global.listeScore[numLevel])
        {
            Global.listeScore[numLevel] = score;
            PlayerPrefs.SetInt(numLevel.ToString(), score);
        }
        affichePanelScore();
    }

    public void restartLevel()
    {
        if (!Global.isWin)
        {
            if (SceneManager.GetActiveScene().name.Equals(Constantes.NAME_SCENE_LEVELTEST))
            {
                if (levelTestActive != 0)
                {
                    Global.levelActive = levelTestActive;
                }
                SceneManager.LoadScene(Constantes.NAME_SCENE_LEVELTEST);
            }
            else
            {
                SceneManager.LoadScene(Constantes.NAME_SCENE_LEVEL);
            }
        }
    }

    public static void affichePanelScore()
    {
        panel.SetActive(true);
    }

    /******************************************************************************
	 * COORDONNEES LEVEL
	 *****************************************************************************/

    void chargeLevel()
    {
        switch (Global.levelActive)
        {
            case 1:
                Instantiate(piecePrefab.transform, new Vector3((float)-270, (float)-157, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)-1, (float)-141, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)293, (float)-203, 0), Quaternion.identity);
                Instantiate(poubellePrefab.transform, new Vector3((float)400, (float)-213, 0), Quaternion.Euler(new Vector3(0, 0, 80)));
                Instantiate(canonPrefab.transform, new Vector3((float)-500, (float)-238, 0), Quaternion.identity);
                Global.canonAngleMin = -10;
                Global.canonAngleMax = 90;
                break;
            case 2:
                Instantiate(piecePrefab.transform, new Vector3((float)-270, (float)95, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)-1, (float)200, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)293, (float)-23, 0), Quaternion.identity);
                Instantiate(poubellePrefab.transform, new Vector3((float)400, (float)-205, 0), Quaternion.identity);
                Instantiate(canonPrefab.transform, new Vector3((float)-500, (float)-238, 0), Quaternion.identity);
                Global.canonAngleMin = -10;
                Global.canonAngleMax = 90;
                break;
            case 3:
                Instantiate(piecePrefab.transform, new Vector3((float)-189, (float)47, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)94, (float)-212, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)314, (float)-114, 0), Quaternion.identity);
                Instantiate(poubellePrefab.transform, new Vector3((float)400, (float)-205, 0), Quaternion.identity);
                Instantiate(canonPrefab.transform, new Vector3((float)-460, (float)-238, 0), Quaternion.identity);
                Global.canonAngleMin = -10;
                Global.canonAngleMax = 90;
                break;
            case 4:
                Instantiate(piecePrefab.transform, new Vector3((float)-327, (float)47, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)-1, (float)200, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)314, (float)-51, 0), Quaternion.identity);
                Instantiate(grueOnPrefab.transform, new Vector3((float)-101, (float)-120.4, 0), Quaternion.identity);
                Instantiate(grueOnPrefab.transform, new Vector3((float)12.9, (float)41.3, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                Instantiate(grueOnPrefab.transform, new Vector3((float)126.9, (float)-120.4, 0), Quaternion.identity);
                Instantiate(poubellePrefab.transform, new Vector3((float)400, (float)-205, 0), Quaternion.identity);
                Instantiate(canonPrefab.transform, new Vector3((float)-500, (float)-238, 0), Quaternion.identity);
                Global.canonAngleMin = -10;
                Global.canonAngleMax = 90;
                break;
            case 5:
                Instantiate(piecePrefab.transform, new Vector3((float)450, (float)-5, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)120, (float)1, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)40, (float)-135, 0), Quaternion.identity);
                Instantiate(grueOnPrefab.transform, new Vector3((float)431, (float)-69, 0), Quaternion.Euler(new Vector3(0, 0, -53)));
                Instantiate(canonPrefab.transform, new Vector3((float)-460, (float)-238, 0), Quaternion.identity);
                Instantiate(poubellePrefab.transform, new Vector3((float)20, (float)-205, 0), Quaternion.identity);
                Global.canonAngleMin = -10;
                Global.canonAngleMax = 90;
                break;
            case 6:
                Instantiate(piecePrefab.transform, new Vector3((float)-211, (float)167, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)0, (float)0, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)243, (float)-81, 0), Quaternion.identity);
                Instantiate(grueOnPrefab.transform, new Vector3((float)-101, (float)-120.4, 0), Quaternion.identity);
                Instantiate(grueOnPrefab.transform, new Vector3((float)13, (float)-100, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                Instantiate(grueOnPrefab.transform, new Vector3((float)126.9, (float)-120.4, 0), Quaternion.identity); ;
                Instantiate(canonPrefab.transform, new Vector3((float)-460, (float)-238, 0), Quaternion.identity);
                Instantiate(poubellePrefab.transform, new Vector3((float)271, (float)-205, 0), Quaternion.identity);
                Global.canonAngleMin = -10;
                Global.canonAngleMax = 90;
                break;
            case 7:
                Instantiate(piecePrefab.transform, new Vector3((float)-37, (float)24, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)60, (float)-193, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)243, (float)-81, 0), Quaternion.identity);
                Instantiate(grueOnPrefab.transform, new Vector3((float)-227, (float)-119, 0), Quaternion.identity);
                Instantiate(grue2OnPrefab.transform, new Vector3((float)-132.7, (float)-5.5, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                Instantiate(grue2OnPrefab.transform, new Vector3((float)174, (float)-188, 0), Quaternion.identity);
                Instantiate(canonPrefab.transform, new Vector3((float)-460, (float)-238, 0), Quaternion.identity);
                Instantiate(poubellePrefab.transform, new Vector3((float)271, (float)-205, 0), Quaternion.identity);
                Global.canonAngleMin = -10;
                Global.canonAngleMax = 90;
                break;
                //Niveau Thomas 1:
            case 8:
                Instantiate(piecePrefab.transform, new Vector3((float)-135, (float)141, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)141, (float)-81, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)0, (float)-150, 0), Quaternion.identity);
                Instantiate(grue2OnPrefab.transform, new Vector3((float)-270, (float)-190, 0), Quaternion.Euler(new Vector3(0, 0, -11)));
                Instantiate(grue2OnPrefab.transform, new Vector3((float)-234, (float)-56, 0), Quaternion.Euler(new Vector3(0, 0, -11)));
                Instantiate(grue2OnPrefab.transform, new Vector3((float)-147, (float)32, 0), Quaternion.Euler(new Vector3(0, 0, 86)));
                Instantiate(grue2OnPrefab.transform, new Vector3((float)-83, (float)-62, 0), Quaternion.identity);
                Instantiate(grue2OnPrefab.transform, new Vector3((float)-70, (float)-193, 0), Quaternion.identity);
                Instantiate(grue2OnPrefab.transform, new Vector3((float)143, (float)-191, 0), Quaternion.identity);
                Instantiate(grue2OnPrefab.transform, new Vector3((float)318, (float)30, 0), Quaternion.identity);

                Instantiate(canonPrefab.transform, new Vector3((float)-500, (float)-237, 0), Quaternion.identity);
                Instantiate(poubellePrefab.transform, new Vector3((float)-6, (float)-205, 0), Quaternion.identity);
                Global.canonAngleMin = -10;
                Global.canonAngleMax = 90;
                break;
            //Niveau Thomas 3:
            case 09:
                Instantiate(piecePrefab.transform, new Vector3((float)-135, (float)141, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)141, (float)-81, 0), Quaternion.identity);
                Instantiate(piecePrefab.transform, new Vector3((float)250, (float)-3, 0), Quaternion.identity);
                Instantiate(grue2OnPrefab.transform, new Vector3((float)-270, (float)-190, 0), Quaternion.Euler(new Vector3(0, 0, -11)));
                Instantiate(grue2OnPrefab.transform, new Vector3((float)-234, (float)-56, 0), Quaternion.Euler(new Vector3(0, 0, -11)));
                Instantiate(grue2OnPrefab.transform, new Vector3((float)-147, (float)32, 0), Quaternion.Euler(new Vector3(0, 0, 86)));
                Instantiate(grue2OnPrefab.transform, new Vector3((float)-83, (float)-62, 0), Quaternion.identity);
                Instantiate(grue2OnPrefab.transform, new Vector3((float)-70, (float)-193, 0), Quaternion.identity);
                Instantiate(grue2OnPrefab.transform, new Vector3((float)143, (float)-191, 0), Quaternion.identity);
                Instantiate(grue2OnPrefab.transform, new Vector3((float)318, (float)-191, 0), Quaternion.identity);
                Instantiate(grue2OnPrefab.transform, new Vector3((float)318, (float)-55, 0), Quaternion.identity);
                // impossible d'afficher à l'écran mon objet "basket"!! 
                //  Instantiate(basketPrefab.transform, new Vector3((float)255, (float)-60, 0), Quaternion.identity);
                // je laisse pour le moment la corbeille - TODO : basket à la place de corbeille
                Global.canonAngleMin = -10;
                Global.canonAngleMax = 90;
                Instantiate(canonPrefab.transform, new Vector3((float)-460, (float)-238, 0), Quaternion.identity);
               Instantiate(poubellePrefab.transform, new Vector3((float)-6, (float)-205, 0), Quaternion.identity);
                break;
                
            default:
                break;
        }
    }
}
