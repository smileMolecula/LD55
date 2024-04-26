using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EscapeHunterCondition : Condition
{
    [SerializeField] private Transform exitPoint;
    private Hunter hunter;
    private NavMeshAgent agent;
    private new void Start()
    {
        base.Start();
        hunter = GetComponent<Hunter>();
        agent = GetComponent<NavMeshAgent>();
    }
    protected override void ConditionMethod()
    {
        hunter.flashlightCollider.gameObject.SetActive(false);
        hunter.Target = exitPoint.position;
        agent.enabled = true;
        animator.speed = 1.5f;
        agent.speed = 6f;
    }
}
