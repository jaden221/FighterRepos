using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/CheckStrafeOrDodge")]
    public class CheckStrafeOrDodge : StateData
    {
        public float windowToDodge;
        float timeToDodge;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            timeToDodge = 0;
            animator.SetBool(TransitionParameter.DodgeBackward.ToString(), false);
            animator.SetBool(TransitionParameter.DodgeForward.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            IncreaseTimeToDodge(characterState);
            Strafe(characterState, animator);
            Dodge(characterState, animator);
            // if holding direction and is dodging then turn on canBackstepLeft or canBackstepRight depending on which one
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        /// <summary>
        /// If returns true then character can strafe, if returned false can dodge. Set timeToDodge to 0 if false
        /// </summary>
        /// <param name="windowToDodge"></param>
        /// <param name="timeToDodge"></param>
        /// <returns></returns>
        private bool isStrafing()
        {
            if (timeToDodge > windowToDodge)
            {
                return true;
            }
            else return false;
        }

        private void Strafe(CharacterState characterState, Animator animator)
        {
            if (isStrafing() && !characterState.characterControl.isStandingStill())
            {
                animator.SetBool(TransitionParameter.Strafe.ToString(), true);
            }

            if (!isStrafing() || characterState.characterControl.isStandingStill())
            {
                animator.SetBool(TransitionParameter.Strafe.ToString(), false);
            }
        }

        private bool isDodging(CharacterState characterState)
        {
            if (timeToDodge < windowToDodge && timeToDodge > Mathf.Epsilon && characterState.characterControl.strafe == false)
            {
                return true;
            }
            else return false;
        }

        private void Dodge(CharacterState characterState, Animator animator)
        {
            if (isDodging(characterState) && characterState.characterControl.isStandingStill())
            {
                animator.SetBool(TransitionParameter.DodgeBackward.ToString(), true);
            }

            if (isDodging(characterState) && !characterState.characterControl.isStandingStill())
            {
                animator.SetBool(TransitionParameter.DodgeForward.ToString(), true);
            }

            if (isDodging(characterState) && characterState.characterControl.moveLeft)
            {
                animator.SetBool(TransitionParameter.DodgeBackward.ToString(), true);
            }

            if (isDodging(characterState) && characterState.characterControl.moveRight)
            {
                animator.SetBool(TransitionParameter.DodgeBackward.ToString(), true);
            }
        }

        private void  IncreaseTimeToDodge(CharacterState characterState)
        {
            if (characterState.characterControl.strafe)
            {
                timeToDodge += Time.deltaTime;
            }
        }
    }
}

