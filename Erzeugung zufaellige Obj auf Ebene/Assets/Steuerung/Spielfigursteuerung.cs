using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spielfigursteuerung : MonoBehaviour {

    public float speed = 8f;
    public Rigidbody rb;
    private bool onGround;
    
// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
           
	
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        bool huepf = Input.GetKey(KeyCode.Space);

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (huepf)
        {
            if(onGround) {
                rb.AddForce(new Vector3(0, 4f, 0), ForceMode.Impulse);
                Debug.Log("Die Leertaste wird gedrueckt!");
                onGround = false;
            }

        }
	}
    private void OnCollisionStay(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "ground") {
            onGround = true;
        }
    }
}
