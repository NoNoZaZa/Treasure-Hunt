using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz3Ausloeser : MonoBehaviour
{

    public GameObject quiz3Cube;

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
        quiz3Cube.SetActive(true);
        Destroy(this.gameObject);
    }
}