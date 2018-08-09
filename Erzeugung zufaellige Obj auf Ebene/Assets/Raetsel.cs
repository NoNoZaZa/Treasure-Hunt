using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raetsel : MonoBehaviour {
    public GameObject[,] bloecke;
    public GameObject stein;
    public int i;
    public int j; 
    // Use this for initialization

    void Start () {
        bloecke = new GameObject[4,4];
       
      }
	
	// Update is called once per frame
	void Update () {
        arrayBefuellen();

    }
    GameObject paare()
    {
        float xPos = 1;
        float yPos = 1;
        float zPos = 1;

        stein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein.transform.position = new Vector3(xPos, yPos, zPos);
        stein.transform.localScale += new Vector3(5.0F, 2.0F, 0.1F);

        if (j <= 4) {
            zPos++;
        }
        //switch (j)
        //{
        //    case < 5:
        //    case 
        //}
        

        if(j >= 4){
            yPos++;
        }

        return stein;


    }
    void arrayBefuellen()
    {
        for(i=0; i <16; i++)
        {
            for(j=0; j <16; j++)
            {
                bloecke[i, j] = paare();
            }
        }

    }
}
