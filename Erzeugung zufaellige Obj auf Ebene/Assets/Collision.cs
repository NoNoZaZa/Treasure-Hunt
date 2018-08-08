using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    GameManager m;

    // Event, dass bei der Berührung mit einem anderen ausgeführt wird
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Debug.Log("Collision Key");
            if (m != null)
                m.SendMessage("KeyCollected", other.GetComponent<Key>());
        }
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.name == "Key")
    //    {
    //        Debug.Log("Collision Key");
    //        Destroy(col.gameObject);
    //    }
    //}

    void Start()
    {
       // m = FindObjectOfType<GameManager>;
        //m.SendMessage(m.KeyCollected(Key key));
    }
}
