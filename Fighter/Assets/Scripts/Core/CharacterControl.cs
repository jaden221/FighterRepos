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
}

namespace Project.Core
{
    public class CharacterControl : MonoBehaviour
    {

        [Header("Colliders")]
        public GameObject colliderEdgePrefab;

        [Header("ControlsFromManualInput")]
        public bool moveRight;
        public bool moveLeft;
        public bool jump;
        public bool attack;
        public bool strafe;

        [Header("Lists")]
        public List<GameObject> groundSpheres = new List<GameObject>();
        public List<GameObject> frontSpheres = new List<GameObject>();
        public List<Collider> ragdollParts = new List<Collider>();
        public List<Collider> collidingParts = new List<Collider>();
        
        [Header("Gameplay")]
        public float gravityMultiplier;
        public float pullMultiplier;
        public float blockDistance;
        public float dodgeVelocity;

        [Header("Components")]
        [HideInInspector] public Rigidbody myRigidbody;
        [HideInInspector] public Animator SkinnedMeshAnimator;

        private void Awake()
        {
            myRigidbody = GetComponent<Rigidbody>();
            SkinnedMeshAnimator = GetComponent<Animator>();

            bool switchBack = false;
            if (!IsFacingForward()) switchBack = true;
            
            SetRagdollParts();
            SphereMethod();

            if (switchBack) FaceForward(false);
        }

        //private IEnumerator Start()
        //{
        //    yield return new WaitForSeconds(5f);
        //    myRigidbody.AddForce(Vector3.up * 100f);
        //    yield return new WaitForSeconds(.5f);
        //    TurnOnRagdoll();
        //}

        private void SetRagdollParts()
        {
            Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider col in colliders)
            {
                if (col.gameObject != this.gameObject)
                {
                    col.isTrigger = true;
                    ragdollParts.Add(col);
                }
            }
        }

        private void TurnOnRagdoll()
        {
            myRigidbody.useGravity = false;
            myRigidbody.velocity = Vector3.zero;
            GetComponent<Collider>().enabled = false;
            SkinnedMeshAnimator.avatar = null;
            SkinnedMeshAnimator.enabled = false;
            foreach(Collider col in ragdollParts)
            {
                if (col.gameObject != this.gameObject)
                {
                    col.isTrigger = false;
                    col.attachedRigidbody.velocity = Vector3.zero;
                }
            }
        }

        private void SphereMethod()
        {
            Collider boxCollider = GetComponent<Collider>();
            float bottom = boxCollider.bounds.center.y - boxCollider.bounds.extents.y + .01f;
            float top = boxCollider.bounds.center.y + boxCollider.bounds.extents.y - .01f;
            float front = boxCollider.bounds.center.z + boxCollider.bounds.extents.z - .01f;
            float back = boxCollider.bounds.center.z - boxCollider.bounds.extents.z + .01f;

            GameObject bottomFront = CreateEdgeSphere(new Vector3(0, bottom, front));
            GameObject bottomBack = CreateEdgeSphere(new Vector3(0, bottom, back));
            GameObject topFront = CreateEdgeSphere(new Vector3(0, top, front));
            GameObject topBack = CreateEdgeSphere(new Vector3(0, top, back));

            bottomFront.transform.parent = this.transform;
            bottomBack.transform.parent = this.transform;
            topFront.transform.parent = this.transform;
            topBack.transform.parent = this.transform;

            groundSpheres.Add(bottomFront);
            groundSpheres.Add(bottomBack);
            frontSpheres.Add(topFront);
            frontSpheres.Add(topBack);

            float horzSec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5;
            CreateMiddleSpheres(bottomBack, transform.forward, horzSec, 4, groundSpheres);

            float vertSec = (bottomFront.transform.position - topFront.transform.position).magnitude / 10;
            CreateMiddleSpheres(bottomFront, transform.up, vertSec, 9, frontSpheres);
        }

        //private void FixedUpdate()
        //{
        //    if (myRigidbody.velocity.y < 0f)
        //    {
        //        myRigidbody.velocity += Vector3.down * gravityMultiplier;
        //    }
        //    if (myRigidbody.velocity.y >0f && !jump)
        //    {
        //        myRigidbody.velocity += Vector3.down * pullMultiplier;
        //    } 
        //}

        public GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(colliderEdgePrefab, pos, Quaternion.identity);
            return obj;
        }

        public void CreateMiddleSpheres(GameObject start, Vector3 direction, float sec, int interactions, List<GameObject> sphereList)
        {
            for (int i = 0; i < interactions; i++)
            {
                Vector3 pos = start.transform.position + (direction * sec * (i + 1));
                GameObject newObj = CreateEdgeSphere(pos);
                newObj.transform.parent = this.transform;
                sphereList.Add(newObj);
            }
        }

        private void OnTriggerEnter(Collider col)
        {
            if (ragdollParts.Contains(col)) return;
            
            CharacterControl characterControl = col.transform.root.GetComponent<CharacterControl>();
            if (characterControl == null) return;

            if (col.gameObject == characterControl.gameObject) return;

            if (!collidingParts.Contains(col))
            {
                collidingParts.Add(col);
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (collidingParts.Contains(col))
            {
                collidingParts.Remove(col);
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

        public void CacheCharacterControl(Animator animator)
        {
            CharacterState[] arr = animator.GetBehaviours<CharacterState>();

            foreach (CharacterState c in arr)
            {
                c.characterControl = this;
            }
        }

        public bool checkFront()
        {
            foreach (GameObject obj in frontSpheres)
            {
                RaycastHit hit;
                if (Physics.Raycast(obj.transform.position, Vector3.forward, out hit, blockDistance, LayerMask.GetMask("Ground")))
                {
                    if (!ragdollParts.Contains(hit.collider))
                    {
                        if (!isBodyPart(hit.collider))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //Change Control reference to this
        public bool isBodyPart(Collider col)
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
