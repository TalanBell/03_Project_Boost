using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource rocketSound;

    bool m_Play;
    bool m_ToggleChange;  // to check sound only plays once

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
        m_Play = true;
        m_ToggleChange = true;
    }
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if (m_Play == true && m_ToggleChange == true)
            {
                rocketSound.Play();
                m_ToggleChange = false;
            }
        }
        else
        {
            rocketSound.Stop();
            m_ToggleChange = true;
        }

        if (Input.GetKey(KeyCode.A))  // Can thrust whilst rotating
        {
            transform.Rotate(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.left);
        }

    }
}
