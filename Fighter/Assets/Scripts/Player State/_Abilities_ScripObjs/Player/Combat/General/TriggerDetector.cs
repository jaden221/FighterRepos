using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core
{
    public class TriggerDetector : MonoBehaviour
    {
        private CharacterControl owner;

        private void Awake()
        {
            owner = GetComponentInParent<CharacterControl>();
        }

        private void OnTriggerEnter(Collider col)
        {
            if (owner.ragdollParts.Contains(col)) return;

            CharacterControl attacker = col.transform.root.GetComponent<CharacterControl>();

            if (attacker == null || col.gameObject == attacker.gameObject) return;

            if (!owner.collidingParts.Contains(col))
            {
                owner.collidingParts.Add(col);
            }
        }

        private void OnTriggerExit(Collider attacker)
        {
            if (owner.collidingParts.Contains(attacker))
            {
                owner.collidingParts.Remove(attacker);
            }
        }
    }
}