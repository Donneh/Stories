﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 15;
    public float height = 5;
    public float heightDamping = 3;
    
    void Update () {
        if (target){
            float wantedHeight = target.position.y + height;
                 
            float currentHeight = transform.position.y;
            
         
            // Damp the height
            currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
         
            Vector3 pos = target.position;
            pos -= Vector3.forward * distance;
            pos.y = currentHeight;
            transform.position = pos;
             
            transform.LookAt (target);
        }
    }
}
