using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monster, Player's Base Info
/// </summary>
public abstract class BaseObject : MonoBehaviour, IBaseInteract
{
    public enum ObjectType { None, Character, Monster, NPC, Feature };
    public ObjectType objectType { get { return _objectType; } set { _objectType = value; } }
    [SerializeField] private ObjectType _objectType = ObjectType.None;


    [System.Serializable] protected struct Stats
    {
        public int current_hp;             //생명력
        public int current_mp;             //마나
        public int current_stamina;        //스태미나
        public int level;          //레벨
        public int exp;            //경험치

        public int strenth;        //힘 - 물리 대미지
        public int attention;      //집중력 - 명중률/회피율
        public int intelligence;   //지능 - 마법?
        public int insight;        //통찰력 - 약점 분석
        public int potential;      //잠재력 - 최소/최대 대미지 격차
        public int luck;           //행운 -
    };      //Object Base Stats


    [SerializeField] protected Stats stats;
    [SerializeField] protected GameObject baseGameObject;
    [SerializeField] protected Collider2D baseCol;
    [SerializeField] protected Rigidbody2D baseRbody;

    //Give damage to others
    public void Damage(BaseObject target, int damage)
    {
        target.Damaged(damage);
    }

    //Get damage by others
    public void Damaged(int damage)
    {
        this.stats.current_hp -= damage;
    }

    public void Knockback()
    {
        baseRbody.AddForce(new Vector2(100,100));
    }
}
