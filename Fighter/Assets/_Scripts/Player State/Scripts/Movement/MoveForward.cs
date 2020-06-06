using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public bool constant;
        public AnimationCurve speedGraph;
        public float speed = 1;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            //Debug.Log(characterControl.gameObject.name + "From characterControl UPDATE");
            //Debug.Log(animator.gameObject.name + "From animator UPDATE");
            if (characterState.characterControl.jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }
            if (constant)
            {
                ConstantMove(characterState, animator, stateInfo);
            }
            else
            {
                ControlledMove(characterState, animator, stateInfo);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        private void ControlledMove(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
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
                characterState.characterControl.MoveForward(speedGraph, stateInfo, speed);
            }

            if (characterState.characterControl.moveRight)
            {
                characterState.characterControl.FaceForward(true);
                characterState.characterControl.MoveForward(speedGraph, stateInfo, speed);
            }
        }

        private void ConstantMove(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.characterControl.MoveForward(speedGraph, stateInfo, speed);
        }

    }

}
