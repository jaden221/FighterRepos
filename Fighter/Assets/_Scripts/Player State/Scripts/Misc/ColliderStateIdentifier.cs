using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.State;

namespace Project.State
{
    public enum ColliderStateNames
    {
        Idle,
        Walk,
        Jump,
        Fall,
        JumpPrep,
        Melee1,
        Melee2,
        Melee3,
        Strafe,
        Run,
    }
}

public class ColliderStateIdentifier : MonoBehaviour
{

    public ColliderStateNames colliderStateName;

    public bool isActive;

    public List<Collider> cols = new List<Collider>();

    //public Transform selfTransformRoot;

    private void Awake()
    {
        SetActiveFalse();
        //selfTransformRoot = transform.root.GetComponent<Transform>();
    }

    public void SetActiveTrue()
    {
        foreach(Collider col in cols)
        {
            col.enabled = true;
        }
        isActive = true;
    }

    public void SetActiveFalse()
    {
        foreach (Collider col in cols)
        {
            col.enabled = false;
        }
        isActive = false;
    }
}
