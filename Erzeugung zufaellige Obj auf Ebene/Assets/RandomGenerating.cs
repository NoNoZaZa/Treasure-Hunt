using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants {
    public const int HoechstanzahlRaeume = 10;
}

public class RandomGenerating : MonoBehaviour {

    public GameObject Raumprefab;
    public GameObject[] Raeume;

    public Vector3[] generierteRaeume;

    public Vector2 center;
    public Vector2 size;

    public System.Random zufall = new System.Random();
    public int raumzaehler = 0;

	// Use this for initialization
	void Start () {
        while (raumzaehler < Constants.HoechstanzahlRaeume) {
            SpawnRoom();

            raumzaehler++;  
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnRoom() {
        Vector2 pos = center + new Vector2(Random.Range(-size.x / 2, size.x /2), 0);
        Instantiate(Raumprefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,1,0,0.5f);
        Gizmos.DrawCube(center, size);
    }

}
