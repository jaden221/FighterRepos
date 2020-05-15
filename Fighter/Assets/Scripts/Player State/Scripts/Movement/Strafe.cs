using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/MoveForward")]
    public class Strafe : StateData
    {
        public AnimationCurve speedGraph;
        public float speed = 1;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (characterState.characterControl.moveLeft && characterState.characterControl.moveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!characterState.characterControl.moveLeft && !characterState.characterControl.moveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
            }

            if (characterState.characterControl.moveLeft)
            {
                characterState.characterControl.FaceForward(false);
                if (!characterState.characterControl.checkFront())
                {
                    characterState.characterControl.MoveForward(speedGraph, stateInfo, speed);
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

    }
}

