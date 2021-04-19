using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool isAttacked = false;
    void OnTriggerStay2D(Collider2D other)
    {
        IBaseInteract obj = other.transform.parent.GetComponent<IBaseInteract>();
        IBaseMobAct mob = other.transform.parent.GetComponent<IBaseMobAct>();
        if (PlayerManager.Instance.playerStatus.Equals(PlayerStatus.Attack) && mob != null && !isAttacked)
        {
            isAttacked = true;
            StartCoroutine("Touch");
            obj.Damaged(10);
            obj.Knockback();
        }

    }

    IEnumerator Touch()
    {

        yield return new WaitForSeconds(0.5f);
        isAttacked = false;
    }
}
