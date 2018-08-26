using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuerCollision : MonoBehaviour {

    public bool unlockable;
    public bool solved = false;
    QuizTimer quiz;
    bool sound = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void ToggleUnlockable() {
    //    if (unlockable)
    //    {
    //        unlockable = false;
    //    }
    //    else {
    //        unlockable = true;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            //Debug.Log("Collisionobjekt: " + collision);
            Vector3 aktuellePosition = this.transform.position;

            if (unlockable) {
                Vector3 pos = new Vector3(aktuellePosition.x + 12, aktuellePosition.y, aktuellePosition.z);
                this.transform.position = Vector3.Lerp((this.transform.position), pos, Time.deltaTime);
                AudioSource src = this.GetComponent<AudioSource>();
                if (sound)
                {
                    src.Play();
                    sound = false;
                }
            }
            else
            {
                if (solved == true)
                {
                    Vector3 pos = new Vector3(aktuellePosition.x +2, aktuellePosition.y, aktuellePosition.z);
                    this.transform.position = Vector3.Lerp((this.transform.position), pos, Time.deltaTime);
                    AudioSource src = this.GetComponent<AudioSource>();
                    if (sound)
                    {
                        src.Play();
                        sound = false;
                    }
                    //enabled = false;
                }
            }
            Debug.Log("unlockable: " + unlockable);
        }
    }

}
