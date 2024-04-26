using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractive
{
    [SerializeField] private Condition flickeringLamp;
    [SerializeField] private int fear;
    [SerializeField] private float mana = 1f;
    private bool isActivate = false;
    public void Activation()
    {
        isActivate = true;
        flickeringLamp.ActivationCondition();
    }
    public void EndAnimation() => isActivate = false;
    public bool GetActivation() => isActivate;
    public int GetFear() => fear;
    public float TakeMana() => mana;
}
