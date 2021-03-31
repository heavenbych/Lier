using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllManager : MonoBehaviour
{
    private static ControllManager _instance;

    public VariableJoystick variableJoystick;
    public static ControllManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(ControllManager)) as ControllManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (ControllManager._instance == null)
            ControllManager._instance = this;
        else if (_instance != this)
            Destroy(gameObject);
    }
}
