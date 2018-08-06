using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public int keycount = 0;

    // Event, dass bei der Berührung mit einem anderen ausgeführt wird
    void OnCollisionEnter(Collision touch)
    {
        if (touch.gameObject.name == "key_gold")
        {
        keycount++; 
        }
    }
}
