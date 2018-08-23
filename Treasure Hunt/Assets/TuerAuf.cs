using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuerAuf : MonoBehaviour {

    public bool solved = false;
    QuizTimer quiz;

	// Use this for initialization
	void Start () {
        //quiz = GameObject.FindGameObjectWithTag("QuizTimer").GetComponent<QuizTimer>();
    }
	
	// Update is called once per frame
	void Update () {
        //solved = quiz.solved;
        if (solved == true)
        {
            Vector3 pos = new Vector3(transform.position.x - 13, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp((transform.position), pos, Time.deltaTime);
            AudioSource src = this.GetComponent<AudioSource>();
            src.Play();
            src.Stop();
            //enabled = false;
        }
	}
}
