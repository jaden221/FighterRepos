using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

public class TriggerDetectorMelee : MonoBehaviour
{
    CharacterControl characterControl;
    public Collider colliderSelf;

    private void Awake()
    {
        characterControl = transform.root.GetComponent<CharacterControl>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (colliderSelf.enabled == false || col.transform.root == characterControl.transform || characterControl.attackInfo.canDmg == false || characterControl.attackInfo.hitEnemies.Contains(col.transform.root))
        {
            return;
        }
        characterControl.attackInfo.hitEnemies.Add(col.transform.root);
        col.transform.root.GetComponent<EnemyDamagedData>().damageDetector.TakeDamage(characterControl.attackInfo.damage);
    }

    private void OnTriggerExit(Collider col)
    {
        
    }
}
