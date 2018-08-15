using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float zeitGesamt = 10f;
    public float timer = 0f;
    public Text countDownText;

    // Use this for initialization
    void Start()
    {
        timer = zeitGesamt;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            gameObject.SetActive(false);
        }

        countDownText.text = timer.ToString("0.00");   
    }





}
