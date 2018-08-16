using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

    public GameObject puzzlestein;
    Vector3 pos;
    public int i;
    public int j;
    Transform slot;
    int xtemp;
    int ytemp;


    // Use this for initialization
    void Start()
    {
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                pos = new Vector3(i, j, 5f);
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


                //Puzzlelücke
                if (i == 3 && j == 2)
                {
                    ++j;
                    GameObject empty = new GameObject();
                    Instantiate(empty, pos, Quaternion.identity);
                    return;
                }
            }
        }       
        
    
    }

    //private void OnMouseUp()
    //{
    //    xtemp = transform.position.x;
    //    ytemp = transform.position.y;
    //}


    // Update is called once per frame
    void Update () {
		
	}
}
