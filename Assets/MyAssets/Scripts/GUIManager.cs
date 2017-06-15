using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {

	public GameObject btn_Jouer;
	public GameObject btn_Quitter;
	public GameObject btn_Retour;
	public GameObject levels;
	public GameObject btn_langue;
	public GameObject btn_music;
	public GameObject btn_bruitage;
	public GameObject languetteParam;
	public Animator languetteAnim;

	public Sprite langue_fr;
	public Sprite langue_en;
	public Sprite musique_on;
	public Sprite musique_off;
	public Sprite bruitage_on;
	public Sprite bruitage_off;

	public Sprite gold;
	public Sprite locked;

	void Awake (){
		// Gestion de la langue
		if (!PlayerPrefs.HasKey(Constantes.LANGUE)) {
			PlayerPrefs.SetString (Constantes.LANGUE, "fr");
			Global.langueKey = 0;
		} else {
			switch (PlayerPrefs.GetString (Constantes.LANGUE)) {
			case "fr": 
				Global.langueKey = 0;
				btn_langue.GetComponent<Image>().sprite = langue_fr;
				break;
			case "en":
				Global.langueKey = 1;
				btn_langue.GetComponent<Image>().sprite = langue_en;
				break;
			default:
				break;
			}
		}

		// Gestion de la musique
		if (!PlayerPrefs.HasKey (Constantes.MUSIQUE)) {
			PlayerPrefs.SetInt (Constantes.MUSIQUE, 1);
		} else {
			switch (PlayerPrefs.GetInt(Constantes.MUSIQUE)) {
			case 0: 
				btn_music.GetComponent<Image>().sprite = musique_off;
				// Désactiver la musique
				break;
			case 1:
				btn_music.GetComponent<Image>().sprite = musique_on;
				// Activer la musique
				break;
			default:
				break;
			}
		}

		// Gestion des bruitages
		if (!PlayerPrefs.HasKey (Constantes.BRUITAGE)) {
			PlayerPrefs.SetInt (Constantes.BRUITAGE, 1);
		} else {
			switch (PlayerPrefs.GetInt(Constantes.BRUITAGE)) {
			case 0: 
				btn_bruitage.GetComponent<Image>().sprite = bruitage_off;
				// Désactiver la musique
				break;
			case 1:
				btn_bruitage.GetComponent<Image>().sprite = bruitage_on;
				// Activer la musique
				break;
			default:
				break;
			}
		}
	}

	void Start(){
		switch (Global.menuPage) {
		case "menu":
			AfficheAccueil ();
			break;
		case "levels":
			AfficheLevels ();
			break;
		default:
			break;
		}
	}


	/************************************************************************
	 * Navigation
	 ***********************************************************************/
	public void QuitGame(){
		Application.Quit ();
	}

	public void AfficheLevels(){
		btn_Jouer.SetActive (false);
		btn_Quitter.SetActive (false);
		btn_Retour.SetActive (true);
		levels.SetActive (true);
		chargerPieceMenuLevel ();
		Global.menuPage = "levels";
	}

	public void AfficheAccueil(){
		btn_Jouer.SetActive (true);
		btn_Quitter.SetActive (true);
		btn_Retour.SetActive (false);
		levels.SetActive (false);
		Global.menuPage = "menu";
		btn_Jouer.GetComponentInChildren<Text> ().text = Langues.btn_play [Global.langueKey];
		btn_Quitter.GetComponentInChildren<Text> ().text = Langues.btn_quit [Global.langueKey];
	}

	public void LanceJeu(GameObject bouton){
		if (bouton != null) {
			Global.levelActive = int.Parse(bouton.name);
			SceneManager.LoadScene(Constantes.NAME_SCENE_LEVEL);
		}
	}

	// Supprime toutes les sauvegardes
	public void DeleteSAve(){
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene (Constantes.NAME_SCENE_MENU);
	}

	/************************************************************************
	 * Gestion des levels
	 ***********************************************************************/

	// Récupère les scores sauvegardés
	void chargeSave(){
		for (int i = 1; i < Global.nombreLevel+1; i++) {
			Global.listeScore [i] = PlayerPrefs.GetInt (i.ToString ());
			Global.listeTetatives [i] = PlayerPrefs.GetInt (Constantes.NOM_PLAYPREF_TENTATIVES + i.ToString ());
		}
	}

	// Affiche les levels
	void chargerPieceMenuLevel(){
		chargeSave ();
		bool flagIsActive = true;

		// pour chaque level
		foreach(Transform level in levels.transform){ 
			if (int.Parse(level.name) < Global.listeScore.Length){
				int score = Global.listeScore[int.Parse(level.name)];
				int nbTentative = Global.listeTetatives[int.Parse(level.name)];

				// Pour activer / désactiver le bouton du level
				if (flagIsActive){
					level.GetComponent<Button>().interactable = true;
				}
				else {
					level.GetComponent<Button>().interactable = false;
					level.GetComponent<Image>().sprite = locked;
				}

				// pour chaque item du bouton
				foreach(Transform itemTransform in level.transform){ 
					GameObject itemGameObject = itemTransform.gameObject;

					switch (itemTransform.tag) {
					case Constantes.TAG_COIN:
						Image image = itemGameObject.GetComponentInChildren<Image> ();

						if (flagIsActive) {
							switch (score) {
							case 1:
								if (itemTransform.name.Equals (Constantes.LEFT_COIN)) {
									image.sprite = gold;
								}
								break;
							case 2:
								if (itemTransform.name.Equals (Constantes.LEFT_COIN) || itemTransform.name.Equals (Constantes.MIDDLE_COIN)) {
									image.sprite = gold;
								}
								break;
							case 3:
								if (itemTransform.name.Equals (Constantes.LEFT_COIN) || itemTransform.name.Equals (Constantes.MIDDLE_COIN) || itemTransform.name.Equals (Constantes.RIGHT_COIN)) {
									image.sprite = gold;
								}
								break;
							default:
								break;
							}
						}
						break;
					case Constantes.NAME_BTN_CADENA :
						if (flagIsActive){
							itemGameObject.GetComponentInChildren<Image>().enabled = false;
						} 
						else{
							itemGameObject.GetComponentInChildren<Image>().enabled = true;
						}
						break;
					case Constantes.NAME_BTN_TEXT :
						if (flagIsActive){
							itemGameObject.GetComponent<Text>().enabled = true;
							itemGameObject.GetComponent<Text>().text = level.name;
						} 
						else{
							itemGameObject.GetComponent<Text>().enabled = false;
						}
						break;
					case Constantes.NAME_BTN_TENTATIVES:
						if (flagIsActive) {
							itemGameObject.GetComponent<Text> ().text = nbTentative.ToString ();
						} else {
							itemGameObject.GetComponent<Text> ().text = string.Empty;
						}
						break;
					}
				}

				// Si score = 0 alors c'est le dernier level actif
				if (score < 3){
					flagIsActive = false;
				}
			}
		}
	}

	/************************************************************************
	 * PARAMETRES
	 ***********************************************************************/
	// Quand on clique sur le drapeau pour changer de langue
	public void changeLangue(){
		switch (Global.langueKey) {
		case 0: 
			Global.langueKey = 1;
			btn_langue.GetComponent<Image>().sprite = langue_en;
			PlayerPrefs.SetString (Constantes.LANGUE, "en");
			break;
		case 1 :
			Global.langueKey = 0;
			btn_langue.GetComponent<Image>().sprite = langue_fr;
			PlayerPrefs.SetString (Constantes.LANGUE, "fr");
			break;
		}
		SceneManager.LoadScene (Constantes.NAME_SCENE_MENU);
	}

	// Quand on clique sur le bouton musique
	public void changeMusique(){
		switch (PlayerPrefs.GetInt (Constantes.MUSIQUE)) {
		case 0: 
			PlayerPrefs.SetInt (Constantes.MUSIQUE, 1);
			btn_music.GetComponent<Image>().sprite = musique_on;
			// Activer la musique
			break;
		case 1:
			PlayerPrefs.SetInt (Constantes.MUSIQUE, 0);
			btn_music.GetComponent<Image>().sprite = musique_off;
			// Désactiver la musique
			break;
		default:
			break;
		}
	}

	// Quand on clique sur le bouton bruitage
	public void changeBruitage(){
		switch (PlayerPrefs.GetInt (Constantes.BRUITAGE)) {
		case 0: 
			PlayerPrefs.SetInt (Constantes.BRUITAGE, 1);
			btn_bruitage.GetComponent<Image>().sprite = bruitage_on;
			// Activer les bruitages
			break;
		case 1:
			PlayerPrefs.SetInt (Constantes.BRUITAGE, 0);
			btn_bruitage.GetComponent<Image>().sprite = bruitage_off;
			// Désactiver les bruitages
			break;
		default:
			break;
		}
	}

	// Quand on clique sur le bouton Paramètre
	public void AffichageParam(){
		languetteAnim.enabled = true;
		
		bool isHidden = languetteAnim.GetBool("isHidden");
		languetteAnim.SetBool("isHidden", !isHidden);
	}
}