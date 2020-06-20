using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

public class MeleeTriggerDetector : MonoBehaviour
{
    CharacterControl characterControl;
    Collider colliderSelf;

    private void Awake()
    {
        characterControl = transform.root.GetComponent<CharacterControl>();
        colliderSelf = this.GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (colliderSelf.enabled == false || 
            col.transform.root == characterControl.transform || 
            characterControl.meleeAttackInfo.canDmg == false || 
            characterControl.meleeAttackInfo.hitEnemies.Contains(col.transform.root) || 
            !col.transform.root.GetComponent<DamageDetector>())
        {
            return;
        }
        characterControl.meleeAttackInfo.hitEnemies.Add(col.transform.root);
        col.transform.root.GetComponent<EnemyDamagedData>().damageDetector.TakeDamage(characterControl.meleeAttackInfo.damage);
    }

    private void OnTriggerExit(Collider col)
    {
        
    }
}
