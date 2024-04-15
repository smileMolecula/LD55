using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterSeePlayerCondition : Condition
{
    public override void ActivationCondition()
    {
        animator.Play(animClip.name);
    }
}
