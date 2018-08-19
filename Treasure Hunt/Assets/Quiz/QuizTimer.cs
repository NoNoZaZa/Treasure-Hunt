﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizTimer : MonoBehaviour
{
    public float zeitGesamt;
    public float timer = 0f;
    public Text countDownText;
    public Text winText;
    public bool hasWon = false;



    // Use this for initialization
    void Start()
    {
        timer = zeitGesamt;
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

            timer -= Time.deltaTime;

            if (timer < 0)
            {
                countDownText.enabled = false;
                if( hasWon == false)
                {
                  winText.text = "Verloren";
                } 
            }

            countDownText.text = timer.ToString("0.00");

        if (hasWon == true)
        {
            winText.text = "Gewonnen!";
            timer = 0;
            
        }

        if (timer <= -3)
        {
            Destroy(this);
        }
    }
}