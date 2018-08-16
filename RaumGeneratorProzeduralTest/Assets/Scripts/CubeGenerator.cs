using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    public GameObject prefab;
    Vector3 raumposition;
    int success;
    int maximaleRaumzahl = 10;

    List<Vector3> raumpositionen = new List<Vector3>();
    Vector3 norden = new Vector3(-17, 0, 0);
    Vector3 osten = new Vector3(0, 0, 17);
    Vector3 sueden = new Vector3(17, 0, 0);
    Vector3 westen = new Vector3(0, 0, -17);

    //1 = norden, 2 = osten, 3 = sueden, 4 = westen
    int naechsteRaumPosition = 0;

	// Use this for initialization
	void Start () {

        while (success < maximaleRaumzahl) {
            success = success + RaumGenerieren();
            //Debug.Log(success);
        }
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    int RaumGenerieren()
    {
        int zufallszahl = Random.Range(0, 100);

        Debug.Log("zufallszahl: " + zufallszahl);
        Debug.Log("naechsteRaumPosition am Anfang: " + naechsteRaumPosition);


            if (zufallszahl > 25)
            {
                naechsteRaumPosition = 2;
                Debug.Log("naechsteRaumPosition nach > 25 Vergleich: " + naechsteRaumPosition);

                if (zufallszahl > 50)
                {
                    naechsteRaumPosition = 3;
                    Debug.Log("naechsteRaumPosition nach > 50 Vergleich: " + naechsteRaumPosition);

                    if (zufallszahl > 75)
                    {
                        naechsteRaumPosition = 4;
                        Debug.Log("naechsteRaumPosition nach > 75 Vergleich: " + naechsteRaumPosition);

                    }
                }
            }
            else if (zufallszahl < 25)
            {
                naechsteRaumPosition = 1;
                Debug.Log("naechsteRaumPosition nach < 25 Vergleich: " + naechsteRaumPosition);

            }
        
        switch (naechsteRaumPosition)
        {
            case 1:
                raumposition = new Vector3(raumposition.x + norden.x, raumposition.y + norden.y, raumposition.z + norden.z);
                break;
            case 2:
                raumposition = new Vector3(raumposition.x + osten.x, raumposition.y + osten.y, raumposition.z + osten.z);
                break;
            case 3:
                raumposition = new Vector3(raumposition.x + sueden.x, raumposition.y + sueden.y, raumposition.z + sueden.z);
                break;
            case 4:
                raumposition = new Vector3(raumposition.x + westen.x, raumposition.y + westen.y, raumposition.z + westen.z);
                break;

        }

        if (raumpositionen.Contains(raumposition))
        {
            //Raum existiert bereits an der Stelle, return 1 als "Fehler"
            return 0;
        }
        else {
            Instantiate(prefab, raumposition, Quaternion.identity);
            raumpositionen.Add(raumposition);
        }


        return 1;
    }

}
