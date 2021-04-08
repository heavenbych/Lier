using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// 
/// </summary>
/// <param name="Idle">YEE</param>
public enum PlayerStatus { Idle, Walk, Pet_Idle, Pet_Move, Charging, Operating, Skill, Action}


/// <summary>
/// In-Game character Manager
/// </summary>
public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;

    public PlayerStatus PlayerStatus { get { return PlayerStatus; } set { playerStatus = value; } }

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
    }
    
}
