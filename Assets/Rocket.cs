using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 10f;

    Rigidbody rigidBody;
    AudioSource rocketSound;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    foreach (ContactPoint contact in collision.contacts)
    //    {
    //        Debug.DrawRay(contact.point, contact.normal, Color.white);
    //    }
    //    if (collision.relativeVelocity.magnitude > 2)
    //        audioSource.Play();
    //}

    // Update is called once per frame
    void Update () {
        Thrust();
        Rotate();
	}

    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                // do nothing
                print("OK");  //TODO remove this line
                break;
            case "Fuel":
                // if fuel object, add fuel
                print("Fuel");  //TODO remove this line
                break;
            default:
                // kill player
                print("Dead!");  //TODO remove this line
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
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

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))  // Can thrust whilst rotating
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false;  // resume physics control of rotation

        // reapply constraints
        rigidBody.constraints = RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezePositionZ;
    }


}
