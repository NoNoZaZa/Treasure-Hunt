using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuizGeneratorSkript : MonoBehaviour
{

    public RoomGeneration raumGenerator;
    public GameObject quiz1;
    public GameObject quiz2;
    public GameObject quiz3;
    public GameObject quiz4;
    public GameObject drehrad;
    public GameObject endraumPrefab;
    public GameObject endraumWandPrefab;

    public List<Vector3> raumpositionenInQuizGenerator;
    int[] quizPositionenArray = new int[4];
    int zaehlVariable = 0;
    int anzahlQuizzes = 0;

    Vector3 positionWeitestEntfernterRaum = new Vector3(0,0,0);
    public Vector3 positionEndraum = new Vector3(0,0,0);
    //Hilfsvariable um im Wandgenerator zu übergeben, in welche Richtung der Endraum liegt um dort keine Wand zu generieren
    //1 = norden (-x Richtung), 2 = osten (+z Richtung), 3 = sueden (+x Richtung), 4 = westen (-z Richtung)
    public int ausrichtungDesEndraums = 0;
    //Hilfsvariable um im Wandgenerator einfacher die Wand zu finden, die nicht generiert werden soll
    public int zahlDesAmWeitestenEntferntenRaums = 0;

    // Use this for initialization
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        int[] quizPositionenArray = new int[4];
        Debug.Log("Das QuizGeneratorSkript wurde gestartet");

        int raumpositionenMaximum = 0;


        //if (raumGenerator.raumpositionen.Count == 0) {
        //    Debug.Log("Die Liste ist leer.");
        //} else
        //{
        //    Debug.Log("Die Liste ist nicht leer.");
        //}

        foreach (Vector3 raumposition in raumGenerator.raumpositionen)
        {
            //Debug.Log("Zugriff funktioniert");
            raumpositionenInQuizGenerator.Add(raumGenerator.raumpositionen.ElementAt(zaehlVariable));
            //Debug.Log(("RaumKoordinaten: " + (raumGenerator.raumpositionen.ElementAt(zaehlVariable))));
            float raumpositionenMaximumTemp = Mathf.Abs(raumpositionenInQuizGenerator.ElementAt(zaehlVariable).x) + Mathf.Abs(raumpositionenInQuizGenerator.ElementAt(zaehlVariable).z);
            //Debug.Log("raumpositionenMaximumTemp" + raumpositionenMaximumTemp);
            //Debug.Log("raumpositionenMaximum" + raumpositionenMaximum);
            if (raumpositionenMaximumTemp > raumpositionenMaximum) {
                raumpositionenMaximum = (int)raumpositionenMaximumTemp;
                positionWeitestEntfernterRaum = raumpositionenInQuizGenerator.ElementAt(zaehlVariable);
                zahlDesAmWeitestenEntferntenRaums = zaehlVariable;
                //Debug.Log("Position des am weitesten vom Anfangsraum entfernten Raum: " + positionWeitestEntfernterRaum);
            }
            zaehlVariable++;
        }

        drehrad.transform.position = new Vector3(positionWeitestEntfernterRaum.x, positionWeitestEntfernterRaum.y + 2, positionWeitestEntfernterRaum.z);

        positionEndraum = positionWeitestEntfernterRaum;
        positionEndraum = new Vector3(positionEndraum.x + 34, positionEndraum.y, positionEndraum.z);
        if (!raumpositionenInQuizGenerator.Contains(positionEndraum))
        {
            GameObject endraum = Instantiate(endraumPrefab, positionEndraum, Quaternion.identity);
            ausrichtungDesEndraums = 3;
        } else
        {
            positionEndraum = new Vector3(positionEndraum.x - 68, positionEndraum.y, positionEndraum.z);
            if (!raumpositionenInQuizGenerator.Contains(positionEndraum))
            {
                GameObject endraum = Instantiate(endraumPrefab, positionEndraum, Quaternion.identity);
                ausrichtungDesEndraums = 1;
            } else
            {
                positionEndraum = new Vector3(positionEndraum.x + 34, positionEndraum.y, positionEndraum.z + 34);
                if (!raumpositionenInQuizGenerator.Contains(positionEndraum))
                {
                    GameObject endraum = Instantiate(endraumPrefab, positionEndraum, Quaternion.identity);
                    ausrichtungDesEndraums = 2;
                }
                else {
                    positionEndraum = new Vector3(positionEndraum.x, positionEndraum.y, positionEndraum.z - 68);
                    if (!raumpositionenInQuizGenerator.Contains(positionEndraum))
                    {
                        GameObject endraum = Instantiate(endraumPrefab, positionEndraum, Quaternion.identity);
                        ausrichtungDesEndraums = 4;
                    }
                    else {
                        Debug.Log("Es wurde keine Position fuer den Endraum gefunden!");
                    }
                }
            }
        }
        
        

        while (anzahlQuizzes < 4)
        {
            int zufallszahl = zufallszahlGenerieren(0, 9);
            if (quizPositionenArray.Contains(zufallszahl) == false)
            {
                quizPositionenArray[anzahlQuizzes] = zufallszahl;
                //Debug.Log(quizPositionenArray[anzahlQuizzes]);

                anzahlQuizzes++;
            }            
        }

        if (!quizPositionenArray.Contains(0)) {
            int anfangsquiz = zufallszahlGenerieren(0, 3);
            quizPositionenArray[anfangsquiz] = 0;
        }

        Vector3 quiz1position = raumpositionenInQuizGenerator[quizPositionenArray[0]];
        Vector3 quiz2position = raumpositionenInQuizGenerator[quizPositionenArray[1]];
        Vector3 quiz3position = raumpositionenInQuizGenerator[quizPositionenArray[2]];
        Vector3 quiz4position = raumpositionenInQuizGenerator[quizPositionenArray[3]];
        
        quiz1.transform.position = quiz1position;
        quiz2.transform.position = quiz2position;
        quiz3.transform.position = quiz3position;
        quiz4.transform.position = quiz4position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    int zufallszahlGenerieren(int start, int ende)
    {
        //Range ist 1 bis 9 weil im 0ten Raum (dem Startraum) immer ein Quiz ist und die 9 inklusive der RandomRange ist
        int zufallszahl = Random.Range(start, ende);
        return zufallszahl;
    }

}

