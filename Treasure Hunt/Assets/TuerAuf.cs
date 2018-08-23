using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuerAuf : MonoBehaviour {

    bool solved = false;
    QuizTimer quiz;

	// Use this for initialization
	void Start () {
        quiz = GameObject.FindGameObjectWithTag("QuizTimer").GetComponent<QuizTimer>();
    }
	
	// Update is called once per frame
	void Update () {
        solved = quiz.solved;
        Debug.Log("Juhu" + solved);
        if (solved)
        {
            this.transform.Translate(-13, 0, 0);
            AudioSource src = GetComponent<AudioSource>();
            src.Play();
        }
        Debug.Log(solved);
	}
}
