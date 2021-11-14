using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;
    public RubyController RubyController;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusicClipThree();
    }
    public void PlayMusicClipOne()
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.PlayOneShot(musicClipOne);
    }
    public void PlayMusicClipTwo()
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.PlayOneShot(musicClipTwo);
    }
    public void PlayMusicClipThree()
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.PlayOneShot(musicClipThree);
    }



    // Update is called once per frame
    void Update()
    {
        if (RubyController.scoreValue >= 4)
        {
            PlayMusicClipOne();
        }
        if (RubyController.currentHealth <= 0)
        {
            PlayMusicClipTwo();
        }
    }
}
