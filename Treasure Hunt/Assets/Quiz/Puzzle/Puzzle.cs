using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

    public GameObject puzzlestein;
    GameObject empty;
    Vector3 pos;
    Vector3 posE;
    public int i;
    public int j;


    // Use this for initialization
    void Start()
    {
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                pos = new Vector3(i, j, 5f);
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
                    posE = new Vector3(i, j, 5f);
                    empty = new GameObject();
                    empty = Instantiate(empty, posE, Quaternion.identity);
                    empty.name = "empty";
                    return;
                }
            }
        }       
        
    
    }

    // Update is called once per frame
    void Update () {
		
	}
}
