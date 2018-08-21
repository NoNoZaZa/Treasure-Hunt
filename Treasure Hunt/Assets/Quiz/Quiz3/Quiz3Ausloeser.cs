using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz3Ausloeser : MonoBehaviour
{
    public GameObject quiz3Cube;


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Destroy(this.gameObject);
        quiz3Cube.SetActive(true);
    }
}