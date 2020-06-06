using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfo : MonoBehaviour
{
    public List<Collider> hitBoxes = new List<Collider>();

    public bool canDmg;

    public float damage;
    public float maxHits;
    public float timeBetweenHits;

    public void ResetInfo(float Damage, float MaxHits, float TimeBetweenHits)
    {
        canDmg = false;
        damage = Damage;
        maxHits = MaxHits;
        timeBetweenHits = TimeBetweenHits;

        hitBoxes.Clear();
    }
}
