using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class TimerQuiz1 : MonoBehaviour
{
    public Interaktion interaktion;
    public float zeitGesamt1 = 15f;
    public float timer1 = 0f;
    public Text countDownText;
    public Text winText;
    public GameObject quiz1Cube;


    // Use this for initialization
    void Start()
    {
        timer1 = zeitGesamt1;
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz1Cube.activeInHierarchy)
        {
            timer1 -= Time.deltaTime;

            if (timer1 < 0)
            {
                gameObject.SetActive(false);
                countDownText.enabled = false;
            }

            countDownText.text = timer1.ToString("0.00");
        }

        if (interaktion.quiz1zaehler == 8 && timer1 > 0)
        {
            winText.text = "Gewonnen!";
            timer1 = 0;
            Abbruch();
        }

        if (interaktion.quiz1zaehler < 8 && timer1 < 0)
        {
            winText.text = "Verloren";
            Abbruch();
        }
    }


    IEnumerable Abbruch()
    {
        yield return new WaitForSeconds(5);
        winText.enabled = false;
    }
}