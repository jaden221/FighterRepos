using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/ColStateHandler")]
    public class ColStateHandler : StateData
    {
        public ColliderStateNames colliderStateNames;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.characterControl.colliderStateObjs[colliderStateNames.ToString()].SetActiveTrue();
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.characterControl.colliderStateObjs[colliderStateNames.ToString()].SetActiveTrue();
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.characterControl.colliderStateObjs[colliderStateNames.ToString()].SetActiveFalse();
        }
    }

}