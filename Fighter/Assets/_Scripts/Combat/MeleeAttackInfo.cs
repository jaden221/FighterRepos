using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackInfo : MonoBehaviour
{
    public bool canDmg;

    public float damage;

    public List<Transform> hitEnemies = new List<Transform>();

    public void ResetInfo()
    {
        canDmg = false;
        damage = 0;
        hitEnemies.Clear();
    }

    public void SetValues(float Damage)
    {
        damage = Damage;
    }
}
