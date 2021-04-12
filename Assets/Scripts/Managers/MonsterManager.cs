using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    private static MonsterManager _instance;


    public static MonsterManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(MonsterManager)) as MonsterManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (MonsterManager._instance == null)
            MonsterManager._instance = this;
        else if (_instance != this)
            Destroy(gameObject);
    }


}

