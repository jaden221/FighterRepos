using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/Attack")]
    public class Attack : StateData
    {
        public ColliderStateNames ColStateNames;

        public float windowMin;
        public float windowMax;

        public float damage;
        public float maxHits;
        public float timeBetweenHits;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
            
            characterState.characterControl.attackInfo.ResetInfo(damage, maxHits, timeBetweenHits);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= windowMin && stateInfo.normalizedTime <= windowMax)
            {
                characterState.characterControl.attackInfo.canDmg = true;
                return;
            }

            if (stateInfo.normalizedTime > windowMax)
            {
                characterState.characterControl.attackInfo.canDmg = false;
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

    }

}