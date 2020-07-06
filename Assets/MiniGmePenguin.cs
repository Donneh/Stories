using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGmePenguin : MonoBehaviour
{
    public CharacterController player;
    
    private void OnMouseDown()
    {
        Vector3 playerPos = player.transform.position;
        float distance = Vector3.Distance(playerPos, transform.position);
        if (distance < 5)
        {
            SceneManager.LoadScene("SnowballGame");
        }
    }
}
