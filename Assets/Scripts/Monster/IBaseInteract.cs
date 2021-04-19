using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseInteract
{
    void Damage(BaseObject target, int damage);
    void Damaged(int damage);

    void Knockback();
}
