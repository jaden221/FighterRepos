using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/Strafe")]
    public class Strafe : StateData
    {
        public AnimationCurve speedGraph;
        public float speed = 1;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (characterState.characterControl.moveLeft && characterState.characterControl.strafe)
            {
                characterState.characterControl.FaceForward(true);
                characterState.characterControl.MoveForward(speedGraph, stateInfo, -speed);
            }
            if (characterState.characterControl.moveRight && characterState.characterControl.strafe)
            {
                characterState.characterControl.FaceForward(false);
                characterState.characterControl.MoveForward(speedGraph, stateInfo, -speed);
            }
            else if (!characterState.characterControl.strafe || characterState.characterControl.isStandingStill())
            {
                animator.SetBool(TransitionParameter.Strafe.ToString(), false);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}
