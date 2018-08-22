using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject scoreTextObj;
    int keysCollected = 0;
    Text scoreT;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        scoreT = scoreTextObj.GetComponent<Text>();
        scoreT.text = "Schlüssel: " + keysCollected.ToString();
    }

    public void Collect(int passedValue, GameObject passedObj)
    {
        //Key "zerstören"
        passedObj.GetComponent<Renderer>().enabled = false;
        passedObj.GetComponent<Collider>().enabled = false;
        Destroy(passedObj, 1.0f);
        //Score erhöhen
        keysCollected = keysCollected + passedValue;
        scoreT.text = "Schlüssel: " + keysCollected.ToString();
    }


}
