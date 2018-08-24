using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandgenerator : MonoBehaviour {

    public RoomGeneration raumGenerator;
    public QuizGeneratorSkript quizGeneratorSkript;
    public GameObject wandPrefab;
    public GameObject wandEndraumPrefab;

    // Use this for initialization
    void Start () {
        Debug.Log("Der Wandgenerator wurde gestartet");

        int maximaleRaumzahl = raumGenerator.maximaleRaumzahlPublic;

        Vector3[,] wandpositionenArrayWandgenerator = raumGenerator.wandpositionenArray;
        Vector3 endraumPosition = quizGeneratorSkript.positionEndraum;
        int ausrichtungDesEndraums = quizGeneratorSkript.ausrichtungDesEndraums;
        int zahlDesAmWeitestenEntferntenRaums = quizGeneratorSkript.zahlDesAmWeitestenEntferntenRaums;

        int anzahlWaende = WaendeGenerieren(maximaleRaumzahl, wandpositionenArrayWandgenerator, endraumPosition, ausrichtungDesEndraums, zahlDesAmWeitestenEntferntenRaums);
        //Debug.Log("Anzahl platzierter Waende: " + anzahlWaende);
    }

    // Update is called once per frame
    void Update () {
		
	}

    int WaendeGenerieren(int maximaleRaumzahl, Vector3[,]wandpositionenArrayWandgenerator, Vector3 endraumposition, int ausrichtungDesEndraums, int zahlDesAmWeitestenEntferntenRaums)
    {
        int wandzumEndraum = (zahlDesAmWeitestenEntferntenRaums * 4) + ausrichtungDesEndraums - 1;
        wandpositionenArrayWandgenerator[wandzumEndraum, 1] = new Vector3(5, 0, 0);
        raumGenerator.tuerpositionen.Add(wandpositionenArrayWandgenerator[wandzumEndraum, 0]);
        //Debug.Log("wandposition der Wand neben dem Endraum: " + wandpositionenArrayWandgenerator[wandzumEndraum, 0]);

        int wandzaehler = 0;
        for (int j = 0; j < maximaleRaumzahl * 4; j++)
        {
            //Debug.Log("Wandgenerieren-Schleife wird durchlaufen zum " + j + "-(s)ten Mal");
            //Debug.Log("WandpositonenArray[" + j + "]: " + wandpositionenArray[j, 0]);
            //if (tuerpositionenArray[j, 0] != new Vector3(0, 0, 0)) {
            
            switch ((int)wandpositionenArrayWandgenerator[j, 1].magnitude)
            {
                case 1:
                    Instantiate(wandPrefab, wandpositionenArrayWandgenerator[j, 0] + new Vector3(0, 0, -2), Quaternion.Euler(0, 0, 0));
                    //Debug.Log("Wand erfolgreich platziert");
                    wandzaehler++;
                    break;
                case 2:
                    Instantiate(wandPrefab, wandpositionenArrayWandgenerator[j, 0] + new Vector3(-2, 0, 0), Quaternion.Euler(0, 90, 0));
                    //Debug.Log("Wand erfolgreich platziert");
                    wandzaehler++;
                    break;
                case 3:
                    Instantiate(wandPrefab, wandpositionenArrayWandgenerator[j, 0], Quaternion.Euler(0, 180, 0));
                    //Debug.Log("Wand erfolgreich platziert");
                    wandzaehler++;
                    break;
                case 4:
                    Instantiate(wandPrefab, wandpositionenArrayWandgenerator[j, 0], Quaternion.Euler(0, 270, 0));
                    //Debug.Log("Wand erfolgreich platziert");
                    wandzaehler++;
                    break;
                case 5:
                    //Tuer wuerde den Weg in einen Nachbarraum versperren, deswegen wird keine instantiiert.
                    //Debug.Log("Keine Wand platziert.");
                    break;
            }
            //}
        }

        //Debug.Log(ausrichtungDesEndraums);

        if (!raumGenerator.raumpositionen.Contains(endraumposition - new Vector3(34,0,0))) {
            Instantiate(wandEndraumPrefab, endraumposition + new Vector3(-16.475f, 2.9f, 0), Quaternion.identity);
            wandzaehler++;
        }
        if (!raumGenerator.raumpositionen.Contains(endraumposition - new Vector3(0, 0, -34)))
        {
            Instantiate(wandEndraumPrefab, endraumposition + new Vector3(0, 2.9f, 16.475f), Quaternion.Euler(0, 90, 0));
            wandzaehler++;
        }
        if (!raumGenerator.raumpositionen.Contains(endraumposition - new Vector3(-34, 0, 0)))
        {
            Instantiate(wandEndraumPrefab, endraumposition + new Vector3(16.475f, 2.9f, 0), Quaternion.Euler(0, 180, 0));
            wandzaehler++;
        }
        if (!raumGenerator.raumpositionen.Contains(endraumposition - new Vector3(0, 0, 34)))
        {
            Instantiate(wandEndraumPrefab, endraumposition + new Vector3(0, 2.9f, -16.475f), Quaternion.Euler(0, 270, 0));
            wandzaehler++;
        }

        return wandzaehler;
    }

}
