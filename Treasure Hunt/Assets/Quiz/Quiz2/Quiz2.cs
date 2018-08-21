using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz2 : MonoBehaviour {

    public GameObject cube, druckplatte, player;
    public Vector3 groesse = new Vector3(0.8f, 0.8f, 0.8f);
    public float holdDistance = 1f;
    public float moveDelay = 2f;
    public GameObject timer;
    private QuizTimer quiztimer;

    private Vector3 target = Vector3.zero;

    // Use this for initialization
    void Start () {
        //erzeugung();
        cube = Instantiate(cube, transform.position, Quaternion.identity);
        cube.transform.parent = this.transform;
        //if (!cubeInstance.activeInHierarchy) cubeInstance.SetActive(true);

        timer = Instantiate(timer);
        timer.transform.parent = GameObject.Find("UI").transform;
        quiztimer = timer.GetComponent<QuizTimer>();
        quiztimer.zeitGesamt = 20f;


        //Druckplatte
        druckplatte = Instantiate(druckplatte);
        druckplatte.transform.parent = this.transform;
        //druckplatte.GetComponent<Renderer>().material.color = Color.magenta;
        //druckplatte.transform.position = new Vector3(-10f, 2f, 30f);

    }

    // Update is called once per frame
    void Update () {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, holdDistance));
    }




    public void Wearing()
    {
        if (cube != null)
        {
            cube.transform.position = Vector3.Lerp(cube.transform.position, target, Time.deltaTime * moveDelay);
            //cube.transform.position = 
            cube.transform.rotation = player.transform.rotation;
        }
        else if (cube != null && quiztimer.timer > 0)
        {
            quiztimer.hasWon = true;

        }
    }


    void Erzeugung()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = groesse;
        cube.AddComponent<Rigidbody>();
        cube.gameObject.GetComponent<Renderer>().material.color = Color.green;
        cube.tag = "hebObj";
        
    }

}
