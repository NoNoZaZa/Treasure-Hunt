using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Quiz1 : MonoBehaviour {
    public Interaktion interaktion;
    
    public GameObject[,] bloecke;
    public GameObject cubePref;
    public ArrayList liste = new ArrayList();

    private int i;
    private int j;

    public float groesse = 0.8f;
    private Color[] farben = {Color.black, Color.blue, Color.red, Color.green, Color.magenta, Color.cyan, Color.yellow, Color.grey };
    public GameObject timer;
    private QuizTimer quiztimer;
    public GameObject schluesselpref;

    // Use this for initialization

    void Start () {
        
        bloecke = new GameObject[4,4];       
        ErzeugungObjekte();
        ArrayBefuellen();
        Anordnung();
        timer = Instantiate(timer);
        timer.transform.parent = GameObject.Find("UI").transform;
        quiztimer = timer.GetComponent<QuizTimer>();
        quiztimer.zeitGesamt = 15f;
        quiztimer.quiz = this.gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        if (interaktion.quiz1zaehler == 8 && quiztimer.timer > 0)
        {
            quiztimer.hasWon = true;
            GameObject schluessel = Instantiate(schluesselpref, transform.position, transform.rotation);
        }

    }

    void ErzeugungObjekte()
    {
        const float NUM_CUBES = 16;
        int farbIndex = 0;
        for (int i = 0; i < NUM_CUBES; i += 2)
        {
            GameObject steinA = Instantiate(cubePref, transform.position, transform.rotation);
            GameObject steinB = Instantiate(cubePref, transform.position, transform.rotation);

            steinA.transform.localScale = new Vector3(groesse, groesse, groesse);
            steinB.transform.localScale = new Vector3(groesse, groesse, groesse);

            steinA.gameObject.GetComponent<Renderer>().material.color = farben[farbIndex];
            steinB.gameObject.GetComponent<Renderer>().material.color = farben[farbIndex];

            steinA.transform.parent = this.transform;
            steinB.transform.parent = this.transform;

            liste.Add(steinA);
            liste.Add(steinB);

            farbIndex++;
        }
    }


    void ArrayBefuellen()
    {
        
        for(i=0; i <4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                ArrayRandomzuweisen();
            }
        }

    }

    void Anordnung()
    {
        
        for(i = 0; i<4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                //bloecke[i, j].transform.localPosition = new Vector3(i,j, 0);
                bloecke[i, j].transform.Translate(i, j, 0);           
                
            }
        }
    }

    void ArrayRandomzuweisen()
    {
        int zahl = Random.Range(0, liste.Count);//random.Next(0, liste.Count);
        ((GameObject)liste[zahl]).GetComponent<Rigidbody>();
        ((GameObject)liste[zahl]).tag = "stein";
        bloecke[i, j] = (GameObject)liste[zahl];
        liste.RemoveAt(zahl);
    }
}
