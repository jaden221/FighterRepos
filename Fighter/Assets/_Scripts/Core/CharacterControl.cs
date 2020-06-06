using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.State;
using System;

public enum TransitionParameter
{
    Move,
    Jump,
    ForceTransition,
    Grounded,
    Attack,
    Strafe,
    DodgeBackward,
    DodgeForward,
}

namespace Project.Core
{
    public class CharacterControl : MonoBehaviour
    {

        [Header("ControlsFromManualInput")]
        public bool moveRight;
        public bool moveLeft;
        public bool jump;
        public bool attack;
        public bool strafe;

        [Header("Gameplay")]
        public float blockDistance;

        [Header("Components")]
        [HideInInspector] public Rigidbody myRigidbody;
        [HideInInspector] public Animator skinnedMeshAnimator;
        [HideInInspector] public AttackInfo attackInfo;

        [Header("Lists")]
        public List<GameObject> groundSpheres;
        public List<Collider> collidingParts;

        [Header("Dictionaries")]
        public Dictionary<string, ColliderStateIdentifier> colliderStateObjs = new Dictionary<string, ColliderStateIdentifier>();
        
        [Space(10)]
        public GameObject colStates;

        private void Awake()
        {
            myRigidbody = GetComponent<Rigidbody>();
            skinnedMeshAnimator = GetComponent<Animator>();
            attackInfo = GetComponent<AttackInfo>();

            TheDictionaryThing();

            bool switchBack = false;
            if (!IsFacingForward()) switchBack = true;

            if (switchBack) FaceForward(false);
        }

        public void TheDictionaryThing()
        {
            ColliderStateIdentifier[] allChildren = colStates.GetComponentsInChildren<ColliderStateIdentifier>();

            foreach(ColliderStateIdentifier obj in allChildren)
            {
                colliderStateObjs.Add(obj.colliderStateName.ToString(), obj);
                //Debug.Log(colliderStateObjs[obj.colliderStateName.ToString()]);
            }
        }

        public void MoveForward(AnimationCurve speedGraph, AnimatorStateInfo stateInfo, float speed)
        {
            myRigidbody.velocity = transform.forward * speedGraph.Evaluate(stateInfo.normalizedTime) * speed;
        }

        public void FaceForward(bool forward)
        {
            if (forward)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            if (!forward)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        public bool IsFacingForward()
        {
            if (transform.forward.z > 0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isStandingStill()
        {
            if ((moveLeft && moveRight) || (!moveLeft && !moveRight))
            {
                return true;
            }
            else return false;
        }
    }
}
