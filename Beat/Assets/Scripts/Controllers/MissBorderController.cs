using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissBorderController : MonoBehaviour
{
    public AudioClip MissAudioClip;

    protected AudioSource missSound;

    void Start()
    {
        missSound = gameObject.AddComponent<AudioSource>();
        missSound.playOnAwake = false;
        missSound.clip = MissAudioClip;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Beat")
        {
            if (missSound != null)
                missSound.Play();
        }
    }
}
