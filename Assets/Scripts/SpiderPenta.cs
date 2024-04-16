using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPenta : MonoBehaviour , IFriend
{
    [SerializeField] private Condition spiderCondition;
    private bool isActivate = false;
    public void Activation()
    {
        isActivate = true;
        spiderCondition.gameObject.SetActive(true);
        spiderCondition.ActivationCondition();
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
