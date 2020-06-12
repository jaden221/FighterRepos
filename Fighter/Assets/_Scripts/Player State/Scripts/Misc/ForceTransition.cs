using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core; 

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/ForceTransition")]
    public class ForceTransition : StateData
    {
        [Range(0.01f,1f)]
        public float TransitionTiming;

        public List<TransitionParameter> transitionParameterTrue = new List<TransitionParameter>();
        
        public List<TransitionParameter> transitionParameterFalse = new List<TransitionParameter>();

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.ForceTransition.ToString(), false);
            animator.speed = 1;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= TransitionTiming)
            {
                animator.SetBool(TransitionParameter.ForceTransition.ToString(), true);
                
                if (transitionParameterFalse.Count > 0)
                {
                    foreach (TransitionParameter param in transitionParameterFalse)
                    {
                        animator.SetBool(param.ToString(), false);
                    }
                }

                if (transitionParameterTrue.Count > 0)
                {
                    foreach (TransitionParameter param in transitionParameterTrue)
                    {
                        animator.SetBool(param.ToString(), true);
                    }
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.ForceTransition.ToString(), false);
        }

    }
}

