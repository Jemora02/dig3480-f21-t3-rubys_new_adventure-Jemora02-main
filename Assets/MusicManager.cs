using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;
    private AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rubycontroller.scoreValue >= 4)
        {
            audioSource.Stop();
            audioSource.loop = true;
            audioSource.PlayOneShot(MusicClipOne);

        }
        if (Rubycontroller.currentHealth <= 0)
        {
            audioSource.Stop();
            audioSource.loop = true;
            audioSource.PlayOneShot(musicClipTwo);
        }
    }
}
