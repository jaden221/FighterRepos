using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;
using Project.State;
using System;

namespace Project.Combat
{
    public class DamageDetector : MonoBehaviour
    {
        CharacterControl characterControl;

        private void Awake()
        {
            characterControl = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            if (AttackManager.Instance.currentAttacks.Count > 0)
            {
                CheckAttack();
            }
        }

        private void CheckAttack()
        {
            foreach (AttackInfo info in AttackManager.Instance.currentAttacks)
            {
                if (info == null || !info.isRegistered || info.isFinished || info.currentHits >= info.maxHits || info.attacker == characterControl)
                {
                    continue;
                }
                
                if (info.mustCollide)
                {
                    if (isCollided(info))
                    {
                        TakeDamage(info);
                    }
                }
            }
        }

        private bool isCollided(AttackInfo info)
        {
            foreach (Collider col in characterControl.collidingParts)
            {
                foreach(string name in info.colliderNames)
                {
                    if (name == col.gameObject.name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void TakeDamage(AttackInfo info)
        {
            Debug.Log(info.attacker.gameObject.name + " hits: " + this.gameObject.name);
            characterControl.SkinnedMeshAnimator.runtimeAnimatorController = info.attackAbility.GetDeathAnimator();
            info.currentHits++;

            characterControl.GetComponent<BoxCollider>().enabled = false;
            characterControl.myRigidbody.useGravity = false;
        }

    }
}

