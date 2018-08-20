using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    struct Geschwindigkeit
    {
        private float geschw;
    }

public class Quiz3 : MonoBehaviour {
    public Interaktion interaktion;
    //public float minGeschw = 1f;
    //public float maxGeschw = 6f;
    //private float geschwindigkeit;
    //public float grenze = 3f;
    //public float offset;
    public GameObject timer;
    private QuizTimer quiztimer;
    private float groesse = 0.0045f;
    public List<GameObject> cubeListe;
    public GameObject cubeForm;
    private float geschwindigkeit = 0.15f;


    // Use this for initialization
    void Start()
    {
        cubeListe = new List<GameObject>();
        ErzeugungCubes();
        timer = Instantiate(timer);
        timer.transform.parent = GameObject.Find("UI").transform;
        quiztimer = timer.GetComponent<QuizTimer>();
        quiztimer.zeitGesamt = 10f;
        quiztimer.quiz = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CubesBewegen();
        //transform.position = new Vector3(Mathf.PingPong(Time.time * geschwindigkeit, grenze) + offset, transform.position.y, transform.position.z);
        if (interaktion.zaehlercubes == 6 && quiztimer.timer > 0)
        {
            quiztimer.hasWon = true;
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
            cube.transform.Translate(0,-4+i,0);
            cube.transform.forward = cube.transform.right;
            cubeListe.Add(cube);
            cube.tag = "Quiz3";
        }
    }

    

    void CubesBewegen()
    {
        foreach (GameObject cube in cubeListe)
        {
            //geschwindigkeit = Random.Range(0.0f, 0.2f);
            Vector3 dir = Vector3.zero;

            //cube.transform.Translate(Mathf.PingPong(Time.time * geschwindigkeit, grenze) + offset, 0, 0);
            //cube.transform.Translate(Mathf.PingPong(Time.time * geschwindigkeit, grenze), 0, 0);
            //cube.transform.position = new Vector3(Mathf.PingPong(Time.time * geschwindigkeit, grenze), 0, 0);
            float cubeX = cube.transform.position.x;
            Debug.Log(cube.transform.position.x);

            if (cubeX > transform.position.x + 3f)
            {
                //cube.transform.position = Vector3.Lerp(cube.transform.position, cube.transform.position + new Vector3(1, 0, 0), 0.1f);
                //dir = new Vector3(-1, 0, 0);
                cube.transform.forward *= -1;

            }
            if (cubeX < transform.position.x - 3f)
            {
                //cube.transform.position = Vector3.Lerp(cube.transform.position, cube.transform.position + new Vector3(-1,0,0), 0.1f);
                //dir = new Vector3(+1, 0, 0);
                cube.transform.forward *= -1;

            }
            cube.transform.Translate(0,0,geschwindigkeit);
        }
    }
}
