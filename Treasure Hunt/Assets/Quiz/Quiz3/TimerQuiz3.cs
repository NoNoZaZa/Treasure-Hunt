using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class TimerQuiz3 : MonoBehaviour
{
    public Interaktion interaktion;
    public float zeitGesamt3 = 10f;
    public float timer3 = 0f;
    public Text countDownText;
    public Text winText;
    public GameObject quiz3Cube;



    // Use this for initialization
    void Start()
    {
        timer3 = zeitGesamt3;       
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz3Cube.activeInHierarchy)
        {
            timer3 -= Time.deltaTime;

            if (timer3 < -3)
            {
                gameObject.SetActive(false);
                
            }
            if (timer3 < 0)
            {
                countDownText.enabled = false;
            }

            countDownText.text = timer3.ToString("0.00");
        }


        

        if (interaktion.zaehlercubes == 6 && timer3 > 0)
        {
            winText.text = "Gewonnen!";
            timer3 = 0;
            //Abbruch();
        }
        
        if (interaktion.zaehlercubes < 6 && timer3 < 0)
        {
            winText.text = "Verloren";
            //Abbruch();
        }

        if (timer3 <= -3)
        {
            winText.text = "";
        }
    }


    //IEnumerable Abbruch()
    //{          
    //    yield return new WaitForSeconds(5);
    //    winText.enabled = false;
    //}
}
