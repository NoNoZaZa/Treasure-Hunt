using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz2Ausloeser : MonoBehaviour
{
    public GameObject quiz2Cube;


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Destroy(this.gameObject);
        quiz2Cube.SetActive(true);
    }
}