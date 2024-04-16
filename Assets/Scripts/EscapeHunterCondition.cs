using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EscapeHunterCondition : Condition
{
    [SerializeField] private Transform exitPoint;
    private Hunter hunter;
    private NavMeshAgent agent;
    private void Start()
    {
        hunter = GetComponent<Hunter>();
        agent = GetComponent<NavMeshAgent>();
    }
    public override void ActivationCondition()
    {
        animator?.Play(animClip.name);
        audioSource?.Play();
        hunter.Target = exitPoint.position;
        animator.speed = 1.5f;
        agent.speed = 6f;
    }
}
