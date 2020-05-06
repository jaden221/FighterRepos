using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core;

namespace Project.Combat
{
    public class AttackManager : Singleton<AttackManager>
    {
        public List<AttackInfo> currentAttacks = new List<AttackInfo>();
    }
}

