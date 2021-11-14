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
        if (Ruby Controller.scoreValue >= 4)
        {
            winTextObject.SetActive(true);
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            musicSource.loop = true;

        }
        if (Rubycontroller.currentHealth <= 0)
        {
            loseTextObject.SetActive(true);
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
            musicSource.clip = musicClipOne;
            musicSource.Play();
            musicSource.loop = true;
    }
}
