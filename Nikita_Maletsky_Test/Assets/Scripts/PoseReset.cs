using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseReset : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField]
    private int poseTarget;
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            
            playerController.rightPose = poseTarget;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            playerController.rightPose = poseTarget;
        }
    }
}
