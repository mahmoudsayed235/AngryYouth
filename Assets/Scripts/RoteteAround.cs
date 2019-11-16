using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteteAround : MonoBehaviour
{
    public int speed = 200;
     AudioSource audio;
    public AudioClip FruiteClip;
    void Update()
    {
        gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.loop = false;
        audio = gameObject.GetComponent<AudioSource>();
        audio.clip = FruiteClip;
        SwingOpen();
    }
    void SwingOpen()
    {
        transform.RotateAround(this.transform.position, Vector3.up, speed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audio.Play();
            gameObject.SetActive(false);
        }
    }
  
}
