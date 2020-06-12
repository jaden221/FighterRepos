using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/IsTurning")]
    public class IsTurning : StateData
    {
        
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (characterState.characterControl.IsFacingForward() & characterState.characterControl.moveLeft)
            {
                Debug.Log("Turn from right to left");
                return;
            }

            if (!characterState.characterControl.IsFacingForward() & characterState.characterControl.moveRight)
            {
                Debug.Log("Turn from left to right");
                return;
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }

}