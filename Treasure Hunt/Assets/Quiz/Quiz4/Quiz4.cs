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
    public GameObject[] steinPos;
    public GameObject schluesselpref;

    // Use this for initialization
    void Start()
    {
        steinPos = new GameObject[16];
        timer = Instantiate(timer);
        timer.transform.parent = GameObject.Find("UI").transform;
        quiztimer = timer.GetComponent<QuizTimer>();
        quiztimer.zeitGesamt = 30f;
        quiztimer.quiz = this.gameObject;
        int index = 0;

        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                pos = new Vector3(i, j + offsetY, 7f);
                GameObject puzzle = Instantiate(puzzlestein, pos, Quaternion.identity);
                
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
                steinPos[index] = puzzle;
                //PuzzleMovement puzzlemovement = (PuzzleMovement) GetComponent("PuzzleMovement");
                //puzzlemovement.steinPos[index] = steinPos[index];
                puzzle.GetComponent("PuzzleMovement");

                //Puzzlelücke
                if (i == 3 && j == 2)
                {
                    ++j;
                    posE = new Vector3(i, j + offsetY, 7f);
                    empty = new GameObject();
                    empty = Instantiate(empty, posE, Quaternion.identity);
                    empty.name = "empty";
                    steinPos[index] = empty;
                    return;
                }
                
                Debug.Log(index);
                index++;
            }
        }       
        
    
    }

    // Update is called once per frame
    void Update () {
        
        if (steinPos[0].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[1].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[2].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[3].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[4].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[5].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[6].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[7].GetComponent<Renderer>().material.color == Color.cyan )
        {
            quiztimer.hasWon = true;
            GameObject schluessel = Instantiate(schluesselpref, transform.position, transform.rotation);
        }
        else if (steinPos[1].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[5].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[9].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[13].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[0].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[4].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[8].GetComponent<Renderer>().material.color == Color.cyan &&
            steinPos[12].GetComponent<Renderer>().material.color == Color.cyan &&
            quiztimer.timer > 0)
        {
            quiztimer.hasWon = true;
            GameObject schluessel = Instantiate(schluesselpref, transform.position, transform.rotation);
        }
        //else if (zeileL blau && zeileR rot)
        //    else if (zeileL rot && zeileR blau)

    }
}
