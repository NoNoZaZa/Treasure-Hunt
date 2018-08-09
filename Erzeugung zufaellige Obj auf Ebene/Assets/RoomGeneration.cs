using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants {
    public const int HoechstanzahlRaeume = 10;
    public const int Seed1 = 42;
}

public class RoomGeneration : MonoBehaviour {

    public GameObject Raumprefab;
    public GameObject[] Raeume;

    public char[,] generierteRaeume = new char[Constants.HoechstanzahlRaeume, Constants.HoechstanzahlRaeume];


    public Vector3 center;
    public Vector3 size;
    public bool randomizeSeed = true;

    public int raumzaehler = 0;

	// Use this for initialization
	void Start () {
        if (randomizeSeed == false) {
            Random.InitState(Constants.Seed1);
        }
        while (raumzaehler < Constants.HoechstanzahlRaeume) {
            SpawnRoom();

            raumzaehler++;  
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnRoom() {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x /2), -1, Random.Range(-size.z /2, size.z / 2));
        Instantiate(Raumprefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

}
