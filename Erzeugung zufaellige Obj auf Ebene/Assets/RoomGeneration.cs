﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const int HoechstanzahlRaeume = 10;
    public const int Seed1 = 42;
    public const int raumgroesse = 17;
}

public class RoomGeneration : MonoBehaviour
{

    public GameObject RaumMitVierTueren;
    public GameObject RaumMitDreiTueren;
    public GameObject RaumMitNebeneinanderLiegendenTueren;
    public GameObject RaumMitHintereinanderLiegendenTueren;
    public GameObject RaumMitEinerTuer;
    private GameObject[] raumArtenArray;

    private char[,] generierteRaeume;
    private char[,] raumPositionen;
    public List<Vector3> tuerpositionen;


    private Vector3 center;
    private Vector3 size;
    public bool randomizeSeed = true;

    private int raumzaehler = 0;
    private int vorherigeRaumArt;
    private int vorherigeRaumAusrichtung;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < Constants.HoechstanzahlRaeume; i++)
        {
            for (int j = 0; j < Constants.HoechstanzahlRaeume; j++)
            {
                generierteRaeume[i, j] = 'o';
            }
        }

        raumArtenArray = new GameObject[5];
        raumArtenArray[0] = RaumMitVierTueren;
        raumArtenArray[1] = RaumMitHintereinanderLiegendenTueren;
        raumArtenArray[2] = RaumMitDreiTueren;
        raumArtenArray[3] = RaumMitNebeneinanderLiegendenTueren;
        raumArtenArray[4] = RaumMitEinerTuer;

        center = new Vector3(0, -1, 0);
        size = new Vector3();

        if (randomizeSeed == false)
        {
            Random.InitState(Constants.Seed1);
        }

        raumPositionen = new char[Constants.HoechstanzahlRaeume + (Constants.HoechstanzahlRaeume / 2), Constants.HoechstanzahlRaeume + (Constants.HoechstanzahlRaeume / 2)];
        generierteRaeume = new char[Constants.HoechstanzahlRaeume, Constants.HoechstanzahlRaeume];
        tuerpositionen = new List<Vector3>();

        while (raumzaehler < Constants.HoechstanzahlRaeume) {
        SpawnRoom();
        
        raumzaehler++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRoom()
    {
        //Zufallszahl um zu bestimmen, welcher Raum als nächstes platziert wird 
        //Raum 1: Raum mit Vier Tueren
        //Raum 2: Raum mit hintereinanderliegenden Tueren
        //Raum 3: Raum mit Drei Tueren
        //Raum 4: Raum mit nebeneinanderliegenden Tueren
        //Raum 5: Raum mit einer Tuer (quasi Dead End)

        int zufallszahlRaumArt = Random.Range(1, 5);
        vorherigeRaumArt = zufallszahlRaumArt;

        //Zufallszahl um die Positionierung des Raums festzulegen
        //Oben = 1, Rechts = 2, Unten = 3, Links = 4
        int zufallszahlRaumAusrichtung = Random.Range(1, 4);

        switch (vorherigeRaumArt)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }


        //Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x /2), -1, Random.Range(-size.z /2, size.z / 2));
        Vector3 pos = center;
        Instantiate(raumArtenArray[4], pos, Quaternion.identity);
        //Instantiate(raumArtenArray[0], pos2, Quaternion.Euler(0, 0, 0));
        //Instantiate(raumArtenArray[0], pos + new Vector3(0,0, -Constants.raumgroesse), Quaternion.identity);
        //Instantiate(raumArtenArray[0], pos + new Vector3(-Constants.raumgroesse, 0, 0), Quaternion.identity);
        //Instantiate(raumArtenArray[0], pos + new Vector3(Constants.raumgroesse, 0, 0), Quaternion.identity);
        //Instantiate(raumArtenArray[0], pos + new Vector3(0, 0, Constants.raumgroesse), Quaternion.identity);



        vorherigeRaumAusrichtung = zufallszahlRaumAusrichtung;
    }

    int CreateDoor(float xKoordinate, float zKoordinate) {
        Vector3 neuePosition = new Vector3(xKoordinate, -0.1f, zKoordinate);
        tuerpositionen.Add(neuePosition);
        return (0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

}
