using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

    public GameObject puzzlestein;
    Vector3 pos;
    public int i;
    public int j;
    Color farbe;

    // Use this for initialization
    void Start()
    {
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                pos = new Vector3(i, j, 5f);
                GameObject puzzle = Instantiate(puzzlestein, pos, Quaternion.identity);
                farbe = puzzle.GetComponent<Renderer>().material.color;
                if (farbe == Color.red)
                { 
                    puzzle.GetComponent<Renderer>().material.color = Color.cyan;
                }
                else
                {
                    puzzle.GetComponent<Renderer>().material.color = Color.red;
                }
                if (!puzzle.activeInHierarchy) puzzle.SetActive(true);
        
                if (i==3 && j== 2)
                {
                    ++j;
                    GameObject empty = new GameObject();
                    Instantiate(empty, pos, Quaternion.identity);
                    return;
                }
            }
        }       
        
    
    }

    // Update is called once per frame
    void Update () {
		
	}
}
