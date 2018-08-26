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
        if (obj.tag == "infoquiz1")
        {
            quizText.text = "PAARSUCHE \n\n \nKlicke die Paare an, damit sie verschwinden.\nNur wenn alle Paare verschwunden sind,\nwird der Schlüssel freigeschaltet.\n\n\nHüpfe gegen den Würfel mit dem Stern, um das Minigame zu starten.\n\nZum Schließen der Anleitung drücke die linke Maustaste.";
        }


        if(obj.tag == "infoquiz2")
        {
            quizText.text = "TRAGEN \n\n \nTrage den lila Würfel auf die lila Druckplatte, die sich im ersten Raum, in dem du warst, befindet.\nKlicke, um den Würfel aufzunehmen, die linke Maustaste " +
                "und um ihn loszulassen die rechte Maustaste.\n\n\nHüpfe gegen den Würfel mit dem Stern, um das Minigame zu starten.\n\nZum Schließen der Anleitung drücke die linke Maustaste.";
        }

        if (obj.tag == "infoquiz3")
        {
            quizText.text = "ABSCHIEßEN \n\n \nSchieße alle Würfel ab, um den Schlüssel zu bekommen.\nNutze zum Schießen die linke Maustaste.\n\n\nHüpfe gegen den Würfel mit dem Stern, um das Minigame zu starten.\n\nZum Schließen der Anleitung drücke die linke Maustaste.";          
        }


        if(obj.tag == "infoquiz4")
        {
            quizText.text = "SORTIEREN \n\n\nBringe alle roten Würfel nach unten.\n" +
                "Klicke hierzu die Würfel, die sich neben der Lücke befinden, mit der Maus an, um sie in die Lücke zu verschieben.\n\n\nHüpfe gegen den Würfel mit dem Stern, um das Minigame zu starten.\n\nZum Schließen der Anleitung drücke die linke Maustaste.";
        }
    }

}
