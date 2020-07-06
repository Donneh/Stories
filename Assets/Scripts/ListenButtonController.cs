using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenButtonController : MonoBehaviour
{

    private float storyPart = 1;

    public void nextPart()
    {
        storyPart += 1;
    }

    public void PlayAudio()
    {
        AudioClip clip = (AudioClip)Resources.Load("part-" + storyPart);
        GetComponent<AudioSource>().PlayOneShot(clip);

    }
}
