using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prediction : MonoBehaviour {

    protected Vector2 velocity;

    private float gravityModifier = 1.2f;
    private GameObject[] listDotClone;
    private int nbDePoint = 500;

    // Use this for initialization
    void Start()
    {
        listDotClone = new GameObject[nbDePoint];

        // Création de tous les points au même endroit avec des noms différents
        for (int i = 0; i < nbDePoint; i++)
        {
            GameObject dotClone = Resources.Load("dotPrediction") as GameObject;
            dotClone.name = "dotClone_" + i;
            dotClone = Instantiate(dotClone, this.transform.position, Quaternion.identity) as GameObject;
            listDotClone[i] = dotClone;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0.0f;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 shootDirection = mousePosition - this.transform.position;
        float testMagnitude = new Vector2(shootDirection.x * Constantes.SPEED_BALL, shootDirection.y * Constantes.SPEED_BALL).magnitude;
        if (testMagnitude < Constantes.MIN_PUISSANCE_CANON)
        {
            velocity = new Vector2(shootDirection.x * Constantes.SPEED_BALL * Constantes.MULT_SPEED_BALL, shootDirection.y * Constantes.SPEED_BALL * Constantes.MULT_SPEED_BALL);
        }
        else
        {
            velocity = new Vector2(shootDirection.x * Constantes.SPEED_BALL, shootDirection.y * Constantes.SPEED_BALL);
        }

        Vector2 positionStep = transform.position;

        for (int i = 0; i < listDotClone.Length; i++)
        {
            velocity += gravityModifier * Physics2D.gravity;
            positionStep += velocity * Time.deltaTime;

            GameObject dotPredictionTemp = GameObject.Find(listDotClone[i].name);
            dotPredictionTemp.GetComponent<Transform>().position = positionStep;
        }
    }
}
