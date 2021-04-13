using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Overall Game's Running Status
/// </summary>
public enum GameStatus { Intro, Server, Character, Loading, InGame}

public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance;
    public int frame = 60;
    public GameStatus gameStatus { get { return _gameStatus; } set { _gameStatus = value; } }

    [SerializeField] private GameStatus _gameStatus = GameStatus.Intro;


    public static GameManager Instance
    {
        get {
            if(!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (GameManager._instance == null)
            GameManager._instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        _gameStatus = GameStatus.Intro;
        
    }

    private void Update()
    {
        Application.targetFrameRate = frame;

    }
}
