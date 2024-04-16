using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lamp : MonoBehaviour, IFriend
{
    [SerializeField] private Condition flickeringLamp;
    private bool isActivate = false;
    public void Activation()
    {
        isActivate = true;
        flickeringLamp.ActivationCondition();
    }
    public void EndAnimation()
    {
        isActivate = false;
    }
    public bool GetActivation()
    {
        return isActivate;
    }
}
