using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource rocketSound;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
	}

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if (!rocketSound.isPlaying)  // to check sound only plays once
            {
                rocketSound.Play();
            }
        }
        else
        {
            rocketSound.Stop();
        }
    }
    private void Rotate()
    {
        rigidBody.freezeRotation = true;  // take manual control of rotation

        if (Input.GetKey(KeyCode.A))  // Can thrust whilst rotating
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }

        rigidBody.freezeRotation = false;  // resume physics control of rotation

        // reapply constraints
        rigidBody.constraints = RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezePositionZ;
    }


}
