using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    public void TakeDamage(float damage)
    {
        Debug.Log(this.name + " Damage : " + damage);
    }

    public void TakeDamageFromBeam(float damage, float stunTime)
    {
        Debug.Log(this.name + " Damage : " + damage + " Stun Time " + stunTime);
    }
}
