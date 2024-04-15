using UnityEngine.AI;
using UnityEngine;
using System;

public class Hunter : MonoBehaviour
{
    [SerializeField] private IAbility iAbility;
    private float fear;
    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private FlashlightCollider flashlightCollider;
    [SerializeField] private float speedTurn = 30f;
    private MovementPath movementPath;
    private NavMeshAgent navMeshAgent;
    private Vector3 target;
    private float angleFlishlight = 0f;
    private Transform transformflashlight;
    private float angleFlishlightCurrent = 0f;
    private float angleFlishlightOld = 0f;
    
    private Vector3 Target
    {
        get{return target;}
        set
        {
            target = value;
            navMeshAgent.SetDestination((Vector2)target);
        }
    }

    private void Awake()
    {
        flashlightCollider.seePlayer += SeePlayer;
        movementPath = GetComponent<MovementPath>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        transformflashlight = transform.GetChild(0);
        navMeshAgent.updateRotation = false;
		navMeshAgent.updateUpAxis = false;
        target = movementPath.GetPointPosition();
        navMeshAgent.SetDestination(target);
    }
    private void Update()
    {
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetAimDirection(target - navMeshAgent.steeringTarget);
        if(Vector2.Distance(transform.position,target) < 0.3f)
        {
            GoToNextGoal();
        }
        // Vector3 direction = target - transform.position;
        // Quaternion rotation = Quaternion.LookRotation(navMeshAgent.v);
        // transformflashlight.rotation = Quaternion.Lerp(transformflashlight.rotation,rotation,speedTurn);
        // if(!(angleFlishlightCurrent + 1 > angleFlishlight || angleFlishlightCurrent - 1 < angleFlishlight))
        // {
        //     angleFlishlightCurrent += Mathf.Lerp(angleFlishlightOld,angleFlishlight,1f * Time.deltaTime);
        // }
        
        transformflashlight.eulerAngles = new Vector3(0,0,angleFlishlightCurrent);
    }
    private void SeePlayer()
    {
        Debug.Log("Мы увидели игрока");
    }
    private void GoToNextGoal()
    {
        movementPath.NextPathPoint();
        target = movementPath.GetPointPosition();
        navMeshAgent.SetDestination(target);
    }
}
