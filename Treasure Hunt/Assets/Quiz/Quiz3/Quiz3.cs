using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz3 : MonoBehaviour {
    public Interaktion interaktion;
    public float minGeschw = 1f;
    public float maxGeschw = 6f;
    public float geschwindigkeit = 0.5f;
    public float grenze = 3f;
    public float offset;
    public GameObject timer;
    private QuizTimer quiztimer;
    private float groesse = 0.8f;
    public List<GameObject> cubeListe;
    public GameObject cubeForm;


    // Use this for initialization
    void Start()
    {
        cubeListe = new List<GameObject>();
        ErzeugungCubes();

        
        timer = Instantiate(timer);
        timer.transform.parent = GameObject.Find("UI").transform;
        quiztimer = timer.GetComponent<QuizTimer>();
        quiztimer.zeitGesamt = 10f;
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
            cube.transform.Translate(0,i,0);
            cubeListe.Add(cube);
        }
    }

    Vector3 dir = Vector3.right;

    void CubesBewegen()
    {
        float cubeX;
        foreach (GameObject cube in cubeListe)
        {
            //cube.transform.Translate(Mathf.PingPong(Time.time * geschwindigkeit, grenze) + offset, 0, 0);
            //cube.transform.Translate(Mathf.PingPong(Time.time * geschwindigkeit, grenze), 0, 0);
            //cube.transform.position = new Vector3(Mathf.PingPong(Time.time * geschwindigkeit, grenze), 0, 0);
            cubeX = cube.transform.position.x;
            
            if (cubeX > transform.position.x + 4f)
            {
                //cube.transform.position = Vector3.Lerp(cube.transform.position, cube.transform.position + new Vector3(1, 0, 0), 0.1f);
                dir = new Vector3(-1, 0, 0);
            }
            if (cubeX < transform.position.x - 4f)
            {
                //cube.transform.position = Vector3.Lerp(cube.transform.position, cube.transform.position + new Vector3(-1,0,0), 0.1f);
                dir = new Vector3(+1, 0, 0);
            }
            cube.transform.Translate(dir * geschwindigkeit);

        }
    }

}
