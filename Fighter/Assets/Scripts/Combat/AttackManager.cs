using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

public class AttackManager : Singleton<AttackManager>
{
    public AttackInfo attackInfo;

    private void Awake()
    {
        attackInfo = Resources.Load("AttackInfo") as AttackInfo;
    }
}
