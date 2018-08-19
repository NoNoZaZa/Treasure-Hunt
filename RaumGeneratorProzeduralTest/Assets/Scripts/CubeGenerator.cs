using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    public GameObject raumPrefab;
    public GameObject tuerPrefab;
    Vector3 raumposition = new Vector3(0, 1, 0);
    int successRaeume;
    int successTueren;
    static int maximaleRaumzahl = 10;
    
    int hilfsvariableNachbarfindung = 0;
    
    //x = 0 speichert die Position der Tueren, x = 1 speichert die durch die Länge des Vektors codierte Rotation der Tueren
    Vector3[,] tuerpositionenArray = new Vector3[maximaleRaumzahl * 4, 2];

    List<Vector3> raumpositionen = new List<Vector3>();
    Vector3 norden = new Vector3(-17, 0, 0);
    Vector3 osten = new Vector3(0, 0, 17);
    Vector3 sueden = new Vector3(17, 0, 0);
    Vector3 westen = new Vector3(0, 0, -17);

    //1 = norden, 2 = osten, 3 = sueden, 4 = westen
    int naechsteRaumPosition = 0;

	// Use this for initialization
	void Start () {

        while (successRaeume < maximaleRaumzahl) {
            successRaeume = successRaeume + RaumGenerieren();
            //Debug.Log(success);
        }

        //Raumpositionen durchgehen und Raeume mit Nachbarraeumen finden
        foreach (var raumposition in raumpositionen)
        {
            if (raumpositionen.Contains(raumposition + norden))
            {
                tuerpositionenArray[hilfsvariableNachbarfindung, 1] = new Vector3(5, 0, 0);
                Debug.Log("Raum Nummer " + hilfsvariableNachbarfindung + " hat einen Nachbarn in -x Richtung!");
            }
            if (raumpositionen.Contains(raumposition + osten))
            {
                tuerpositionenArray[hilfsvariableNachbarfindung + 1, 1] = new Vector3(5, 0, 0);
            }
            if (raumpositionen.Contains(raumposition + sueden))
            {
                tuerpositionenArray[hilfsvariableNachbarfindung + 2, 1] = new Vector3(5, 0, 0);
            }
            if (raumpositionen.Contains(raumposition + westen))
            {
                tuerpositionenArray[hilfsvariableNachbarfindung + 3, 1] = new Vector3(5, 0, 0);
            }

            hilfsvariableNachbarfindung = hilfsvariableNachbarfindung + 4;
        }
            successTueren = successTueren + TuerenGenerieren();
        Debug.Log("Platzieren der Tueren war erfolgreich, es wurden " + successTueren + " Tueren platziert.");    

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
            //Raum existiert bereits an der Stelle, return 0 als "Fehler"
            return 0;
        }
        else {
            if (raumpositionen.Contains(new Vector3(0, 1, 0)))
            {
                Instantiate(raumPrefab, raumposition, Quaternion.identity);
                raumpositionen.Add(raumposition);
            }
            else {
                //Sicherstellen, dass ein Raum an den Ursprungskoordinaten existiert
                raumposition = new Vector3(0, 1, 0);
                Instantiate(raumPrefab, raumposition, Quaternion.identity);
                raumpositionen.Add(raumposition);
            }
            

            int hilfsvariableTuerpositionen = successRaeume * 4;

            Vector3 tuerpositionNorden = raumposition + new Vector3(-8, 0, 1);
            Vector3 tuerpositionOsten = raumposition + new Vector3(1, 0, 8);
            Vector3 tuerpositionSueden = raumposition + new Vector3(8, 0, 1);
            Vector3 tuerpositionWesten = raumposition + new Vector3(1, 0, -8);

            tuerpositionenArray[hilfsvariableTuerpositionen, 0] = tuerpositionNorden;
            tuerpositionenArray[hilfsvariableTuerpositionen, 1] = new Vector3(1, 0, 0);

            tuerpositionenArray[hilfsvariableTuerpositionen + 1, 0] = tuerpositionOsten;
            tuerpositionenArray[hilfsvariableTuerpositionen + 1, 1] = new Vector3(2, 0, 0);

            tuerpositionenArray[hilfsvariableTuerpositionen + 2, 0] = tuerpositionSueden;
            tuerpositionenArray[hilfsvariableTuerpositionen + 2, 1] = new Vector3(3, 0, 0);

            tuerpositionenArray[hilfsvariableTuerpositionen + 3, 0] = tuerpositionWesten;
            tuerpositionenArray[hilfsvariableTuerpositionen + 3, 1] = new Vector3(4, 0, 0);


        }


        return 1;
    }

    int TuerenGenerieren() {
        int tuerenzaehler = 0;
        for (int j = 0; j < maximaleRaumzahl * 4; j++) {
            Debug.Log("Tuergenerieren-Schleife wird durchlaufen zum " + j + "-(s)ten Mal");
            Debug.Log("TuerpositonenArray[" + j + "]: " + tuerpositionenArray[j, 0]);
            //if (tuerpositionenArray[j, 0] != new Vector3(0, 0, 0)) {
                switch ((int)tuerpositionenArray[j, 1].magnitude) {
                    case 1:
                        Instantiate(tuerPrefab, tuerpositionenArray[j, 0] + new Vector3(0, 0, -2), Quaternion.Euler(0, 0, 0));
                        Debug.Log("Tuer erfolgreich platziert");
                        tuerenzaehler++;
                        break;
                    case 2:
                        Instantiate(tuerPrefab, tuerpositionenArray[j, 0] + new Vector3(-2, 0, 0), Quaternion.Euler(0, 90, 0));
                        Debug.Log("Tuer erfolgreich platziert");
                        tuerenzaehler++;
                        break;
                    case 3:
                        Instantiate(tuerPrefab, tuerpositionenArray[j, 0], Quaternion.Euler(0, 180, 0));
                        Debug.Log("Tuer erfolgreich platziert");
                        tuerenzaehler++;
                        break;
                    case 4:
                        Instantiate(tuerPrefab, tuerpositionenArray[j, 0], Quaternion.Euler(0, 270, 0));
                        Debug.Log("Tuer erfolgreich platziert");
                        tuerenzaehler++;
                        break;
                    case 5:
                        //Tuer wuerde den Weg in einen Nachbarraum versperren, deswegen wird keine instantiiert.
                        Debug.Log("Keine Tuer platziert.");
                        break;
                }
            //}
        }
        return tuerenzaehler;
    }

}
