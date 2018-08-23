using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Schatzkammer : MonoBehaviour
{
    GameManager gameManager;
    int keysCollected;
    public Text scoreText;
    public GameObject scoreAnzeige;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        keysCollected = gameManager.keysCollected;
        if (keysCollected == 0)
        {
            scoreAnzeige.SetActive(true);
            scoreText.text = "SPIELENDE\n\nDrücke ESC zum Verlassen.";


        }
    }

}
