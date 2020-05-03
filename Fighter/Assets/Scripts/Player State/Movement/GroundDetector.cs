﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/GroundDetector")]
    public class GroundDetector : StateData
    {
        CharacterControl characterControl;
        public float distance;
        [Range(.01f,1f)]
        public float checkTime;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl = characterState.GetCharacterControl(animator);
            animator.animatePhysics = true;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            //Debug.Log("" + stateInfo.normalizedTime);
            if (stateInfo.normalizedTime >= checkTime)
            {
                if (isGrounded(characterControl))
                {
                    Debug.Log("true");
                    animator.SetBool(TransitionParameter.Grounded.ToString(), true);
                }
                else
                {
                    Debug.Log("false");
                    animator.SetBool(TransitionParameter.Grounded.ToString(), false);
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        bool isGrounded(CharacterControl control)
        {
            foreach (GameObject obj in control.groundSpheres)
            {
                Debug.Log("Starting it");
                Debug.DrawRay(obj.transform.position, Vector3.down * distance);
                if (Physics.Raycast(obj.transform.position, Vector3.down, distance, LayerMask.GetMask("Ground")))
                {
                    return true;
                }
            }
            return false;
        }


    }
}

