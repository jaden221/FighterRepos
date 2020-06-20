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
    TurningRight,
    TurningLeft,
    Beam,
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
        public bool run;
        public bool beam;

        [Header("Gameplay")]
        public float blockDistance;

        [Header("Components")]
        [HideInInspector] public Rigidbody myRigidbody;
        [HideInInspector] public Animator skinnedMeshAnimator;
        [HideInInspector] public MeleeAttackInfo meleeAttackInfo;
        [HideInInspector] public BeamAttackInfo beamAttackInfo;

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
            meleeAttackInfo = GetComponent<MeleeAttackInfo>();
            beamAttackInfo = GetComponent<BeamAttackInfo>();

            CreateColStateIdentifierDictionary();

            bool switchBack = false;
            if (!IsFacingForward()) switchBack = true;

            if (switchBack) FaceForward(false);
        }

        public void CreateColStateIdentifierDictionary()
        {
            ColliderStateIdentifier[] allChildren = colStates.GetComponentsInChildren<ColliderStateIdentifier>();

            foreach(ColliderStateIdentifier obj in allChildren)
            {
                colliderStateObjs.Add(obj.colliderStateName.ToString(), obj); 
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
