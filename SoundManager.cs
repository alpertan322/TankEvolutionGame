using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    
    [SerializeField] private AudioClip fireSoundEffect;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip crushSound;
    [SerializeField] private float fireSpeed;
    
    [SerializeField] private float SLOW_FIRE_SPEED;
    [SerializeField] private float MID_FIRE_SPEED;
    [SerializeField] private float HIGH_FIRE_SPEED;

    
    private bool isFire;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
    
        isFire = false;
        fireSpeed = 2;
    }

    public void PlayWinSound()
    {
        _audioSource.PlayOneShot(winSound);
    }
    public void PlayBreakSound()
    {
        _audioSource.PlayOneShot(crushSound);
    }

    public void PlayFireSoundEffect(float shootingRate)
    {

        fireSpeed = shootingRate * fireSpeed;
        if (fireSpeed > 11)
        {
            fireSpeed = 11;
        }
        isFire = true;
        StartCoroutine(HandleFire());

    }

    public void UpdateFireSoundRate(float shootingRate)
    {
        fireSpeed = shootingRate * fireSpeed;
        if (fireSpeed > 11)
        {
            fireSpeed = 11;
        }
    }
    IEnumerator HandleFire()
    {
        _audioSource.PlayOneShot(fireSoundEffect);
        yield return new WaitForSeconds(1/fireSpeed);

        if (isFire)
        {
            StartCoroutine(HandleFire());
        }
    }

    public void StopFire()
    {
        isFire = false;
    }
}