using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monster's Base Class
/// </summary>
public abstract class BaseMonster : BaseObject, IBaseMobAct
{
    
    public enum MonsterType { Normal, Elite, Boss }
    public MonsterType monsterType { get { return _monsterType; } set { _monsterType = value; } }
    [SerializeField] private MonsterType _monsterType;


    public enum MonsterStatus { Idle, Move, Attack, Hit }
    public MonsterStatus monsterStatus { get { return _monsterStatus; } set { _monsterStatus = value; } }
    [SerializeField] private MonsterStatus _monsterStatus = MonsterStatus.Idle;






    [SerializeField] protected Vector2 currentPos;
    [SerializeField] protected Vector2 movement;
    [SerializeField] protected Vector2 newPos;

    protected bool isDirChanged;                        //Check Direction changed
    [SerializeField] protected float speed = 0.5f;      //Monster Movement Speed



    
    public void ResetPos()
    {
        baseGameObject.transform.position = Vector2.zero;
    }
    public void Move()              //Make Mob Move
    {
        if (!isDirChanged)
        {
            isDirChanged = true;
            StartCoroutine("ISetMobVector");
        }
        currentPos = baseRbody.position;
        newPos = currentPos + movement * Time.fixedDeltaTime * speed;
        baseRbody.MovePosition(newPos);
    }
    IEnumerator ISetMobVector()     //Set Mob's Vector random
    {
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        yield return new WaitForSeconds(Random.Range(1f,2f));
        isDirChanged = false;
    }
}
