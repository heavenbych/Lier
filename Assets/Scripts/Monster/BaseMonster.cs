using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : BaseObject, IBaseMobAct
{
    Vector2 currentPos;
    public Vector2 movement;
    Vector2 newPos;
    public bool isRun;
    public Rigidbody2D rbody;
    public GameObject gb;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();

        isRun = false;
    }
    private void FixedUpdate()
    {
        if (!isRun)
        {
            isRun = true;
            StartCoroutine("setVector");

        }
        currentPos = rbody.position;
        newPos = currentPos + movement * Time.fixedDeltaTime;
        rbody.MovePosition(newPos);
        Move();
    }
    public void Move()
    {
        
    }
    IEnumerator setVector()
    {
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        print(gb.name);
        yield return new WaitForSeconds(2f);
        isRun = false;
    }
}
