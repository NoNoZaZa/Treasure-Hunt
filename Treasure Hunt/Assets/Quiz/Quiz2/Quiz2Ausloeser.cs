using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz2Ausloeser : MonoBehaviour
{
    public GameObject quiz2Cube;
    public Text text;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log("Collide!");
       // quiz2.SetActive(true);
        text.enabled = true;
        Destroy(this.gameObject);

    }
}