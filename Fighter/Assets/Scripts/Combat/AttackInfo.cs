using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.State;
using Project.Core;

namespace Project.Combat
{
    public class AttackInfo : MonoBehaviour
    {
        public CharacterControl attacker = null;
        public Attack attackAbility;
        public List<string> colliderNames = new List<string>();

        public bool mustCollide;
        public bool mustFaceAttacker;
        public float lethalRange;
        public int maxHits;
        public int currentHits;
        public bool isRegistered;
        public bool isFinished;

        public void ResetInfo(Attack attack, CharacterControl Attacker)
        {
            isRegistered = false;
            isFinished = false;
            attackAbility = attack;
            attacker = Attacker;
        }

        public void Register(Attack attack)
        {
            isRegistered = true;
            attackAbility = attack;
            colliderNames = attack.colliderNames;
            mustCollide = attack.mustCollide;
            mustFaceAttacker = attack.mustFaceAttacker;
            lethalRange = attack.lethalRange;
            maxHits = attack.maxHits;
            currentHits = 0;
        }
    }
}
