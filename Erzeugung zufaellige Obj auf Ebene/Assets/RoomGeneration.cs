using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const int HoechstanzahlRaeume = 10;
    public const int Seed1 = 42;
}

public class RoomGeneration : MonoBehaviour
{

    public GameObject RaumMitVierTueren;
    public GameObject RaumMitDreiTueren;
    public GameObject RaumMitNebeneinanderLiegendenTueren;
    public GameObject RaumMitHintereinanderLiegendenTueren;
    public GameObject RaumMitEinerTuer;
    public GameObject[] raumArtenArray;

    public char[,] generierteRaeume = new char[Constants.HoechstanzahlRaeume, Constants.HoechstanzahlRaeume];


    public Vector3 center;
    public Vector3 size;
    public bool randomizeSeed = true;

    public int raumzaehler = 0;
    public int vorherigeRaumArt;
    public int vorherigeRaumAusrichtung;

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
        //while (raumzaehler < Constants.HoechstanzahlRaeume) {
        SpawnRoom();
        //SpawnRoom();

        raumzaehler++;
        //}
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
        Instantiate(raumArtenArray[zufallszahlRaumArt], pos, Quaternion.identity);
        //Instantiate(raumArtenArray[4], pos, Quaternion.Euler(0, 0, 0));
        vorherigeRaumAusrichtung = zufallszahlRaumAusrichtung;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

}
