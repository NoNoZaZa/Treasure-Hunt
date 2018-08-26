﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuerGenerator : MonoBehaviour {

    public RoomGeneration raumgenerator;
    public QuizGeneratorSkript quizgenerator;
    public GameObject tuerprefab;

    List<float> xKoordinatenRaeume = new List<float>();
    List<float> zKoordinatenRaeume = new List<float>();
    int zaehlvariable = 0;
    Vector3 tuerpositionNeu;

    List<Vector3> tuerpositionenNeu = new List<Vector3>();
    List<GameObject> tuerListe = new List<GameObject>();

    // Use this for initialization
    void Start () {

        foreach (var raumposition in raumgenerator.raumpositionen) {
            xKoordinatenRaeume.Add(raumposition.x);
            zKoordinatenRaeume.Add(raumposition.z);
            //Debug.Log("xKoordinaten der Raeume: " + raumposition.x);
            //Debug.Log("zKoordinaten der Raeume: " + raumposition.z);
        }

        Debug.Log("TuerGenerator gestartet");
		List<Vector3> tuerpositionen = raumgenerator.tuerpositionen;

        for(int i = 0; i < tuerpositionen.Count; i++) {
            if (xKoordinatenRaeume.Contains(tuerpositionen[i].x) || xKoordinatenRaeume.Contains(tuerpositionen[i].x - 2))
            {
                Vector3 tuerpositionNeu = tuerpositionen[i];
                if (!xKoordinatenRaeume.Contains(tuerpositionNeu.x)) {
                    tuerpositionNeu = new Vector3(tuerpositionNeu.x - 2, tuerpositionNeu.y, tuerpositionNeu.z);
                } 
                GameObject tuer = Instantiate(tuerprefab, tuerpositionNeu, Quaternion.Euler(0, 90, 0));
                tuerListe.Add(tuer);
                tuerpositionenNeu.Add(tuerpositionNeu);
                //Debug.Log("TuerpositionX: " + tuerpositionNeu.x);
            }
            else {
                Vector3 tuerpositionNeu = tuerpositionen[i];
                if (zKoordinatenRaeume.Contains(tuerpositionen[i].z - 2)) {
                    tuerpositionNeu = new Vector3(tuerpositionNeu.x, tuerpositionNeu.y, tuerpositionNeu.z - 2);
                }

                GameObject tuer = Instantiate(tuerprefab, tuerpositionNeu, Quaternion.identity);
                tuerListe.Add(tuer);
                tuerpositionenNeu.Add(tuerpositionNeu);
                //Debug.Log("TuerpositionX: " + tuerpositionNeu.x);
                //Debug.Log("Nicht-gedrehte Tuerpositionen: " + tuerpositionNeu);
            }

            //if (quizgenerator.quizpositionen.Contains(tuerpositionNeu)) {

            //}

            

            zaehlvariable++;
            i++;
        }

        foreach (var GameObject in tuerListe) {
            if (zKoordinatenRaeume.Contains(GameObject.transform.position.z))
            {
                GameObject.AddComponent<TuerCollisionZ>();
            }
            else {
                GameObject.AddComponent<TuerCollision>();
            }
        }

        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
