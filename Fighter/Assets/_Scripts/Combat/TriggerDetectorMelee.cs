using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

public class TriggerDetectorMelee : MonoBehaviour
{
    CharacterControl characterControl;
    List<Transform> hitEnemies = new List<Transform>();
    public Collider colliderSelf;

    private void Awake()
    {
        characterControl = transform.root.GetComponent<CharacterControl>();
    }
    //For self detecting hit on enemy and passing col info to characterControl
    private void OnTriggerEnter(Collider col)
    {
        if (colliderSelf.enabled == false || col.transform.root == characterControl.transform || characterControl.attackInfo.canDmg == false || hitEnemies.Contains(col.transform))
        {
            return;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        
    }
}
