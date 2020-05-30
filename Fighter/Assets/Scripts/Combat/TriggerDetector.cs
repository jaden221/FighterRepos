using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

public class TriggerDetector : MonoBehaviour
{
    CharacterControl characterControl;
    Collider self;

    private void Awake()
    {
        characterControl = transform.root.GetComponent<CharacterControl>();
        self = this.GetComponent<Collider>();
    }
    //For self detecting hit on enemy and passing col info to characterControl
    private void OnTriggerEnter(Collider col)
    {
        if (AttackManager.Instance.attackInfo.hitBoxes.Count == 0 || !AttackManager.Instance.attackInfo.hitBoxes.Contains(self) || characterControl.collidingParts.Contains(col))
        {
            Debug.Log("Here 1");
            return;
        }
        CharacterControl control = col.transform.root.GetComponent<CharacterControl>();
        if (control == null || characterControl == control)
        {
            Debug.Log("Here 2");
            return;
        }
        characterControl.collidingParts.Add(col);
        Debug.Log("Here 3");
        //Attack will use take damage, trigger will only give data, not process
        //col.transform.root.GetComponent<DamageDetector>().TakeDamage(AttackManager.Instance.attackInfo.damage);
    }

    private void OnTriggerExit(Collider col)
    {
        if (characterControl.collidingParts.Contains(col))
        {
            characterControl.collidingParts.Remove(col);
        }
    }
}
