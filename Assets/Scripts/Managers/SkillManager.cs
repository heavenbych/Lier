using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static SkillManager _instance;

    private bool isDashOn;
    public bool isDashing;
    private static float DASHCOOLDOWN = 2f;

    public static SkillManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(SkillManager)) as SkillManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (SkillManager._instance == null)
            SkillManager._instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        isDashOn = true;
        isDashing = false;
    }


    public void Dash()
    {
        if(isDashOn)
        {
            isDashOn = false;
            isDashing = true;
            Invoke("DashCooldown", DASHCOOLDOWN);
        } else
        {
            print("COOLDOWN");
        }
        
    }

    private void DashCooldown()
    {
        isDashOn = true;
    }
}


