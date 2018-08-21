using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeschreibungQuiz : MonoBehaviour {
    public GameObject BeschrQuiz;
    public TextBoxManager manager;
    public GameObject obj;
   

    // Use this for initialization
    void Start() {
        BeschrQuiz.SetActive(false);
        manager = GameObject.Find("TextBoxManager").GetComponent<TextBoxManager>();

    }

    // Update is called once per frame
    void Update() {
        weggklicken();
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        BeschrQuiz.SetActive(true);
        manager.TextZuweisung(gameObject);
    }
    void weggklicken()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BeschrQuiz.SetActive(false);
        }
    }
}
