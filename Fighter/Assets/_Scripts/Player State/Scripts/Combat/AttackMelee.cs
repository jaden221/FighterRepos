using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/AttackMelee")]
    public class AttackMelee : StateData
    {
        public float damage;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
            characterState.characterControl.meleeAttackInfo.ResetInfo();
            characterState.characterControl.meleeAttackInfo.SetValues(damage);
            characterState.characterControl.meleeAttackInfo.canDmg = true;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.characterControl.meleeAttackInfo.ResetInfo();
        }

    }

}