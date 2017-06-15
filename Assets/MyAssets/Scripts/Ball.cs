using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public AudioClip lowRebound;

	/********************************************************************************************
	 *  RAMASSAGE DE PIECE
	 *******************************************************************************************/
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag.Equals(Constantes.PIECE_TAG) && !Global.isWin){
			Global.point ++;
			coll.gameObject.SetActive(false);
		}
	}

	/********************************************************************************************
	 *  GESTION DE L'AUDIO
	 *******************************************************************************************/
	void OnCollisionEnter2D(Collision2D coll) {
		//Debug.Log ("SON");
		GetComponent<AudioSource>().PlayOneShot(lowRebound);
	}
}
