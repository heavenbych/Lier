using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Manager about Dungeon's Stage Status
/// Ex) Stage1, Bossroom, etc...
/// </summary>
public enum StageStatus { None, Room, Stage1, Stage2, Stage3, Stage4, Boss }
public class StageManager : MonoBehaviour
{
    private static StageManager _instance;

    public StageStatus StageStatus { get { return StageStatus; } set { stageStatus = value; } }

    [SerializeField] private StageStatus stageStatus;

    public static StageManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(StageManager)) as StageManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (StageManager._instance == null)
            StageManager._instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        StageStatus = StageStatus.None;
    }

    private void Update()
    {
        
    }


    
}
