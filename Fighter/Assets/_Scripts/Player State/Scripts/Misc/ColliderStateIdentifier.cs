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
        Melee1Prep,
        Melee1Action,
        Melee1Recovery,
        Melee2Prep,
        Melee2Action,
        Melee2Recovery,
        Melee3Prep,
        Melee3Action,
        Melee3Recovery,
        Strafe,
        Run,
        Turn,
        Beam1Prep,
        Beam1Action,
        Beam1Recovery,
    }
}

public class ColliderStateIdentifier : MonoBehaviour
{

    public ColliderStateNames colliderStateName;

    public bool isActive;

    public List<Collider> cols = new List<Collider>();

    private void Awake()
    {
        SetActiveFalse();
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
