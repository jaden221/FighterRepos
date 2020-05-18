using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/IsMoving")]
    public class IsMoving : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

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