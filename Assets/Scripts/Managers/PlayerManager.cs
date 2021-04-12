using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerStatus { Idle, Move, Pet_Idle, Pet_Move, Attack, Skill, SubAct, Cast}


/// <summary>
/// In-Game character Manager
/// </summary>
public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;


    private int hp;
    private int mp;
    private int stamina;
    private int level;

    private int strenth;        //힘 - 물리 대미지
    private int attention;      //집중력 - 명중률/회피율
    private int intelligence;   //지능 - 마법?
    private int insight;        //통찰력 - 약점 분석
    private int potential;      //잠재력 - 최소/최대 대미지 격차
    private int luck;           //행운 -

    public PlayerStatus PlayerStatus { get { return playerStatus; } set { playerStatus = value; } }

    [SerializeField] private PlayerStatus playerStatus = PlayerStatus.Idle;
    public static PlayerManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(PlayerManager)) as PlayerManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (PlayerManager._instance == null)
            PlayerManager._instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        PlayerStatus = PlayerStatus.Idle;
    }
    

    
}
