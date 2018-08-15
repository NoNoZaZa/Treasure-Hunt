using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Interaktion interaktion;
    public float zeitGesamt = 10f;
    float timerNeu = 5f;
    public float timer = 0f;
    public float timerNeuAnzeige = 0f;
    public Text countDownText;
    public Text winText;
    public GameObject quiz3Cube;


    // Use this for initialization
    void Start()
    {
        timer = zeitGesamt;
        timerNeuAnzeige = timerNeu;
        winText.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        if (quiz3Cube.activeInHierarchy)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                gameObject.SetActive(false);
                countDownText.enabled = false;
            }

            countDownText.text = timer.ToString("0.00");
        }

        if (interaktion.zaehlercubes == 6 && timer > 0)
        {
            winText.text = "Gewonnen!";

            timerNeuAnzeige -= Time.deltaTime;
            if (timerNeuAnzeige < 0)
            {
                winText.enabled = false;

            }

        }
        //abbruchVerloren();
    }

    //Quiz3
    //void abbruchGewonnen()
    //{

    //}

        //void abbruchVerloren() {
        //    if (interaktion.zaehlercubes < 6 && timer < 0)
        //    {
        //        winText.text = "Verloren";
        //    }

        //}
    }
