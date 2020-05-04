using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public bool constant;
        public AnimationCurve speedGraph;
        public float speed = 1;
        public float blockDistance;

        CharacterControl characterControl;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl = characterState.GetCharacterControl(animator);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (characterControl.jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }
            if (constant)
            {
                ConstantMove(animator, stateInfo);
            }
            else
            {
                ControlledMove(animator, stateInfo);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        private void ControlledMove(Animator animator, AnimatorStateInfo stateInfo)
        {
            if (characterControl.moveLeft && characterControl.moveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!characterControl.moveLeft && !characterControl.moveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
            }

            if (characterControl.moveLeft)
            {
                characterControl.FaceForward(false);
                if (!checkFront(characterControl))
                {
                    characterControl.MoveForward(speedGraph,stateInfo,speed);
                }
            }

            if (characterControl.moveRight)
            {
                characterControl.FaceForward(true);
                if (!checkFront(characterControl))
                {
                    characterControl.MoveForward(speedGraph, stateInfo, speed);
                }
            }
        }

        private void ConstantMove(Animator animator, AnimatorStateInfo stateInfo)
        {
            if (!checkFront(characterControl))
            {
                characterControl.MoveForward(speedGraph, stateInfo, speed);
            }
        }

        bool checkFront(CharacterControl control)
        {
            foreach (GameObject obj in control.frontSpheres)
            {
                RaycastHit hit;
                if (Physics.Raycast(obj.transform.position, Vector3.forward, out hit , blockDistance, LayerMask.GetMask("Ground")))
                {
                    if (!control.ragdollParts.Contains(hit.collider))
                    {
                        if (!IsBodyPart(hit.collider))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        bool IsBodyPart(Collider col)
        {
            CharacterControl control = col.transform.root.GetComponent<CharacterControl>();
            if (control == null)
            {
                return false;
            }
            if (control.gameObject == col.gameObject)
            {
                return false;
            }

            if (control.ragdollParts.Contains(col))
            {
                return true;
            }
            return false;
        }
    }

}
