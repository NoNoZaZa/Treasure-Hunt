using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private int zeitGesamt = 10;
    public Text countDownText;

	// Use this for initialization
	void Start () {
        StartCoroutine("Zeit");
	}
	
	// Update is called once per frame
	void Update () {
        countDownText.text = ("Timer: " + zeitGesamt);

        if(zeitGesamt <= 0)
        {
            StopCoroutine("Zeit vorbei");
            countDownText.text = "Test";

        }
	}

    IEnumerator Zeitzaehler()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            zeitGesamt--;
        }
    }
}
