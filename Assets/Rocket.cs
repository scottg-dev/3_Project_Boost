using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody mvRigidBody;
    AudioSource mvAudioSource;
	// Use this for initialization
	void Start () {
        mvRigidBody = GetComponent<Rigidbody>();
        mvAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ProccessInput();
	}

    private void ProccessInput()
    {
        if (Input.GetKey(KeyCode.Space))// can thrust while rotating
        {
            //print("Thrusting");
            mvRigidBody.AddRelativeForce(Vector3.up);
            if (!mvAudioSource.isPlaying)// so it doesn't layer on top of each other.
            {
                mvAudioSource.Play();
            }      
        }
        else
        {
            mvAudioSource.Stop();
        }

        if (Input.GetKey(KeyCode.A))
        {
            //print("Rotating left");
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //print("Rotating right");
            transform.Rotate(-Vector3.forward);
        }
    }
}
