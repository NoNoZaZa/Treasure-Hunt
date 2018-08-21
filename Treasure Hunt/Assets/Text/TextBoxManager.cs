using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;
    public Text meinText;
    public GameObject infoquiz3;
    public GameObject infoquiz1;
    private Text quizText;
    private GameObject obj;


    // Use this for initialization
    public void Start() {
        quizText = meinText.GetComponent<Text>();

    }

    void Update()
    {
    }

    public void TextZuweisung(GameObject obj)
    {
        
        if (obj.tag == "infoquiz3")
        {
            quizText.text = "Schieße alle Teile ab um den Schlüssel zu bekommen.\nNutze zum schießen die linke Maustaste.";
            Debug.Log("Quiz3");
        }

        if (obj.tag == "infoquiz1")
        {
            quizText.text = "Bescheibung Quiz1 ";
            Debug.Log("Quiz1");
        }
    }

}
