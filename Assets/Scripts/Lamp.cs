using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lamp : MonoBehaviour, IFriend
{
    [SerializeField] private Condition flickeringLamp;
    private bool isActivate = false;
    private Collider2D col;
    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    public void Activation()
    {
        isActivate = true;
        col.enabled = true;
        flickeringLamp.ActivationCondition();
    }
    public void EndAnimation()
    {
        isActivate = false;
        col.enabled = false;
    }
    public bool GetActivation()
    {
        return isActivate;
    }
}
