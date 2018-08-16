using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class TimerQuiz2 : MonoBehaviour
{
    public Interaktion interaktion;
    public float zeitGesamt2 = 20f;
    public float timer2 = 0f;
    public Text countDownText;
    public Text winText;
    public GameObject quiz2Cube;


    // Use this for initialization
    void Start()
    {
        timer2 = zeitGesamt2;
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz2Cube.activeInHierarchy)
        {
            timer2 -= Time.deltaTime;

            if (timer2 < 0)
            {
                gameObject.SetActive(false);
                countDownText.enabled = false;
            }

            countDownText.text = timer2.ToString("0.00");
        }

    }

}