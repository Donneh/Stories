using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RecordButtonController : MonoBehaviour
{
    bool isRecording = false;
    private AudioSource _audioSource;
    private AudioClip myAudioClip;
    private float storyPart = 1f;

    public void nextPart()
    {
        storyPart += 1;
    }

    public void ChangeRecordStatus()
    {
        if (isRecording)
        {
            isRecording = false;
            Microphone.End(null);
            SavWav.Save("Resources/part-" + storyPart, myAudioClip);
            AssetDatabase.Refresh();
            SetText("Start recording");
        }
        else
        {
            isRecording = true;
            
            myAudioClip = Microphone.Start(null, false, 30, 44100);
            SetText("Stop recording");
        }
    }
    
    void SetText(string buttonText)
    {
        TextMeshProUGUI text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        text.text = buttonText;
    }
}
