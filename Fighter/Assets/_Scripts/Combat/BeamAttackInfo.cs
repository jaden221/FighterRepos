using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

public class BeamAttackInfo : MonoBehaviour
{
    public float damage;

    public List<Transform> hitEnemies = new List<Transform>();

    public float currentWindow;

    public float stunTime;

    public void ResetInfo()
    {
        damage = 0;
        stunTime = 0;
        currentWindow = 0;
        hitEnemies.Clear();
    }

    public void SetValues(float Damage, float StunTime)
    {
        damage = Damage;
        stunTime = StunTime;
    }

    public void IncrementCurrentWindow()
    {
        currentWindow++;
        hitEnemies.Clear();
    }
}
