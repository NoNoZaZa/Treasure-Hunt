using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz3 : MonoBehaviour {
    public Interaktion interaktion;
    public GameObject timer;
    private QuizTimer quiztimer;
    private float groesse = 0.0045f;
    public List<GameObject> cubeListe;
    public GameObject cubeForm;
    private float geschwindigkeit = 9f;
    public GameObject schluesselpref;


    // Use this for initialization
    void Start()
    {
        cubeListe = new List<GameObject>();
        ErzeugungCubes();
        timer = Instantiate(timer);
        timer.transform.parent = GameObject.Find("UI").transform;
        quiztimer = timer.GetComponent<QuizTimer>();
        quiztimer.zeitGesamt = 20f;
        quiztimer.quiz = this.gameObject;
        geschwindigkeit = geschwindigkeit * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        CubesBewegen();
        if (interaktion.zaehlercubes == 6 && quiztimer.timer > 0)
        {
            quiztimer.hasWon = true;
            GameObject schluessel = Instantiate(schluesselpref, transform.position, transform.rotation);
        }
    }

    void ErzeugungCubes()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject cube = Instantiate(cubeForm, transform.position, transform.rotation);
            cube.transform.parent = this.transform;
            cube.transform.localScale = new Vector3(groesse, groesse, groesse);
            cube.transform.position = new Vector3( Random.Range(-3f, 3f) + transform.position.x, transform.position.y, transform.position.z);
            cube.transform.Translate(0,i,0);
            cube.transform.forward = cube.transform.right;
            cubeListe.Add(cube);
            cube.tag = "Quiz3";
        }
    }

    

    void CubesBewegen()
    {
        
        foreach (GameObject cube in cubeListe)
        {          
            Vector3 dir = Vector3.zero;
            float cubeX = cube.transform.position.x;

            if (cubeX > transform.position.x + 3f)
            {
                cube.transform.forward *= -1;
            }
            if (cubeX < transform.position.x - 3f)
            {
                cube.transform.forward *= -1;
            }
            cube.transform.Translate(0,0,geschwindigkeit);
        }
    }
}
