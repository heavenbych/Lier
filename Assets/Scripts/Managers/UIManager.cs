using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// UI 관련 오브젝트들 매니저
/// </summary>
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public GameObject Cvs_UI;

    public GameObject Joystick;
    public GameObject Combat;
    public GameObject Peace;
    public GameObject Inventory;

    public static UIManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(UIManager)) as UIManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (UIManager._instance == null)
            UIManager._instance = this;
        else if (_instance != this)
            Destroy(gameObject);
        
    }

    public void JoystickOn()
    {
        Joystick.SetActive(true);
    }
    public void JoystickOff()
    {
        Joystick.SetActive(false);
    }
    
    
    /// <summary>
    /// 전투 UI 활성화
    /// </summary>
    public void CombatOn()
    {
        Combat.SetActive(true);
        JoystickOn();
    }


    /// <summary>
    /// 비전투 UI 활성화
    /// </summary>
    public void PeaceOn()
    {
        Peace.SetActive(true);
        JoystickOn();
    }


    /// <summary>
    /// 모든 UI 비활성화, 로딩시 사용
    /// </summary>
    public void DisableAllUI()
    {
        Joystick.SetActive(false);
        Combat.SetActive(false);
        Peace.SetActive(false);
    }
}
