using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuerCollisionZ : MonoBehaviour
{

    QuizTimer quiz;
    bool sound = true;
    bool schieben;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (schieben)
        {
            Vector3 aktuellePosition = this.transform.position;

            Vector3 pos = new Vector3(aktuellePosition.x, aktuellePosition.y, aktuellePosition.z + 12);
            this.transform.position = Vector3.Lerp((this.transform.position), pos, Time.deltaTime);
            AudioSource src = this.GetComponent<AudioSource>();
            if (sound)
            {
                src.Play();
                sound = false;
            }


        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Collisionobjekt: " + collision);
            schieben = true;
        }
    }

}
