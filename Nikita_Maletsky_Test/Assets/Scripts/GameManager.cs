using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score = 0;
    public int rightPose;
    void Update()
    {
        score += Time.deltaTime*1;
        
    }
}
