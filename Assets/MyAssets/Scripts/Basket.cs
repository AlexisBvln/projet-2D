using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

    // Quand le ballon attérit dans le panier
    // On sauvegarde le score et on affiche le panel
    void OnTriggerEnter2D(Collider2D col){

        if (!Global.IsWrongWay)
        {
            if (col.gameObject.tag.Equals(Constantes.BALL_TAG) && !Global.isWin)
            {
                if (Global.point == 3)
                {
                    Global.isWin = true;
                    GestionLevel.SaveLevel(Global.levelActive, Global.point);
                }
                else if (Global.point > 0)
                {
                    Global.isWin = false;
                    GestionLevel.SaveLevel(Global.levelActive, Global.point);
                }
                else
                {
                    Global.isWin = false;
                    GestionLevel.affichePanelScore();
                }
            }
        }

    }
}
