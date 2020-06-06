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
        //if (ColliderStateNames.Idle.ToString() == colliderStateName.ToString())
        //{
        //    SetActiveTrue();
        //}
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
