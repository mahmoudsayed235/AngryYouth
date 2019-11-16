using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBagSounds : MonoBehaviour
{
    public AudioSource audioSource;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
    }
}
