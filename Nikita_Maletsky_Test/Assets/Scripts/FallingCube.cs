using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField]
    private bool isPlayer = false;
    private bool NoPlayer = false;
    private bool stopChecking = false;
    private Rigidbody rb;
    private void Start ()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();

    }
    private void FixedUpdate ()
    {
        Vector3 bwd = transform.TransformDirection(Vector3.back);

        RaycastHit hit;

        if (!stopChecking)
        {
            if (Physics.Raycast(transform.position, bwd, out hit, 35))
            {

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * 35, Color.red);

                NoPlayer = false;
                if (!isPlayer)
                {
                    isPlayer = true;
                    playerController.rightPose -= 1;
                }

            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * 35, Color.white);
                isPlayer = false;
                if (!NoPlayer)
                {
                    NoPlayer = true;
                    playerController.rightPose += 1;
                }


            }
        }
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            stopChecking = true;
            Debug.Log("Here's Player!");
            rb.isKinematic = false;
        }
    }
}
