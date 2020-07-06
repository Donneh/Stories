using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    private float storyPart = 1;

    private void Start()
    {
        getText();
    }

    public void nextPart()
    {
        storyPart += 1;
        if (storyPart < 4)
        {
            getText();
        }
        else
        {
            
            SceneManager.LoadScene("MainMenu");
        }
    }

    void getText()
    {
        string path = "Assets/Story/" + storyPart + ".txt";
        StreamReader reader = new StreamReader(path);
        GetComponent<TMPro.TextMeshProUGUI>().text = reader.ReadToEnd();
        Debug.Log(reader.ReadToEnd());
        
        reader.Close();
    }
}
