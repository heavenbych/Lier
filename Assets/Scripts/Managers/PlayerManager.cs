using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerStatus { Idle, Move, Pet_Idle, Pet_Move, Attack, Skill, SubAct, Cast}


/// <summary>
/// In-Game character Manager
/// </summary>
public class PlayerManager : BaseCharacter
{
    private static PlayerManager _instance;


    

    public PlayerStatus playerStatus { get { return _playerStatus; } set { _playerStatus = value; } }

    [SerializeField] private PlayerStatus _playerStatus = PlayerStatus.Idle;
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

        playerStatus = PlayerStatus.Idle;
    }
    

    
}
