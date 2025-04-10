using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletLife = 2f;
    public AudioClip destructionSound;
    public float destructionSoundVolume = 1.0f;

    private void Awake()
    {

        Destroy(gameObject, BulletLife);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (destructionSound != null)
        {
            PlayGlobalSound(destructionSound, destructionSoundVolume);
        }


        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }

    private void PlayGlobalSound(AudioClip clip, float volume)
    {
        GameObject soundObject = new GameObject("TempAudio");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.spatialBlend = 0.0f;
        audioSource.Play();


        Destroy(soundObject, clip.length);
    }
}

