using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/Attack")]
    public class Attack : StateData
    {
        public bool isRegistered;
        public bool isFinished;
        public bool canDmg;

        public float windowMin;
        public float windowMax;

        public float damage;

        public string namething;

        public List<string> hitBoxes = new List<string>();
        List<Collider> HitBoxes = new List<Collider>();

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            Transform[] allChildren = characterState.characterControl.gameObject.GetComponentsInChildren<Transform>();
            HitBoxes.Clear();
            foreach (Transform child in allChildren)
            {
                if (hitBoxes.Contains(child.name))
                {
                    HitBoxes.Add(child.GetComponent<Collider>());
                }
            }
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
            AttackManager.Instance.attackInfo.ResetInfo(HitBoxes, damage);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            if (stateInfo.normalizedTime >= windowMin && stateInfo.normalizedTime <= windowMax)
            {
                canDmg = true;
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

    }

}