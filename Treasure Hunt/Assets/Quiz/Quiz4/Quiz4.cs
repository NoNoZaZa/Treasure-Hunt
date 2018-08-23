using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz4 : MonoBehaviour
{

    public GameObject puzzlestein;
    GameObject empty;
    Vector3 pos;
    Vector3 posE;
    public int i;
    public int j;
    public int offsetY = 2;
    public GameObject timer;
    private QuizTimer quiztimer;
    public GameObject[] steinPos;

    bool reihe1 = false;
    bool reihe2 = false;

    public GameObject schluesselpref;


    // Use this for initialization
    void Start()
    {
        steinPos = new GameObject[16];
        timer = Instantiate(timer);
        timer.transform.parent = GameObject.Find("UI").transform;
        quiztimer = timer.GetComponent<QuizTimer>();
        quiztimer.zeitGesamt = 60f;
        quiztimer.quiz = this.gameObject;
        int index = 0;

        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                pos = new Vector3(i + GameObject.FindGameObjectWithTag("Quiz4Parent").transform.position.x, j + offsetY, 7f + GameObject.FindGameObjectWithTag("Quiz4Parent").transform.position.z);
                GameObject puzzle = Instantiate(puzzlestein, pos, Quaternion.identity);

                if (!puzzle.activeInHierarchy)
                {
                    puzzle.SetActive(true);
                }

                if (((j == 0 || j == 2) && (i == 0 || i == 2)) || ((j == 1 || j == 3) && (i == 1 || i == 3)))
                {
                    puzzle.GetComponent<Renderer>().material.color = Color.cyan;
                }
                else
                {
                    puzzle.GetComponent<Renderer>().material.color = Color.red;
                }
                steinPos[index] = puzzle;


                //Puzzlelücke
                if (i == 3 && j == 2)
                {
                    ++j;
                    posE = new Vector3(i + GameObject.FindGameObjectWithTag("Quiz4Parent").transform.position.x, j + offsetY, 7f + GameObject.FindGameObjectWithTag("Quiz4Parent").transform.position.z);
                    empty = new GameObject();
                    empty = Instantiate(empty, posE, Quaternion.identity);
                    empty.name = "empty";
                    index++;
                    steinPos[index] = empty;
                }

                Debug.Log(index);
                index++;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (steinPos[0].GetComponent<Renderer>().material.color == Color.red &&
            steinPos[4].GetComponent<Renderer>().material.color == Color.red &&
            steinPos[8].GetComponent<Renderer>().material.color == Color.red &&
            steinPos[12].GetComponent<Renderer>().material.color == Color.red)
        { 
            reihe1 = true;
            Debug.Log("reihe1");
        }
        else
        {
            reihe1 = false;
        }
        if (steinPos[1].GetComponent<Renderer>().material.color == Color.red &&
            steinPos[5].GetComponent<Renderer>().material.color == Color.red &&
            steinPos[9].GetComponent<Renderer>().material.color == Color.red &&
            steinPos[13].GetComponent<Renderer>().material.color == Color.red)
        {
            reihe2 = true;
            Debug.Log("reihe2");
        }
        else
        {
            reihe2 = false;
        }
        if(reihe1 && reihe2 && quiztimer.timer > 0)
        { 
        quiztimer.hasWon = true;
            GameObject schluessel = Instantiate(schluesselpref, transform.position, transform.rotation);
        }

        if (quiztimer.hasWon)
        {
            foreach(GameObject puzzle in steinPos)
            {
                Destroy(puzzle);
            }
        }
    }
}
