using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuerGenerator : MonoBehaviour {

    public RoomGeneration raumgenerator;
    public QuizGeneratorSkript quizgenerator;
    public GameObject tuer;

    List<float> xKoordinatenRaeume = new List<float>();
    List<float> zKoordinatenRaeume = new List<float>();
    int zaehlvariable = 0;

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

        foreach (var tuerposition in tuerpositionen) {
            if (xKoordinatenRaeume.Contains(tuerposition.x) || xKoordinatenRaeume.Contains(tuerposition.x - 2))
            {
                Vector3 tuerpositionNeu = tuerposition;
                if (!xKoordinatenRaeume.Contains(tuerpositionNeu.x)) {
                    tuerpositionNeu = new Vector3(tuerpositionNeu.x - 2, tuerpositionNeu.y, tuerpositionNeu.z);
                } 
                tuer = Instantiate(tuer, tuerpositionNeu, Quaternion.Euler(0, 90, 0));
            }
            else {
                Vector3 tuerpositionNeu = tuerposition;
                if (zKoordinatenRaeume.Contains(tuerposition.z - 2)) {
                    tuerpositionNeu = new Vector3(tuerpositionNeu.x, tuerpositionNeu.y, tuerpositionNeu.z - 2);
                }

                tuer = Instantiate(tuer, tuerpositionNeu, Quaternion.identity);
                //Debug.Log("Nicht-gedrehte Tuerpositionen: " + tuerposition);
            }

            tuer.AddComponent<TuerCollision>();

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
