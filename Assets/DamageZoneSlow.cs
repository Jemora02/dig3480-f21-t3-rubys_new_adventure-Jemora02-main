using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZoneSlow : MonoBehaviour
{
    public RubyController RubyController;
    public float changeTime = 3.0f;
    public float speed;
    public float currentSpeed;
    float timer;

    void Start()
    {
        timer = changeTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController >();
        timer -= Time.deltaTime;

        if (controller != null)
        {
            controller.ChangeHealth(-1);
            controller.ChangeSpeed(-1);
        }
        if (timer < 0)
        {
            controller.ChangeSpeed(+1);
            timer = changeTime;
        }
    }
    

}