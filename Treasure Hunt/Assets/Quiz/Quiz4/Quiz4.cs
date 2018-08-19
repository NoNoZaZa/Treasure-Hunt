using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz4 : MonoBehaviour
{
    public GameObject rad1, rad2, rad3, keil;
    private float rotSpeed = 0.0011f;
    private Vector3 targetAngleA;
    private Vector3 targetAngleB;
    private Vector3 targetAngleC;
    //Transform 
    Quaternion targetRotation;



    // Use this for initialization
    void Start()
    {
        int zufall = (Random.Range(1, 8)) * 45;
        //GameObject radChild1 = rad1.transform.GetChild(0).Find("rad").gameObject;
        rad1 = Instantiate(rad1, rad1.transform.position, Quaternion.identity);
        rad1.transform.Rotate(0, zufall, 0);
        rad1.transform.parent = this.transform;
        if (!rad1.activeInHierarchy) rad1.SetActive(true);

        zufall = (Random.Range(1, 8)) * 45;
        rad2 = Instantiate(rad2, rad2.transform.position, Quaternion.identity);
        rad2.transform.Rotate(0, zufall, 0);
        rad2.transform.parent = this.transform;
        if (!rad2.activeInHierarchy) rad2.SetActive(true);

        zufall = (Random.Range(1, 8)) * 45;
        rad3 = Instantiate(rad3, rad3.transform.position, Quaternion.identity);
        rad3.transform.Rotate(0, zufall, 0);
        rad3.transform.parent = this.transform;
        if (!rad3.activeInHierarchy) rad3.SetActive(true);

        keil = Instantiate(keil, keil.transform.position, Quaternion.identity);
        keil.transform.Translate(0, 0, 5f);
        keil.transform.parent = this.transform;
        if (!keil.activeInHierarchy) keil.SetActive(true);

    }


    public void Drehen(GameObject rad, float p, float radP)
    {
        
        //Update();
        //Rechtsdrehung
        if (p > radP)
        {
            float rot = rad.transform.rotation.z;
            //targetAngleA = new Vector3(0, (rot + 45), 0);
            rad.transform.Rotate(0, (rot + 45), 0);

        }
        //Linkssdrehung
        if (p < radP)
        {
            FixedUpdate(rad);
        }
    }

    public void FixedUpdate(GameObject rad)
    {
        float rot = rad.transform.rotation.z;
        //rad.transform.Rotate(0, (rot - 45), 0);

        //get rotation
        Vector3 curr = new Vector3(rad.transform.rotation.x, rad.transform.rotation.y, rad.transform.rotation.z);
        Vector3 desti = new Vector3(0, (rot - 45), 0);
        targetRotation = Quaternion.FromToRotation(curr, (Vector3)desti);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
    }


    // Update is called once per frame
    //void Update()
    //{
    //    float step = Time.deltaTime * rotSpeed;
    //    Vector3 targetDir = target.position - transform.position;
    //    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetAngleA, step, 0.0f);
    //    transform.rotation = Quaternion.LookRotation(newDir);
    //    //transform.rotation.Lerp(rot.z, targetAngleA, step);



    //Smooth rotation
    //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime* rotSpeed);
    //BZW anstatt Lerp:
    //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed* Time.deltaTime);
    //}
}
