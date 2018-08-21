using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz4Ausloeser : MonoBehaviour {

    public GameObject quiz4Cube;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Destroy(this.gameObject);
        quiz4Cube.SetActive(true);
    }
}
