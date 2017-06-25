using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {

	public GameObject departBall;
	public GameObject ballPrefab;

	private bool mouseIsOnCanon;
    private bool temoin;

	// Use this for initialization
	void Start () {
		mouseIsOnCanon = false;
        temoin = false;

    }
	
	// Update is called once per frame
	void Update() {
		// Le canon suis la souris
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (angle > Global.canonAngleMin && angle < Global.canonAngleMax){
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Shoot du ballon
            if (Input.GetMouseButtonUp (0) && Global.waitForShoot && !mouseIsOnCanon) {

				// On désactive le collider du canon afin de ne pas poser de 
				// problème avec la balle quand elle sort du canon
				GetComponent<PolygonCollider2D>().isTrigger = true;

				// Gestion du ballon
				Vector3 oldPosition = departBall.transform.position;
				GameObject newBall = Instantiate(ballPrefab, oldPosition, Quaternion.identity) as GameObject;

				// shoot
				Vector3 mousePosition = Input.mousePosition;
				mousePosition.z = 0.0f;
				mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
				Vector3 shootDirection = mousePosition - newBall.transform.position;
				float testMagnitude = new Vector2(shootDirection.x * Constantes.SPEED_BALL, shootDirection.y * Constantes.SPEED_BALL).magnitude;
				if (testMagnitude < Constantes.MIN_PUISSANCE_CANON){
					newBall.GetComponent<Rigidbody2D>().velocity = 
						new Vector2(shootDirection.x * Constantes.SPEED_BALL*Constantes.MULT_SPEED_BALL, shootDirection.y * Constantes.SPEED_BALL*Constantes.MULT_SPEED_BALL);
				}
				else{
					newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * Constantes.SPEED_BALL, shootDirection.y * Constantes.SPEED_BALL);
				}

				// Enregistre une tentative
				if (Global.listeScore[Global.levelActive] != 3){
					int tentativesTemp = PlayerPrefs.GetInt (Constantes.NOM_PLAYPREF_TENTATIVES + Global.levelActive);
					PlayerPrefs.SetInt (Constantes.NOM_PLAYPREF_TENTATIVES + Global.levelActive.ToString(), tentativesTemp + 1);
				}
				Global.waitForShoot = false;
			}
		}
	}

	// Une fois que la balle est sortie du canon on réactive le collider du canon
	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.tag.Equals (Constantes.BALL_TAG)) {
			GetComponent<PolygonCollider2D>().isTrigger = false;
		}
	}

	void OnMouseEnter(){
		mouseIsOnCanon = true;
	}

	void OnMouseExit(){
		mouseIsOnCanon = false;
	}
}
