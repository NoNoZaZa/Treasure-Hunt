using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseLook : MonoBehaviour {
    //Quelle: https://www.youtube.com/watch?v=blO039OzUZc&t=157s

    Vector2 mouseLook; 
    Vector2 smoothMovement;
    public float sensitivity = 0.1f;
    public float smoothing = 2.0f;

    GameObject character;

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		var maus = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        //Bewegung
        maus = Vector2.Scale(maus, new Vector2(sensitivity * smoothing * 0.35f, sensitivity * smoothing* 0.35f));
        smoothMovement.x = Mathf.Lerp(smoothMovement.x, maus.x, 1f / smoothing);
        smoothMovement.y = Mathf.Lerp(smoothMovement.y, maus.y, 1f / smoothing);
        mouseLook += smoothMovement;
        //Begrenzung für nach oben und unten schauen
        mouseLook.y = Mathf.Clamp(mouseLook.y, -70f, 70f);

        //Drehung um Achse
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
	}
}
