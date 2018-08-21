using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {

    private Queue<string> saetze;
	// Use this for initialization
	void Start () {
        saetze = new Queue<string>();
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void StartDialog(Dialog dialog)
    {
        Debug.Log("Test");
    }
}
