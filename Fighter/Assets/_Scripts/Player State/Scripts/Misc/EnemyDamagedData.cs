using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedData : MonoBehaviour
{
    // This class is for cacheing data this enemy/player has to give to the attacker so no getcomponents are needed

    public DamageDetector damageDetector;

    void Awake()
    {
        damageDetector = transform.root.GetComponent<DamageDetector>();
    }
}
