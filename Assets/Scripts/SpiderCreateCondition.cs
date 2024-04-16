using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCreateCondition :  Condition
{
    public override void ActivationCondition()
    {
        animator?.Play(animClip.name);
        audioSource?.Play();
    }
}
