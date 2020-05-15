using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

namespace Project.State
{
    public class CharacterState : StateMachineBehaviour
    {
        public CharacterControl characterControl;
        [Space(5)]
        public List<StateData> listAbilityData = new List<StateData>();

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (characterControl == null)
            {
                characterControl = animator.transform.root.GetComponent<CharacterControl>();
                //characterControl
            }

            foreach(StateData data in listAbilityData)
            {
                data.OnEnter(this, animator, stateInfo);
            }
        }

        public void UpdateAll(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach(StateData data in listAbilityData)
            {
                data.UpdateAbility(characterState, animator, stateInfo);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(this, animator, stateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (StateData data in listAbilityData)
            {
                data.OnEnter(this, animator, stateInfo);
            }
        }
    }
}