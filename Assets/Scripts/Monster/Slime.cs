using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : BaseMonster
{
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();

        isDirChanged = false;

        this.objectType = ObjectType.Monster;
    }

    private void FixedUpdate()
    {
        
        
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        
    }


    private void OnEnable()
    {
        print("Enabled");
        rbody = GetComponent<Rigidbody2D>();

        isDirChanged = false;

        this.objectType = ObjectType.Monster;

    }
    private void OnDisable()
    {
        Reset();
        SlimeReset();
        StopAllCoroutines();
    }

    private void SlimeReset()
    {
        this.stats.current_hp = 50;
        this.stats.current_mp = 10;
        this.stats.current_stamina = 40;
        this.stats.level = 1;
        this.stats.exp = 2;

    }
}
