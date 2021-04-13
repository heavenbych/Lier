using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseObject : MonoBehaviour, IBaseInteract
{
    protected enum ObjectType { None, Player, Monster, NPC, Deco };
    protected struct Stats
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
    };
    protected struct Coord
    {
        public float x;
        public float y;
        public float z;

        public Coord(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }

    [SerializeField]
    protected ObjectType objectType;
    protected Stats stats;
    protected Coord coord;

    protected void reset_Base()
    {
        objectType = ObjectType.None;
    }

}
