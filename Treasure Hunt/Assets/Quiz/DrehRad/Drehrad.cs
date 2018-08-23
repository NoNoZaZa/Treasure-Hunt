using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drehrad : MonoBehaviour
{
    public GameObject rad1, rad2, rad3, keil;
    public float targetAngleA;
    public float targetAngleB;
    public float targetAngleC;
    bool sperre = true;
    Quaternion targetRotation;
    bool drehen = true;


    // Use this for initialization
    void Start()
    {
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
        keil.transform.Translate(0.5f, 4, 0.22f);
        //keil.transform.parent = this.transform;
        if (!keil.activeInHierarchy) keil.SetActive(true);

        //Quiz aufstellen
        this.transform.Translate(0, 2, 0);
        this.transform.Rotate(0, 0, 90);
        this.transform.localScale += new Vector3(-0.5f, -0.5f, -0.5f);

    }

    float rotDir = 0f;
    //Update is called once per frame

    public void Update()
    {


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
        if (sperre && Mathf.Approximately(0f, (int)(rad1.transform.rotation.y * 100)) && Mathf.Approximately(0f, (int)(rad2.transform.rotation.y * 100)) && Mathf.Approximately(0f, (int)(rad3.transform.rotation.y * 100)))
        {
            GameObject keil = GameObject.FindWithTag("keil");
            keil.transform.Translate(0, -2.02f, 0);
            Vector3 ziel = new Vector3(0, 0, 0);
            drehen = false;
            StartCoroutine(StartCounter());
            //keil.transform.Rotate(0, 90, 0);
            //if (keil.transform.position == ziel)
            //{ keil.transform.Rotate(0, 0, 90); }
            //keil.transform.parent = this.transform;
            sperre = false;
        }
    }
    private IEnumerator StartCounter()
    {
        float countDown = 1f;
        for (int i = 0; i < 10000; i++)
        {
            while (countDown >= 0)
            {
                Debug.Log(i++);
                countDown -= Time.smoothDeltaTime;
                yield return null;
            }
        }
        keil.transform.eulerAngles = new Vector3(185, -270, 90);
        keil.transform.position = new Vector3(1.5f, 1.4f, 2f);
        //keil.transform.Translate(-1.2f, 2.13f, -1.3f);
        //keil.transform.rotation = Quaternion.Euler(85, 10, -9);   
        //keil.transform.rotation = Quaternion.Euler(0,90,0 );     
    }

}
