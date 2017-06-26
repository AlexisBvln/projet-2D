using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerBas : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals(Constantes.BALL_TAG))
        {
            Global.IsWrongWay = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals(Constantes.BALL_TAG))
        {
            Global.IsWrongWay = false;
        }

    }
}
