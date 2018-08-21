using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz4 : MonoBehaviour {

    public GameObject puzzlestein;
    GameObject empty;
    Vector3 pos;
    Vector3 posE;
    public int i;
    public int j;
    public int offsetY = 2;
    public GameObject timer;
    private QuizTimer quiztimer;
    Vector3[,] steinPos;

    // Use this for initialization
    void Start()
    {
        timer = Instantiate(timer);
        timer.transform.parent = GameObject.Find("UI").transform;
        quiztimer = timer.GetComponent<QuizTimer>();
        quiztimer.zeitGesamt = 30f;
        quiztimer.quiz = this.gameObject;


        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                pos = new Vector3(i, j + offsetY, 7f);
                GameObject puzzle = Instantiate(puzzlestein, pos, Quaternion.identity);
                puzzle.GetComponent("PuzzleMovement");
                if (!puzzle.activeInHierarchy)
                {
                    puzzle.SetActive(true);
                }

                if (((j==0 || j==2) && (i==0 || i == 2)) || ((j == 1 || j == 3) && (i == 1 || i == 3)))
                {
                    puzzle.GetComponent<Renderer>().material.color = Color.cyan;
                }
                else
                {
                    puzzle.GetComponent<Renderer>().material.color = Color.red;
                }


                //Puzzlelücke
                if (i == 3 && j == 2)
                {
                    ++j;
                    posE = new Vector3(i, j + offsetY, 7f);
                    empty = new GameObject();
                    empty = Instantiate(empty, posE, Quaternion.identity);
                    empty.name = "empty";
                    //steinPos[i, j] = empty.transform.position;
                    return;
                }
                //steinPos[i, j] = puzzle.transform.position;
            }
        }       
        
    
    }

    // Update is called once per frame
    //void Update () {
    //    if (transform.hasChanged)
 //       { tausche positionsinfo im array}



            //       if (zeile12 blau && zeile34 rot)

            //       else if(zeile12 rot && zeile34 blau)

            //       else if (zeileL blau && zeileR rot)

            //       else if (zeileL rot && zeileR blau)

    //}
}
