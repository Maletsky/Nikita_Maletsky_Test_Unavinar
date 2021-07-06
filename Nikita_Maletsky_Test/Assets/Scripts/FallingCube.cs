using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource aud;
    private void Start ()
    {

        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();

    }
   
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            aud.Play();
            Debug.Log("Here's Player!");
            rb.isKinematic = false;
        }
    }
}
