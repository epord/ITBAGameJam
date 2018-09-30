using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource _audioSource;

    //All Sounds
    public AudioClip jump;
    public AudioClip shoot;
    public AudioClip level;
    public AudioClip levelLong;
    public AudioClip win;
    public AudioClip loss;
    public AudioClip hit;
    public AudioClip timeOut;

    private void Start()
    {
        
    }


    public void PlayLevel()
    {
        _audioSource.volume = 1;
        _audioSource.PlayOneShot(level);
    }

    public void PlayLevelLong()
    {
        _audioSource.volume = 1;
        _audioSource.loop = true;
        _audioSource.clip = levelLong;
        _audioSource.Play();
    }

    public void PlayHit()
    {
        _audioSource.volume = 1;
        _audioSource.PlayOneShot(hit);
    }

    public void PlayTimeOut()
    {
        _audioSource.volume = 0.25f;
        _audioSource.PlayOneShot(timeOut);
    }

    public void PlayJump()
    {
        _audioSource.volume = 0.6f;
        _audioSource.PlayOneShot(jump);
    }

    public void PlayShoot()
    {
        _audioSource.volume = 1;
        _audioSource.PlayOneShot(shoot);
    }

    public void PlayWin()
    {
        _audioSource.volume = 0.1f;
        _audioSource.PlayOneShot(win);
    }

    public void PlayLoss()
    {
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(loss);
    }
}
