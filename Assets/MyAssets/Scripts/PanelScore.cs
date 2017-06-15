using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PanelScore : MonoBehaviour {

	public GameObject pieceWinOr1;
	public GameObject pieceWinOr2;
	public GameObject pieceWinOr3;
	public GameObject pieceLooseOr1;
	public GameObject pieceLooseOr2;
	public GameObject pieceLooseOr3;

	public GameObject buttonRestart;
	public GameObject buttonLevels;
	public GameObject buttonNext;

	void Awake () {
		// Inscrit le numéro du level dans le GUI
		GameObject guiTextTitre = GameObject.Find(Constantes.NAME_TITRE_GUI_LEVEL);
		Text titre = guiTextTitre.GetComponent<Text>();
		titre.text = Langues.txt_titre[Global.langueKey] + Global.levelActive;

		// Ecrit dans les boutons
		buttonRestart.GetComponent<Text>().text = Langues.btn_restart [Global.langueKey];
		buttonLevels.GetComponent<Text>().text = Langues.btn_levels [Global.langueKey];
		buttonNext.GetComponent<Text>().text = Langues.btn_next [Global.langueKey];
	}

	void Start(){
		GameObject guiTextWin = GameObject.Find (Constantes.NAME_TITRE_GUI_WIN);
		Text titre = guiTextWin.GetComponent<Text> ();

		if (Global.isWin && Global.levelActive != Global.nombreLevel) {
			titre.text = Langues.txt_win[Global.langueKey];
			GameObject.Find("next").SetActive(true);
		} else {
			titre.text = Langues.txt_loose[Global.langueKey];
			GameObject.Find("next").SetActive(false);
		}

		switch (Global.point) {
		case 1 : 
			pieceWinOr1.SetActive(true);
			pieceWinOr2.SetActive(false);
			pieceWinOr3.SetActive(false);
			pieceLooseOr1.SetActive (false);
			pieceLooseOr2.SetActive (true);
			pieceLooseOr3.SetActive (true);
			break;
		case 2 : 
			pieceWinOr1.SetActive(true);
			pieceWinOr2.SetActive(true);
			pieceWinOr3.SetActive(false);
			pieceLooseOr1.SetActive (false);
			pieceLooseOr2.SetActive (false);
			pieceLooseOr3.SetActive (true);
			break;
		case 3 : 
			pieceWinOr1.SetActive(true);
			pieceWinOr2.SetActive(true);
			pieceWinOr3.SetActive(true);
			pieceLooseOr1.SetActive (false);
			pieceLooseOr2.SetActive (false);
			pieceLooseOr3.SetActive (false);
			break;
		default:
			pieceLooseOr1.SetActive (true);
			pieceLooseOr2.SetActive (true);
			pieceLooseOr3.SetActive (true);
			pieceWinOr1.SetActive (false);
			pieceWinOr2.SetActive (false);
			pieceWinOr3.SetActive (false);
			break;
		}
	}
}
