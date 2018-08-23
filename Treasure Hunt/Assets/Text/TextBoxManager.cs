using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;
    public Text meinText;
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
            quizText.text = "ABSCHIEßEN \n \nSchieße alle Teile ab, um den Schlüssel zu bekommen.\nNutze zum Schießen die linke Maustaste.";          
        }

        if(obj.tag == "infoquiz2")
        {
            quizText.text = "TRAGEN \n \nTrage den Würfel auf die Druckplatte, um den Schlüssel anzeigen zu lassen.\nNutze zum Tragen die linke Maustaste " +
                "und zum Loslassen die rechte Maustaste.";
        }

        if (obj.tag == "infoquiz1")
        {
            quizText.text = "PAARSUCHE \n \nKlicke die Paare an, damit sie verschwinden.\nNur wenn alle Paare verschwunden sind\nwird der Schlüssel freigeschaltet.";
        }
        if(obj.tag == "infoquiz4")
        {
            quizText.text = "SORTIEREN \n\nBringe die roten Würfel nach unten, um den Schlüssel freizuschalten.\n" +
                "Klicke die Würfel hierzu mit der Maus an.";
        }
    }

}
