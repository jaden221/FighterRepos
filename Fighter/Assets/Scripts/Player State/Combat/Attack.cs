using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;
using Project.Combat;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/Attack")]
    public class Attack : StateData
    {
        public float startAttackTime;
        public float endAttackTime;
        public List<string> colliderNames = new List<string>();
        public List<RuntimeAnimatorController> deathAnimators = new List<RuntimeAnimatorController>();

        public bool mustCollide;
        public bool mustFaceAttacker;
        public float lethalRange;
        public int maxHits;

        CharacterControl characterControl;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl = characterState.GetCharacterControl(animator);
            animator.SetBool(TransitionParameter.Attack.ToString(), false);

            GameObject obj = Instantiate(Resources.Load("AttackInfo", typeof(GameObject))) as GameObject;
            AttackInfo info = obj.GetComponent<AttackInfo>();

            info.ResetInfo(this);

            if (!AttackManager.Instance.currentAttacks.Contains(info))
            {
                AttackManager.Instance.currentAttacks.Add(info);
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            RegisterAttack(characterState,animator,stateInfo);
            DeregisterAttack(characterState, animator, stateInfo);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public void RegisterAttack(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (startAttackTime <= stateInfo.normalizedTime && endAttackTime >= stateInfo.normalizedTime)
            {
                foreach  (AttackInfo info in AttackManager.Instance.currentAttacks)
                {
                    if (info == null)
                    {
                        continue;
                    }

                    if (!info.isRegistered && info.attackAbility == this)
                    {
                        info.Register(this, characterControl);
                    }
                }
            }
        }

        public void DeregisterAttack(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= endAttackTime)
            {
                foreach(AttackInfo info in AttackManager.Instance.currentAttacks)
                {
                    if (info == null)
                    {
                        continue;
                    }
                    if (info.attackAbility == this && !info.isFinished)
                    {
                        info.isFinished = true;
                        Destroy(info.gameObject);
                    }
                }
            }
        }

        public void ClearAttack()
        {
            for (int i = 0; i <AttackManager.Instance.currentAttacks.Count; i++)
            {
                if (AttackManager.Instance.currentAttacks[i] == null || AttackManager.Instance.currentAttacks[i].isFinished)
                {
                    AttackManager.Instance.currentAttacks.RemoveAt(i);
                }
            } 
        }
    }

}
