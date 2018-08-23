using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spielfigursteuerung : MonoBehaviour {
    public Rigidbody rb;
    private bool onGround;
    float translation;
    float seitlich;
    float speed;


    // Use this for initialization
    void Start () {
        speed = 3f;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        Cursor.visible = false;   
	
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime*2;
        seitlich = Input.GetAxis("Horizontal") * speed * Time.deltaTime*2;

        bool huepf = Input.GetKey(KeyCode.Space);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 6f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 3f;
        }

        transform.Translate(seitlich, 0, translation);


        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Application.Quit();
        }

        if (huepf)
        {
            if(onGround) {
                rb.AddForce(new Vector3(0, 4f, 0), ForceMode.Impulse);
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
