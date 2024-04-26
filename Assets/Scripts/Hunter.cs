using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class Hunter : MonoBehaviour
{
    [SerializeField] private IAbility iAbility;
    [SerializeField] private FieldOfView fieldOfView;
    [field: SerializeField] public FlashlightCollider flashlightCollider{get; private set;}
    [SerializeField] private float speedTurn = 30f;
    private MovementPath movementPath;
    private NavMeshAgent navMeshAgent;
    private Vector3 target;
    private Transform transformflashlight;
    [SerializeField] private Condition seePlayerCondition;
    [SerializeField] private Condition frightCondition;
    [SerializeField] private Condition escapeCondition;
    [SerializeField] private Condition idleCondition;
    [SerializeField] private Condition runCondition;
    private FearStripeHunter fearStripe;
    private bool isRun = true;
    private bool isEscape = false;
    private Vector2 direction;
    public Vector3 Target
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
        fearStripe = GetComponent<FearStripeHunter>();
        movementPath = GetComponent<MovementPath>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        flashlightCollider.seePlayer += SeePlayer;
        flashlightCollider.seeMysticism += Fright;
        fearStripe.isFright += Escape;
        transformflashlight = flashlightCollider.transform;
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
                StartCoroutine(Idle());
            }
            direction = navMeshAgent.steeringTarget - transform.position;
        }
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
        direction = (positionPlayer - (Vector2)transform.position).normalized;
        yield return new WaitForSeconds(4f);
        navMeshAgent.enabled = true;
        Target = positionPlayer;
        isRun = true;
    }
    private IEnumerator Idle()
    {
        isRun = false;
        navMeshAgent.enabled = false;
        int numberHunterTurs = Random.Range(2,6);
        idleCondition.ActivationCondition();
        float positionX = 2f;
        for(int i = 0; i < numberHunterTurs; i++)
        {
            int randomValue = Random.Range(-10,10);
            if(randomValue > 0)
            {
                positionX = 2f;
            }
            else
            {
                positionX = -2f;
            }
            Vector3 randomPosition = new Vector2(transform.position.x + positionX,transform.position.y + Random.Range(-10,10));
            direction = randomPosition - transform.position;
            yield return new WaitForSeconds(1.5f);
        }
        isRun = true;
        navMeshAgent.enabled = true;
        GoToNextGoal();
        runCondition.ActivationCondition();
    }
    private void Fright(Vector2 positionObject, int fear)
    {
        frightCondition.ActivationCondition();
        fearStripe.Fear(fear);
        StartCoroutine(FrightCoroutine(positionObject));
    }
    private IEnumerator FrightCoroutine(Vector2 positionObject)
    {
        if(!isEscape)
        {
            isRun = false;
            navMeshAgent.enabled = false;
            Vector2 plannedPosition = Target;
            target = positionObject;
            yield return new WaitForSeconds(3f);
            navMeshAgent.enabled = true;
            Target = plannedPosition;
            isRun = true;
        }
    }
    private void Escape()
    {
        StopAllCoroutines();
        isRun = true;
        isEscape = true;
        runCondition.ActivationCondition();
        escapeCondition.ActivationCondition();
        FindObjectOfType<PlayerController>().NumbersHunters--;
    }
}