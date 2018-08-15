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
    public GameObject quiz3Cube;

    // Use this for initialization
    void Start()
    {
        timer = zeitGesamt;
        
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
            }

            countDownText.text = timer.ToString("0.00");
        }
    }

}
