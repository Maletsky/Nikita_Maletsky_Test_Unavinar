using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float score = 0;
    [SerializeField]
    private int pose;
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
    private Text ScoreText;
    [SerializeField]
    private GameObject RestartBut;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;
        rotationAngle = 0;
    }


    private void Update()
    {   
        
        if (pose == rightPose)
        {
            speed = speedTarget*10;
            score += Time.deltaTime * 1;
        }
        else
        {
            speed = speedTarget;
        }
        ScoreText.text = ("Score:" + score);

        rb.AddForce(Vector3.forward * speed);

       

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
        
        if (constrution.eulerAngles.y > -10 && constrution.eulerAngles.y < 10)
        {
            pose = 0;
        }
        if (constrution.eulerAngles.y > 80 && constrution.eulerAngles.y < 100)
        {
            pose = 1;
        }
        if (constrution.eulerAngles.y > 170 && constrution.eulerAngles.y < 190)
        {
            pose = 2;
        }
        if (constrution.eulerAngles.y > 260 && constrution.eulerAngles.y < 280)
        {
            pose = 3;
        }


        target = Quaternion.Euler(0, rotationAngle, 0);

        constrution.rotation = Quaternion.Slerp(constrution.rotation, target, Time.deltaTime * rotationSpeed);
      



        if (Input.touchCount > 0 && speedTarget != 0)
        {
            Touch touch = Input.GetTouch(0);
           

            switch (touch.phase)
            {

                case TouchPhase.Began:
                    rotationF = 0;
                    rotated = false;

                    startPos = touch.position;

                    break;


                case TouchPhase.Moved:

                    direction = touch.position - startPos;
                    rotationF = direction.x / 4;
                    break;

               
            }
        }
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Finish")
        {
            speedTarget = 0;
            RestartBut.SetActive(true);
        }
    }
    public void RestartLevel ()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
