using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody mvRigidBody;
    AudioSource mvAudioSource;
    [SerializeField] float mvRcsThrust = 100f;
    // Use this for initialization
    void Start () {
        mvRigidBody = GetComponent<Rigidbody>();
        mvAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
    }
    private void Rotate()
    {
        mvRigidBody.freezeRotation = true; //take manual control of rotation

        float lvRcsThrust = 100f;

        float lvRotationThisFrame = lvRcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            //print("Rotating left");
            transform.Rotate(Vector3.forward * lvRotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //print("Rotating right");
            transform.Rotate(-Vector3.forward * lvRotationThisFrame);
        }

        mvRigidBody.freezeRotation = false;//resume physics control of rotation
    }

    private void Thrust()
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
    }
}
