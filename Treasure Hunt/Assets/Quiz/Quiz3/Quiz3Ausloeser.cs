using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz3Ausloeser : MonoBehaviour
{
    public GameObject quiz3Cube;
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
        quiz3Cube.SetActive(true);
        text.enabled = true;
        Destroy(this.gameObject);

    }
}