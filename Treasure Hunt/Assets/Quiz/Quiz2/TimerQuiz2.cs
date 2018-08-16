using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class TimerQuiz2 : MonoBehaviour
{
    public Interaktion interaktion;
    public float zeitGesamt = 20f;
    public float timer = 0f;
    public Text countDownText;
    public Text winText;
    public GameObject quiz2Cube;


    // Use this for initialization
    void Start()
    {
        timer = zeitGesamt;
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz2Cube.activeInHierarchy)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                gameObject.SetActive(false);
                countDownText.enabled = false;
            }

            countDownText.text = timer.ToString("0.00");
        }

    }


    IEnumerable Abbruch()
    {
        yield return new WaitForSeconds(5);
        winText.enabled = false;
    }
}