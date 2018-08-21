using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drehrad : MonoBehaviour
{
    public GameObject rad1, rad2, rad3, keil;
    private float rotSpeed = 0.0011f;
    public float targetAngleA;
    public float targetAngleB;
    public float targetAngleC;
    bool sperre = true;
    Quaternion targetRotation;



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

        keil = Instantiate(keil, keil.transform.position, Quaternion.identity);
        //keil.transform.Translate(0, 0, 5f);
        keil.transform.parent = this.transform;
        if (!keil.activeInHierarchy) keil.SetActive(true);

        //Quiz aufstellen
        this.transform.Translate(10, 2.25f, 0);
        this.transform.Rotate(0, 0, 90);
        this.transform.localScale += new Vector3(-0.5f, -0.5f, -0.5f);

    }


    //public void FixedUpdate(GameObject rad)
    //{
    //    float rot = rad.transform.rotation.z;
    //    //rad.transform.Rotate(0, (rot - 45), 0);

    //    //get rotation
    //    Vector3 curr = new Vector3(rad.transform.rotation.x, rad.transform.rotation.y, rad.transform.rotation.z);
    //    Vector3 desti = new Vector3(0, (rot - 45), 0);
    //    targetRotation = Quaternion.FromToRotation(curr, (Vector3)desti);
    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);



    //}


    float rotDir = 0f;
    // Update is called once per frame
    public void Update()
    {


        //Quaternion target1 =  rad1.transform.rotation * Quaternion.Euler(new Vector3(0, targetAngleA, 0));
        //rad1.transform.rotation = Quaternion.Lerp(rad1.transform.rotation, target1, Time.deltaTime);
        //rad1.transform.Rotate(rad1.transform.up, Mathf.Lerp(rad1.transform.rotation.y, rad1.transform.rotation.y + targetAngleA, Time.deltaTime));

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



        //Keil soll sich in Radmitte schieben & drehen (Schlüsselprinzip)
        if (sperre && Mathf.Approximately(0f, (int)(rad1.transform.rotation.y * 100)) && Mathf.Approximately(0f, (int)(rad2.transform.rotation.y * 100)) && Mathf.Approximately(0f, (int)(rad3.transform.rotation.y * 100)))
        {
            GameObject keil = GameObject.FindWithTag("keil");
            keil.transform.Translate(0, 0, -2.3f);
            Vector3 ziel = new Vector3(0, 0, 0);
            if (keil.transform.position == ziel)
            { keil.transform.Rotate(0, 0, 90); }
            //keil.transform.parent = this.transform;
            sperre = false;
        }

        //    float step = Time.deltaTime * rotSpeed;
        //    Vector3 targetDir = target.position - transform.position;
        //    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetAngleA, step, 0.0f);
        //    transform.rotation = Quaternion.LookRotation(newDir);
        //    //transform.rotation.Lerp(rot.z, targetAngleA, step);

        //Smooth rotation
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime* rotSpeed);
        //BZW anstatt Lerp:
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed* Time.deltaTime);

    }
}
