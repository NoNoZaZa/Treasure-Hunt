using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Truhe : MonoBehaviour {

    public Animation anim;
    int keysCollected;
    GameManager gameManager;
    public bool offen = false;
    public Text scoreText;
    public GameObject scoreAnzeige;

    // Use this for initialization
    void Start () {
        anim = anim = GetComponent<Animation>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
    }
	
	// Update is called once per frame
	void Update () {
        keysCollected = gameManager.keysCollected;
        offen = GameObject.FindWithTag("MainCamera").GetComponent<Interaktion>().offen;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (keysCollected > 0)
        //    {
        //        anim.Play();
        //        offen = true;
        //        keysCollected--;
        //        GameManager.instance.Eingesetzt(keysCollected);
        //    }
        //}
        if (offen && keysCollected == 0)
        {
            StartCoroutine(StartCounter());
        }
    }

    //Quelle von IEnumerator: https://answers.unity.com/questions/1040630/do-something-for-10-sec.html
    private IEnumerator StartCounter()
    {
        float countDown = 8f;
        for (int i = 0; i < 10000; i++)
        {
            while (countDown >= 0)
            {
                Debug.Log(i++);
                countDown -= Time.smoothDeltaTime;
                yield return null;
            }
        }
        scoreAnzeige.SetActive(true);
        scoreText.text = "SPIELENDE\n\nDrücke ESC zum Verlassen.";
    }

    //private void OnMouseUp()
    //{
    //    if(keysCollected > 0)
    //    {
    //        anim.Play();
    //        offen++;
    //        keysCollected--;
    //        GameManager.instance.Eingesetzt(keysCollected);
    //    }
    //}
}
