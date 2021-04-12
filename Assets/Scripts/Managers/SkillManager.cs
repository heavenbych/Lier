using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Skill management Class
/// </summary>
public class SkillManager : MonoBehaviour
{
    private static SkillManager _instance;

    private bool isDashOn;
    [SerializeField]
    public bool isDashing;
    private static float DASHCOOLDOWN = 2f;

    private bool isAttackOn;
    [SerializeField]
    public bool isAttacking;

    private static float ATTACKCOOLDOWN = 0.5f;
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
        isAttackOn = true;
        isAttacking = false;
    }

    public void Attack()
    {
        if(isAttackOn&&
            PlayerManager.Instance.PlayerStatus==PlayerStatus.Idle)
        {
            isAttackOn = false;
            isAttacking = true;

            PlayerManager.Instance.PlayerStatus = PlayerStatus.Attack;
            Invoke("AttackCooldown", ATTACKCOOLDOWN);
        } else
        {
            print("AttackCD");
        }
    }
    private void AttackCooldown()
    {
        isAttackOn = true;
    }
    public void Dash()
    {
        if(isDashOn)
        {
            isDashOn = false;
            PlayerManager.Instance.PlayerStatus = PlayerStatus.SubAct;
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


