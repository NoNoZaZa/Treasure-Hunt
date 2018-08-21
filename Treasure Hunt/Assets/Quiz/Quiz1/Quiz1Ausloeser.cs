using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz1Ausloeser : MonoBehaviour {

    public GameObject quiz1Cube;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Destroy(this.gameObject);
        quiz1Cube.SetActive(true);
    }
}
