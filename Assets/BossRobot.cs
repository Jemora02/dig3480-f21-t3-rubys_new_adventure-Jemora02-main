using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRobot : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    public ParticleSystem smokeEffect;
    public Text score;
    public int scoreValue = 0;
    public  RubyController RubyController;
    public AudioSource audioSource;
    public AudioClip Broken;
    public AudioClip Fixed;
    public AudioClip hitSound;
    public AudioClip throwSound;
    public int bossmaxHealth = 5;
    public GameObject projectile2Prefab;


    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;
    public int bosshealth { get { return bosscurrentHealth; } }
    public int bosscurrentHealth;
    Vector2 lookDirection = new Vector2(1, 0);

    
    
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        score.text = scoreValue.ToString();
        audioSource = GetComponent<AudioSource>();
        PlaySound(Broken);
    }

    void Update()
    {
        //remember ! inverse the test, so if broken is true !broken will be false and return won’t be executed.
        if(!broken)
        {
            return;
        }
        
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
            Launch();
        }
        if (bosscurrentHealth <= 0)
        {
            Fix();
        }

    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectile2Prefab, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile2 projectile = projectileObject.GetComponent<Projectile2>();
        projectile.Launch(lookDirection, 300);


        PlaySound(throwSound);
    }
    void FixedUpdate()
    {
        //remember ! inverse the test, so if broken is true !broken will be false and return won’t be executed.
        if(!broken)
        {
            return;
        }
        
        Vector2 position = rigidbody2D.position;
        
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        
        rigidbody2D.MovePosition(position);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController >();

        if (player != null)
        {
            player.ChangeHealth(-2);
        }
    }
    
    //Public because we want to call it from elsewhere like the projectile script
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        //optional if you added the fixed animation
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
        RubyController.scoreValue += 1;
        RubyController.score.text = RubyController.scoreValue.ToString();
        PlaySound(Fixed);
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            PlaySound(hitSound);
            animator.SetTrigger("Hit");
        }
        bosscurrentHealth = Mathf.Clamp(bosscurrentHealth + amount, 0, bossmaxHealth);

    }
    public void PlaySound(AudioClip clip)
    {

        audioSource.PlayOneShot(clip);
    }

}