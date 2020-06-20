using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttackInfo : MonoBehaviour
{
    public float damage;

    public float stunTime;

    public void ResetInfo()
    {
        damage = 0;
        stunTime = 0;
    }

    public void SetValues(float Damage, float StunTime)
    {
        damage = Damage;
        stunTime = StunTime;
    }
}
