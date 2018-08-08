using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int keysCollected = 0;

    public void KeyCollected(Key key)
    {
        Debug.Log("CoinCollected");
        Destroy(key.gameObject);
        key.gameObject.GetComponent<Renderer>().enabled = false;
        keysCollected++;
    }

}
