using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnObj : MonoBehaviour {

    public GameObject Statueprefab;
    public Vector3 center;
    public Vector3 size = new Vector3 (10, 10, 10);
    public Quaternion rot;
    public int counter = 0;
    public System.Random zufall = new System.Random();

    // Use this for initialization
    void Start () {
        int zahl = zufall.Next(0, 5);
        while (zahl > 0)
        {
            Spawn();
            zahl--;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //if(Input.GetKeyDown(KeyCode.Q)){ 
        //    Spawn();
        //}
        
    }
    

    public void Spawn()
    {
        Vector3 pos = center + new Vector3(UnityEngine.Random.Range(-size.x / 8, size.x / 8), 1f , UnityEngine.Random.Range(-size.z / 8, size.z / 8));
        Quaternion rot = new Quaternion(0, UnityEngine.Random.Range(-size.y / 8, size.y / 8), 0, -1f);

        Instantiate(Statueprefab, pos, rot);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);

    }
}
