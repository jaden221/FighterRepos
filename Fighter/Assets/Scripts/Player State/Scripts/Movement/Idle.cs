﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/Idle")]
    public class Idle : StateData
    {
        CheckStrafeOrDodge checkStrafeOrDodge = null;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (characterState.characterControl.attack)
            {
                animator.SetBool(TransitionParameter.Attack.ToString(), true);
            }

            if (characterState.characterControl.jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (characterState.characterControl.isStandingStill() && !characterState.characterControl.strafe)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!characterState.characterControl.isStandingStill() && !characterState.characterControl.strafe)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}

