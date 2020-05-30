using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/Dodge")]
    public class Dodge : StateData
    {
        public bool backward = false;
        public bool forward = false;
        public float animationSpeed;
        public float speedInput;
        public float minTime;
        public float maxTime;
        public AnimationCurve speedGraph;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.speed = animationSpeed;
            if (stateInfo.normalizedTime >= minTime && stateInfo.normalizedTime <= maxTime)
            {
                if (backward)
                {
                    characterState.characterControl.myRigidbody.velocity = Vector2.zero;
                    speedInput = Mathf.Abs(speedInput) * -1;
                    characterState.characterControl.MoveForward(speedGraph, stateInfo, speedInput);
                }

                if (forward)
                {
                    characterState.characterControl.myRigidbody.velocity = Vector2.zero;
                    speedInput = Mathf.Abs(speedInput);
                    characterState.characterControl.MoveForward(speedGraph, stateInfo, speedInput);
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}