using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseReset : MonoBehaviour
{
    private PlayerController playerController;
 
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            
            playerController.rightPose = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            playerController.rightPose = 0;
        }
    }
}
