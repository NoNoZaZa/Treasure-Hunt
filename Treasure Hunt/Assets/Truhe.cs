using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truhe : MonoBehaviour {

    public Animation anim;
    int keysCollected;
    GameManager gameManager;
    int offen;

    // Use this for initialization
    void Start () {
        anim = anim = GetComponent<Animation>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        keysCollected = gameManager.keysCollected;
    }
	
	// Update is called once per frame
	void Update () {

        if (offen == 4)
        {
            Debug.Log("ENDE!");
        }


    }

    private void OnMouseUp()
    {
        if(keysCollected > 0)
        {
            anim.Play();
            offen++;
            keysCollected--;
            GameManager.instance.Eingesetzt(keysCollected);
        }
    }
 }
