using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winmusic : MonoBehaviour
{
    public AudioClip musicClipOne;
    public AudioSource musicSource;
    public  RubyController RubyController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RubyController.scoreValue >= 4)
        {
            musicSource.clip = musicClipOne;
            musicSource.Play();
            musicSource.loop = true;
        }
    }
}
