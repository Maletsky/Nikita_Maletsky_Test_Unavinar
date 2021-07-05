using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float score = 0;
    public int rightPose;

    private Rigidbody rb;
    [SerializeField]
    private int speed;
    [SerializeField]
    private int speedTarget;
    [SerializeField]
    private Vector2 startPos;
    [SerializeField]
    private Vector2 direction;
    [SerializeField]
    private float rotationF;
   [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform constrution;

    [SerializeField]
    private int rotationAngle;

    [SerializeField]
    private bool rotated;

    [SerializeField]
    private Quaternion target;

    [SerializeField]
    private Text test;

    public bool canCheck = false;
   void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;
        rotationAngle = 0;
    }


    void Update()
    {   
        
        if (rightPose == 0)
        {
            speed = speedTarget*3;
            score += Time.deltaTime * 1;
        }
        else
        {
            speed = speedTarget;
        }
        test.text = ("Score:" + score);

        rb.AddForce(Vector3.forward * speed);

        rotationF = direction.x / 4;

        if (rotationF >= 50 && !rotated)
        {
            rotated = true;
            rotationAngle += 90;
        }
        if (rotationF <= -50 && !rotated)
        {
            rotated = true;
            rotationAngle -= 90;
        }
        
            
       target = Quaternion.Euler(0, rotationAngle, 0);

        constrution.rotation = Quaternion.Slerp(constrution.rotation, target, Time.deltaTime * rotationSpeed);
      



        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            switch (touch.phase)
            {

                case TouchPhase.Began:
                    rotated = false;

                    startPos = touch.position;

                    break;


                case TouchPhase.Moved:

                    direction = touch.position - startPos;

                    break;

               
            }
        }
    }
}
