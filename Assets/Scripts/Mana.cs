using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public event Action tookMana;
    [SerializeField] private float mana = 5f;
    [SerializeField] private Condition tookManaCondition;
    public float TookMana()
    {
        tookMana?.Invoke();
        tookManaCondition.ActivationCondition();
        return mana;
    }
}
