using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedData : MonoBehaviour
{
    public DamageDetector damageDetector;

    void Awake()
    {
        damageDetector = transform.root.GetComponent<DamageDetector>();
    }
}
