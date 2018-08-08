using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float speed = 1.0f;
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
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
            if(rb.velocity.y == 0) {
                rb.AddForce(new Vector3(0, 8f, 0), ForceMode.Impulse);
                Debug.Log("Die Leertaste wird gedrueckt!");
            }

        }
	}
}
