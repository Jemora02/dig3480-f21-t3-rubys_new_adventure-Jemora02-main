using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;
    public AudioSource musicSource;
    public  RubyController RubyController;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = musicClipThree;
            musicSource.Play();
            musicSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (RubyController.scoreValue >= 4)
        {
            musicSource.Stop();
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            musicSource.loop = true;
            
        }
        if (RubyController.currentHealth <= 0)
        {
            musicSource.Stop();
            musicSource.clip = musicClipOne;
            musicSource.Play();
            musicSource.loop = true;
        }
    }
    public void ChangeMusic(AudioClip music)
    {
        
    }
}
