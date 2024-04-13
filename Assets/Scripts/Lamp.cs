using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IFriend
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Activation()
    {
        anim.SetTrigger("Activate");
    }
}
