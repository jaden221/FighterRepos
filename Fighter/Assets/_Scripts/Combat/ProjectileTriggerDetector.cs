using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

public class ProjectileTriggerDetector : MonoBehaviour
{
    CharacterControl characterControl;

    private void OnTriggerStay(Collider col)
    {
        if (col.transform.root == characterControl.transform ||
            characterControl.beamAttackInfo.hitEnemies.Contains(col.transform.root) ||
            !col.transform.root.GetComponent<DamageDetector>())
        {
            return;
        }
        characterControl.beamAttackInfo.hitEnemies.Add(col.transform.root);
        col.transform.root.GetComponent<EnemyDamagedData>().damageDetector.TakeDamageFromBeam(characterControl.beamAttackInfo.damage, characterControl.beamAttackInfo.stunTime);
    }
}
