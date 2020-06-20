using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    public class AttackProjectile : StateData
    {
        public float damage;

        public float stunTime;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }

}