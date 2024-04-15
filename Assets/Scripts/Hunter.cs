using UnityEngine.AI;
using UnityEngine;
using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;

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
    private Transform transformflashlight;
    [SerializeField] private Condition seePlayerCondition;
    [SerializeField] private Condition frightCondition;
    private bool isRun = true;
    
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
        flashlightCollider.seeMysticism += Fright;
        movementPath = GetComponent<MovementPath>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        transformflashlight = transform.GetChild(0);
        navMeshAgent.updateRotation = false;
		navMeshAgent.updateUpAxis = false;
        Target = movementPath.GetPointPosition();
    }
    private void Update()
    {
        fieldOfView.SetOrigin(transform.position);
        if(isRun)
        {
            if(Vector2.Distance(transform.position,Target) < 0.3f)
            {
                GoToNextGoal();
            }
        }
        Vector3 direction = navMeshAgent.steeringTarget - transform.position;
        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
        transformflashlight.up = Vector2.MoveTowards(transformflashlight.up,direction,speedTurn * Time.deltaTime);
        fieldOfView.SetAngle(transformflashlight.eulerAngles.z + 105f);
    }
    private void GoToNextGoal()
    {
        movementPath.NextPathPoint();
        Target = movementPath.GetPointPosition();
    }
    private void SeePlayer(Vector2 positionPlayer)
    {
        seePlayerCondition.ActivationCondition();
        StartCoroutine(AttackCoroutine(positionPlayer));
    }
    private IEnumerator AttackCoroutine(Vector2 positionPlayer)
    {
        isRun = false;
        navMeshAgent.enabled = false;
        target = positionPlayer;
        yield return new WaitForSeconds(1f);
        navMeshAgent.enabled = true;
        Target = positionPlayer;
        isRun = true;
    }
    private void Fright(Vector2 positionObject)
    {
        Debug.Log("Обосрался");
        frightCondition.ActivationCondition();
        StartCoroutine(FrightCoroutine(positionObject));
    }

    private IEnumerator FrightCoroutine(Vector2 positionObject)
    {
        isRun = false;
        navMeshAgent.enabled = false;
        Vector2 plannedPosition = Target;
        target = positionObject;
        yield return new WaitForSeconds(1f);
        navMeshAgent.enabled = true;
        Target = plannedPosition;
        isRun = true;
    }
    
}