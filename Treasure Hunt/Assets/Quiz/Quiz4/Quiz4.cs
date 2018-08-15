using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz4 : MonoBehaviour {
    public GameObject rad1, rad2, rad3;


    // Use this for initialization
    void Start()
    {
        int zufall = (Random.Range(1, 8)) * 45;
        rad1 = Instantiate(rad1, rad1.transform.position, Quaternion.Euler(0, 0, zufall));
        if (!rad1.activeInHierarchy) rad1.SetActive(true);

        zufall = (Random.Range(1, 8)) * 45;
        rad2 = Instantiate(rad2, rad2.transform.position, Quaternion.Euler(0, 0, zufall));
        if (!rad2.activeInHierarchy) rad2.SetActive(true);

        zufall = (Random.Range(1, 8)) * 45;
        rad3 = Instantiate(rad3, rad3.transform.position, Quaternion.Euler(0, 0, zufall));
        if (!rad3.activeInHierarchy) rad3.SetActive(true);

    }

    // Update is called once per frame
    void Update ()
    {
        bool left = Input.GetKey(KeyCode.Q);
        bool right = Input.GetKey(KeyCode.E);
        if (right)
        {
            float rot1 = rad1.transform.rotation.z;
            rad1.transform.rotation = Quaternion.Euler(0, 0, (rot1 + 45));

            float rot2 = rad2.transform.rotation.z;
            rad2.transform.rotation = Quaternion.Euler(0, 0, (rot2 + 45));

            float rot3 = rad3.transform.rotation.z;
            rad3.transform.rotation = Quaternion.Euler(0, 0, (rot3 + 45));
        }
        if (left)
        {
            float rot1 = rad1.transform.rotation.z;
            rad1.transform.rotation = Quaternion.Euler(0, (rot1 - 45), 0);

            float rot2 = rad2.transform.rotation.z;
            rad2.transform.rotation = Quaternion.Euler(0, (rot2 - 45), 0);

            float rot3 = rad3.transform.rotation.z;
            rad3.transform.rotation = Quaternion.Euler(0, (rot3 - 45), 0);
        }
    }
}
