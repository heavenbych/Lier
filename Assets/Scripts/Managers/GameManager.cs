using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameStatus { Intro, Server, Character, Loading, InGame}

public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance;
    public int frame = 60;
    public GameStatus GameStatus { get { return GameStatus; } set { gameStatus = value; } }

    [SerializeField] private GameStatus gameStatus = GameStatus.Intro;


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

        gameStatus = GameStatus.Intro;
    }

    private void Update()
    {
        Application.targetFrameRate = frame;

    }
}
