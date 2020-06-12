using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    public void TakeDamage(float damage)
    {
        Debug.Log(this.name + " took this amount of damage: " + damage);
    }
}
