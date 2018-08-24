using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuerGenerator : MonoBehaviour {

    public RoomGeneration raumgenerator;
    List<float> xKoordinaten = new List<float>();
    List<float> yKoordinaten = new List<float>();
    List<float> zKoordinaten = new List<float>();
    int zaehlvariable = 0;

	// Use this for initialization
	void Start () {
        Debug.Log("TuerGenerator gestartet");
		List<Vector3> tuerpositionen = raumgenerator.tuerpositionen;

        foreach (var tuerposition in tuerpositionen) {
            xKoordinaten.Add(tuerposition.x);
            yKoordinaten.Add(tuerposition.y);
            zKoordinaten.Add(tuerposition.z);
        }

        foreach (var xKoordinate in xKoordinaten) {
            
            
            Debug.Log("Tuerpositionen: " + tuerpositionen[zaehlvariable]);
            zaehlvariable++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
