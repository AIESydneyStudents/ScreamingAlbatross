using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public AudioSource audioTest;
    public AudioClip audioData;

    public void PlaySound()
    {
        audioTest.PlayOneShot(audioData);
    }
}
