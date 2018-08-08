using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KollisionSpielfigur : MonoBehaviour {


    private Rigidbody rb;
    public Vector3 vel;
    public bool continuous;
    public bool useDeltaTime;
    public bool block;

    // Use this for initialization
    public enum MoveType { AddForce, MovePosition, Velocity, Translation }
    public MoveType moveType = MoveType.AddForce;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (continuous || !block)
        {
            switch (moveType)
            {
                case MoveType.AddForce:
                    if (continuous && useDeltaTime) rb.AddForce(vel * Time.deltaTime, ForceMode.Force);
                    else rb.AddForce(vel, ForceMode.Force);
                    break;
                case MoveType.MovePosition:
                    rb.MovePosition(vel);
                    break;
                case MoveType.Velocity:
                    rb.velocity = vel;
                    break;
                case MoveType.Translation:
                    if (continuous && useDeltaTime) transform.Translate(vel * Time.deltaTime);
                    else transform.Translate(vel);
                    break;
            }
            block = true;
        }
    }



    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Entered Collision...");
    }

    void OnCollisionStay(Collision other)
    {
        Debug.Log("Currently Colliding...");
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("Exited Collision...");
    }
}