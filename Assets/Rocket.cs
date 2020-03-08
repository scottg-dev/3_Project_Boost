using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody mvRigidBody;
	// Use this for initialization
	void Start () {
        mvRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        ProccessInput();
	}

    private void ProccessInput()
    {
        if (Input.GetKey(KeyCode.Space))// can thrust while rotating
        {
            print("Thrusting");
            mvRigidBody.AddRelativeForce(Vector3.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            print("Rotating left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("Rotating right");
        }
    }
}
