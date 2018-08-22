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

        while (anzahlQuizzes < 4)
        {
            int zufallszahl = zufallszahlGenerieren();
            if(quizPositionenArray[zufallszahl] == 0)
            {
                quizPositionenArray[zufallszahl] = zufallszahl;
                anzahlQuizzes++;
            }
        }

        quiz1.transform.position();

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

