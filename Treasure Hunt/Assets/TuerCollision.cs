using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuerCollision : MonoBehaviour {

    QuizTimer quiz;
    bool sound = true;
    bool schieben;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (schieben)
        {
            Vector3 aktuellePosition = this.transform.position;

            Vector3 pos = new Vector3(aktuellePosition.x + 12, aktuellePosition.y, aktuellePosition.z);
            this.transform.position = Vector3.Lerp((this.transform.position), pos, Time.deltaTime);
            AudioSource src = this.GetComponent<AudioSource>();
            if (sound)
            {
                src.Play();
                sound = false;
            }

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            //Debug.Log("Collisionobjekt: " + collision);
            schieben = true;
        }
    }

}
