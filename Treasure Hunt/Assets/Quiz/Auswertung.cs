using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auswertung : MonoBehaviour {

    public GameObject drehrad;
    GameManager gameManager;
    int keysCollected;
    public Vector3 radPos1, radPos2, radPos3, radPos4;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        keysCollected = gameManager.keysCollected;
        if (keysCollected == 1)
        {
            Debug.Log("Schatzkammer öffnet sich, 1Taler");
            GameObject drehschloss = Instantiate(drehrad, radPos1, Quaternion.identity);
            drehschloss.SetActive(true);
        }
        else if (keysCollected == 2)
        {
            Debug.Log("Schatzkammer öffnet sich, 3.Platz");
            GameObject drehschloss1 = Instantiate(drehrad, radPos1, Quaternion.identity);
            drehschloss1.SetActive(true);
            GameObject drehschloss2 = Instantiate(drehrad, radPos2, Quaternion.identity);
            drehschloss2.SetActive(true);
        }
        else if (keysCollected == 3)
        {
            Debug.Log("Schatzkammer öffnet sich, 2.Platz");
            GameObject drehschloss1 = Instantiate(drehrad, radPos1, Quaternion.identity);
            drehschloss1.SetActive(true);
            GameObject drehschloss2 = Instantiate(drehrad, radPos2, Quaternion.identity);
            drehschloss2.SetActive(true);
            GameObject drehschloss3 = Instantiate(drehrad, radPos3, Quaternion.identity);
            drehschloss3.SetActive(true);
        }
        else if (keysCollected == 4)
        {
            Debug.Log("Schatzkammer öffnet sich, Hauptgewinn");
            GameObject drehschloss1 = Instantiate(drehrad, radPos1, Quaternion.identity);
            drehschloss1.SetActive(true);
            GameObject drehschloss2 = Instantiate(drehrad, radPos2, Quaternion.identity);
            drehschloss2.SetActive(true);
            GameObject drehschloss3 = Instantiate(drehrad, radPos3, Quaternion.identity);
            drehschloss3.SetActive(true);
            GameObject drehschloss4 = Instantiate(drehrad, radPos4, Quaternion.identity);
            drehschloss4.SetActive(true);
        }
        else
        {
            Debug.Log("Du hast leider keine Schlüssel und kannst so die Schatzkammer nicht öffnen :(");
        }

    }
}
