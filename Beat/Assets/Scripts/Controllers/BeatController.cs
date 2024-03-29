﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BeatController : MonoBehaviour
{
    public float SpeedForward = 500;
    public float SpeedBackwards = 500;
    public AudioClip HitAudioClip;
    public AudioClip ReturnAudioClip;
    public float Volume = 1.0f;

    protected Rigidbody2D beatRigidbody;
    protected AudioSource hitSound;
    protected AudioSource returnSound;
    protected bool isHitBack = false;
    public void Initialize()
    {
        var audioSources = gameObject.GetComponents<AudioSource>();

        if (audioSources != null)
            foreach (var audioSource in audioSources)
                Destroy(audioSource);

        if (HitAudioClip != null)
        {
            hitSound = gameObject.AddComponent<AudioSource>();
            hitSound.playOnAwake = false;
            hitSound.clip = HitAudioClip;
            hitSound.volume = Volume;
        }

        if (ReturnAudioClip != null)
        {
            returnSound = gameObject.AddComponent<AudioSource>();
            returnSound.playOnAwake = false;
            returnSound.clip = ReturnAudioClip;
            returnSound.volume = Volume;
        }

        beatRigidbody = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isHitBack)
        {
            isHitBack = true;
            beatRigidbody.AddForce(new Vector2(SpeedBackwards + SpeedForward, 0));
            if (hitSound != null)
                hitSound.Play();
        }
        if (collision.gameObject.tag == "Returned Border")
        {
            if (returnSound != null)
                returnSound.Play();
        }
    } 

    public void Shoot()
    {
        isHitBack = false;
        beatRigidbody.AddForce(new Vector2(-SpeedForward, 0));
    }

    public void Stop()
    {
        beatRigidbody.velocity = Vector3.zero;
    }
}
