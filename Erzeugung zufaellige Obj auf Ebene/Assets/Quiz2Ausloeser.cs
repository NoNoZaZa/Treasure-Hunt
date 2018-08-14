using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz2Ausloeser : MonoBehaviour
{

    public GameObject quiz2Cube;

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
        Destroy(this.gameObject);
        quiz2Cube.SetActive(true);
        Destroy(this.gameObject);

    }
}
