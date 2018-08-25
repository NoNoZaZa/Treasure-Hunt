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
    Vector3 tuerpositionNeu;

    List<Vector3> tuerpositionenNeu = new List<Vector3>();

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

        for(int i = 0; i < tuerpositionen.Count/2; i++) {
            if (xKoordinatenRaeume.Contains(tuerpositionen[i].x) || xKoordinatenRaeume.Contains(tuerpositionen[i].x - 2))
            {
                Vector3 tuerpositionNeu = tuerpositionen[i];
                if (!xKoordinatenRaeume.Contains(tuerpositionNeu.x)) {
                    tuerpositionNeu = new Vector3(tuerpositionNeu.x - 2, tuerpositionNeu.y, tuerpositionNeu.z);
                } 
                tuer = Instantiate(tuer, tuerpositionNeu, Quaternion.Euler(0, 90, 0));
                tuerpositionenNeu.Add(tuerpositionNeu);
                //Debug.Log("TuerpositionX: " + tuerpositionNeu.x);
            }
            else {
                Vector3 tuerpositionNeu = tuerpositionen[i];
                if (zKoordinatenRaeume.Contains(tuerpositionen[i].z - 2)) {
                    tuerpositionNeu = new Vector3(tuerpositionNeu.x, tuerpositionNeu.y, tuerpositionNeu.z - 2);
                }

                tuer = Instantiate(tuer, tuerpositionNeu, Quaternion.identity);
                tuerpositionenNeu.Add(tuerpositionNeu);
                //Debug.Log("TuerpositionX: " + tuerpositionNeu.x);
                //Debug.Log("Nicht-gedrehte Tuerpositionen: " + tuerpositionNeu);
            }

            //if (quizgenerator.quizpositionen.Contains(tuerpositionNeu)) {

            //}

            bool gehoertZuRaumMitQuiz = false;

            for(int j = 0; j < quizgenerator.quizPositionenArray.Length; j++)
            {
                //Debug.Log("QuizpositionX " + quizposition.x + " TuerpositionX " + tuerpositionenNeu[zaehlvariable].x);
                //Debug.Log("QuizpositionZ " + quizposition.z + " TuerpositionZ " + tuerpositionenNeu[zaehlvariable].z);

                if (quizgenerator.quizPositionenArray[j] == tuerpositionen[i + 1].x)
                {
                    gehoertZuRaumMitQuiz = true;
                    break;
                }
                else {
                    //Debug.Log("tuerpositionenNeu[zaehlvariable]" + tuerpositionenNeu[zaehlvariable]);
                }

                //Debug.Log("Quizzuordnung wird ueberprueft");
                //Debug.Log("gehoertZuRaumMitQuiz " + gehoertZuRaumMitQuiz);

            }

            if (gehoertZuRaumMitQuiz)
            {
                tuer.AddComponent<TuerCollision>().unlockable = false;
                Debug.Log("Raum wurde auf unlockable = false gesetzt");
            }
            else
            {
                tuer.AddComponent<TuerCollision>().unlockable = true;
            }

            zaehlvariable++;
            i++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
