using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/Jump")]
    public class Jump : StateData
    {
        public float jumpForce;
        public AnimationCurve gravity;
        public AnimationCurve pull;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.characterControl.myRigidbody.AddForce(Vector3.up * jumpForce);
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.characterControl.gravityMultiplier = gravity.Evaluate(stateInfo.normalizedTime);
            characterState.characterControl.pullMultiplier = pull.Evaluate(stateInfo.normalizedTime);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

    }
}

