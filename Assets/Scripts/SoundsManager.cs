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


    public void PlayLevel()
    {
        _audioSource.PlayOneShot(level);
    }

    public void PlayLevelLong()
    {
        _audioSource.loop = true;
        _audioSource.clip = levelLong;
        _audioSource.Play();
    }

    public void PlayHit()
    {
        _audioSource.PlayOneShot(hit);
    }

    public void PlayTimeOut()
    {
        _audioSource.PlayOneShot(timeOut);
    }

    public void PlayJump()
    {
        _audioSource.PlayOneShot(jump);
    }

    public void PlayShoot()
    {
        _audioSource.PlayOneShot(shoot);
    }

    public void PlayWin()
    {
        _audioSource.PlayOneShot(win);
    }

    public void PlayLoss()
    {
        _audioSource.PlayOneShot(loss);
    }
}
