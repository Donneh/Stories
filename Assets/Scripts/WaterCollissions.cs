using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterCollissions : MonoBehaviour
{

    private float restartDelay = 2f;
    public GameObject levelWon;
    public GameObject levelLost;
        
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (collision.gameObject.tag == "Player")
        {
            
            levelLost.SetActive(true);
            Invoke("LoadGame", restartDelay);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            levelWon.SetActive(true);
            Invoke("LoadGame", restartDelay);
        }
        
        Destroy(other);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("PenguinGameP2");
    }
}
