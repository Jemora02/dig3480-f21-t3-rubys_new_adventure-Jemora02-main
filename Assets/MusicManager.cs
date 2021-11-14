using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    
    public AudioClip musicClipThree;
    public RubyController RubyController;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySound(musicClipThree);
    }
    public void PlaySound(AudioClip clip)
    {

        audioSource.loop = true;
        audioSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        if (RubyController.scoreValue >= 4)
        {
            audioSource.Stop();
            
        }
        if (RubyController.currentHealth <= 0)
        {
            audioSource.Stop();
        }
    }
}
