using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/AttackInfo")]
public class AttackInfo : ScriptableObject
{
    bool isRegistered;
    bool isFinished;
    bool canDmg;

    public float damage;

    public List<Collider> hitBoxes = new List<Collider>();

    public void ResetInfo(List<Collider> HitBoxes, float Damage)
    {
        isRegistered = false;
        isFinished = false;
        canDmg = false;
        damage = Damage;
        CopyHitBoxList(HitBoxes);
    }

    private void CopyHitBoxList(List<Collider> HitBoxes)
    {
        hitBoxes.Clear();
        foreach (Collider col in HitBoxes)
        {
            hitBoxes.Add(col);
        }
        Debug.Log("Here now 2");
    }
}
