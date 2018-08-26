using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drehrad : MonoBehaviour
{
    public GameObject rad1, rad2, rad3, keil;
    public float targetAngleA;
    public float targetAngleB;
    public float targetAngleC;
    bool sperre = true;
    Quaternion targetRotation;
    bool drehen = true;
    public float posX, posY, posZ;
    GameManager gameManager;
    int keysCollected;
    public Text scoreText;
    public GameObject scoreAnzeige;

    public GameObject endraumtuer;
    public TuerCollisionEndraumX tuerCollisionEndraumX;
    public TuerCollisionEndraumZ tuerCollsiionEndraumZ;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        int zufall = (Random.Range(1, 8)) * 45;
        //GameObject radChild1 = rad1.transform.GetChild(0).Find("rad").gameObject;
        rad1 = Instantiate(rad1);
        rad1.transform.Rotate(0, zufall, 0);
        rad1.name = "rad1";
        rad1.transform.parent = this.transform;
        if (!rad1.activeInHierarchy) rad1.SetActive(true);

        zufall = (Random.Range(1, 8)) * 45;
        rad2 = Instantiate(rad2);
        rad2.transform.Rotate(0, zufall, 0);
        rad2.name = "rad2";
        rad2.transform.parent = this.transform;
        if (!rad2.activeInHierarchy) rad2.SetActive(true);

        zufall = (Random.Range(1, 8)) * 45;
        rad3 = Instantiate(rad3);
        rad3.transform.Rotate(0, zufall, 0);
        rad3.name = "rad3";
        rad3.transform.parent = this.transform;
        if (!rad3.activeInHierarchy) rad3.SetActive(true);

        keil = Instantiate(keil);
        //keil.transform.Translate(3.7f, 0f, 0f);
        keil.transform.parent = this.transform;
        //keil.transform.Rotate(0, -90,0);
        if (!keil.activeInHierarchy) keil.SetActive(true);

        //Quiz aufstellen
        this.transform.Translate(0 + posX, 2 + posY, 0 + posZ);
        this.transform.Rotate(0, 0, 90);
        this.transform.localScale += new Vector3(-0.5f, -0.5f, -0.5f);

    }

    float rotDir = 0f;
    //Update is called once per frame

    public void Update()
    {
        keysCollected = gameManager.keysCollected;

        //Quaternion target1 =  rad1.transform.rotation * Quaternion.Euler(new Vector3(0, targetAngleA, 0));
        //rad1.transform.rotation = Quaternion.Lerp(rad1.transform.rotation, target1, Time.deltaTime);
        //rad1.transform.Rotate(rad1.transform.up, Mathf.Lerp(rad1.transform.rotation.y, rad1.transform.rotation.y + targetAngleA, Time.deltaTime));
        if (drehen)
        {
            //RadA
            if (targetAngleA >= 45)
            {
                rotDir = 5;
            }
            else if (targetAngleA <= -45)
            {
                rotDir = -5;
            }

            if (targetAngleA != 0)
            {
                //rad1.transform.Rotate(transform.up, rotDir);
                rad1.transform.Rotate(0, rotDir, 0);
                targetAngleA -= rotDir;
            }

            //RadB
            if (targetAngleB >= 45)
            {
                rotDir = 5;
            }
            else if (targetAngleB <= -45)
            {
                rotDir = -5;
            }

            if (targetAngleB != 0)
            {
                //rad1.transform.Rotate(transform.up, rotDir);
                rad2.transform.Rotate(0, rotDir, 0);
                targetAngleB -= rotDir;
            }

            //RadC
            if (targetAngleC >= 45)
            {
                rotDir = 5;
            }
            else if (targetAngleC <= -45)
            {
                rotDir = -5;
            }

            if (targetAngleC != 0)
            {
                //rad1.transform.Rotate(transform.up, rotDir);
                rad3.transform.Rotate(0, rotDir, 0);
                targetAngleC -= rotDir;
            }

        }

        //Keil soll sich in Radmitte schieben & drehen (Schlüsselprinzip)
        if (keysCollected > 0 && sperre && Mathf.Approximately(0f, (int)(rad1.transform.rotation.y * 100)) && Mathf.Approximately(0f, (int)(rad2.transform.rotation.y * 100)) && Mathf.Approximately(0f, (int)(rad3.transform.rotation.y * 100)))
        {
            GameObject keil = GameObject.FindWithTag("keil");
            keil.transform.Translate(0, 0, -1.8f);
            Vector3 ziel = new Vector3(0, 0, 0);
            drehen = false;
            StartCoroutine(StartCounter());
            //keil.transform.Rotate(0, 90, 0);
            //if (keil.transform.position == ziel)
            //{ keil.transform.Rotate(0, 0, 90); }
            //keil.transform.parent = this.transform;
            sperre = false;
            endraumtuer = GameObject.FindGameObjectWithTag("endraumtuer");
            //tuerCollisionEndraumX = endraumtuer.GetComponent<TuerCollisionEndraumX>();
            //tuerCollisionEndraumX.drehRadGeschafft = true;
            tuerCollsiionEndraumZ = endraumtuer.GetComponent<TuerCollisionEndraumZ>();
            tuerCollsiionEndraumZ.drehRadGeschafft = true;
        }
        else if (keysCollected == 0 && sperre && Mathf.Approximately(0f, (int)(rad1.transform.rotation.y * 100)) && Mathf.Approximately(0f, (int)(rad2.transform.rotation.y * 100)) && Mathf.Approximately(0f, (int)(rad3.transform.rotation.y * 100)))
        {
            GameObject keil = GameObject.FindWithTag("keil");
            keil.transform.Translate(0, 0, -1.8f);
            Vector3 ziel = new Vector3(0, 0, 0);
            drehen = false;
            StartCoroutine(StartCounter());
            scoreAnzeige.SetActive(true);
            scoreText.text = "SPIELENDE\n\nDu hast leider keinen Schlüssel gesammelt & kommst somit nicht in die Schatzkammer :( \n\nDrücke ESC zum Verlassen.";
            sperre = false;
        }
    }

    //Quelle von IEnumerator: https://answers.unity.com/questions/1040630/do-something-for-10-sec.html
    private IEnumerator StartCounter()
    {
        float countDown = 1f;
        for (int i = 0; i < 10000; i++)
        {
            while (countDown >= 0)
            {
                //Debug.Log(i++);
                countDown -= Time.smoothDeltaTime;
                yield return null;
            }
        }
        //keil.transform.eulerAngles = new Vector3(185, -270, 90);
        //keil.transform.position = new Vector3(1.5f + posX, 1.4f + posY, 2f + posZ);
        keil.transform.Rotate(0,0,-90);
        //keil.transform.Translate(-1.2f, 2.13f, -1.3f);
        //keil.transform.rotation = Quaternion.Euler(85, 10, -9);   
        //keil.transform.rotation = Quaternion.Euler(0,90,0 );     
    }

}
