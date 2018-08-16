using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz4 : MonoBehaviour
{
    public GameObject rad1, rad2, rad3;
    private float rotSpeed = 1;
    private Vector3 targetAngleA;
    private Vector3 targetAngleB;
    private Vector3 targetAngleC;


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

    }


    public void Drehen(GameObject rad, float p, float radP)
    {
        
        //Update();
        //Rechtsdrehung
        if (p > radP)
        {
            float rot = rad.transform.rotation.z;
            rad.transform.Rotate(0, (rot + 45), 0);

        }
        //Linkssdrehung
        if (p < radP)
        {
            float rot = rad.transform.rotation.z;
            rad.transform.Rotate(0, (rot - 45), 0);
        }
    }


    // Update is called once per frame
    void Update()
    {
        float speed = Time.deltaTime * rotSpeed;
        .Lerp(rot.z, targetAngleA, speed);
    }
}
