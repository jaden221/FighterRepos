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
            //Make a check that checks if this characterState has Strafe or not which will determine what approach to take? Or keep it in strafe probably...
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            IncreaseTimeToDodge(characterState);

            if (isStrafing() && !characterState.characterControl.isStandingStill()) 
            {
                animator.SetBool(TransitionParameter.Strafe.ToString(), true);
            }

            if (!isStrafing() || characterState.characterControl.isStandingStill()) 
            {
                animator.SetBool(TransitionParameter.Strafe.ToString(), false);
            }
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
        public bool isStrafing()
        {
            if (timeToDodge > windowToDodge)
            {
                return true;
            }
            else return false;
            
        }

        public bool isDodging(CharacterState characterState)
        {
            if (timeToDodge < windowToDodge && timeToDodge > Mathf.Epsilon && characterState.characterControl.strafe == false)
            {
                Debug.Log("Got to 2nd IF ");
                timeToDodge = 0;
                return true;
            }
            else return false;
        }

        public void  IncreaseTimeToDodge(CharacterState characterState)
        {
            if (characterState.characterControl.strafe)
            {
                timeToDodge += Time.deltaTime;
            }
        }
    }
}

