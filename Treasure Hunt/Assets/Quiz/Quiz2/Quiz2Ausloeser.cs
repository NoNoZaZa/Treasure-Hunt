﻿using System.Collections;
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
        Destroy(this.gameObject);
        quiz2Cube.SetActive(true);
        text.enabled = true;


    }
}