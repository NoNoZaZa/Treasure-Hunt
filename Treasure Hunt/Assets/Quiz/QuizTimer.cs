using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizTimer : MonoBehaviour
{
    public float zeitGesamt;
    public float timer;
    public Text countDownText;
    public Text winText;
    public bool hasWon = false;
    public GameObject quiz;
    public bool solved = false;
    private AudioSource src;


    // Use this for initialization
    void Start()
    {
        timer = zeitGesamt;
        winText.text = "";
        src = this.GetComponent<AudioSource>();
        src.loop = true;
        src.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        countDownText.text = timer.ToString("0.00");

        if (timer < 0)
        {
            countDownText.enabled = false;
            Destroy(quiz.gameObject);
            if (hasWon == false)
            {
                winText.text = "Verloren";
                solved = true;
                GameObject.FindGameObjectWithTag("Tuer").GetComponent<TuerAuf>().solved = solved;
            } 
        }

        if (hasWon == true && timer>0)
        {
            winText.text = "Gewonnen!";
            solved = true;
            GameObject.FindGameObjectWithTag("Tuer").GetComponent<TuerAuf>().solved = solved;
            timer = 0;
        }

        if (timer <= -3)
        {
            winText.text = "";            
            Destroy(this.gameObject);
        }
        if(timer <= 0)
        {
            src.Stop();
        }
    }
}