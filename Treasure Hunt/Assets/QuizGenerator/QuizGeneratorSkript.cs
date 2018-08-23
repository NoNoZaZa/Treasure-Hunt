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

    public List<Vector3> raumpositionenInQuizGenerator;
    int[] quizPositionenArray = new int[3];
    int zaehlVariable = 0;
    int anzahlQuizzes = 0;

    // Use this for initialization
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        int[] quizPositionenArray = { 0, 0, 0 };
        Debug.Log("Das QuizGeneratorSkript wurde gestartet");

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
            zaehlVariable++;
        }

        while (anzahlQuizzes < 3)
        {
            int zufallszahl = zufallszahlGenerieren();
            if(quizPositionenArray.Contains(zufallszahl) == false)
            {
                quizPositionenArray[anzahlQuizzes] = zufallszahl;
                Debug.Log(quizPositionenArray[anzahlQuizzes]);

                anzahlQuizzes++;

            }
        }

        Vector3 quiz2position = raumpositionenInQuizGenerator[quizPositionenArray[0]];
        Vector3 quiz3position = raumpositionenInQuizGenerator[quizPositionenArray[1]];
        Vector3 quiz4position = raumpositionenInQuizGenerator[quizPositionenArray[2]];
        
        quiz1.transform.position = new Vector3(0,0,0);
        quiz2.transform.position = quiz2position;
        quiz3.transform.position = quiz3position;
        quiz4.transform.position = quiz4position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    int zufallszahlGenerieren()
    {
        //Range ist 1 bis 9 weil im 0ten Raum (dem Startraum) immer ein Quiz ist und die 9 inklusive der RandomRange ist
        int zufallszahl = Random.Range(1, 9);
        return zufallszahl;
    }

}

