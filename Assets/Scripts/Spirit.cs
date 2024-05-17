using UnityEngine.AI;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class Spirit : MonoBehaviour, IMystical, ISpirit
{
    [SerializeField] private int fear = 20;
    [SerializeField] private Condition spiderCreateCondition;
    [SerializeField] private Condition spiderDeathCondition;
    private NavMeshAgent agent;
    private Vector2 sizeHome;
    private Vector2 target;
    private Vector2 Target
    {
        get{return target;}
        set
        {
            target = value;
            agent.SetDestination(target);
        }
    }
    private Vector2 direction;
    public event Action deathSpirit;
    private bool isActivate = true;
    void Awake()
    {
        spiderCreateCondition.ActivationCondition();
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        RandomPositionNavMesh();
    }
    void Update()
    {
        if(Vector2.Distance(transform.position,target) < 1f)
        {
            RandomPositionNavMesh();
        }
        direction = agent.steeringTarget - transform.position;
        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
    }
    private void RandomPositionNavMesh()
    {
        bool generateCorrectionPath = false;
        NavMeshPath navMeshPath = new NavMeshPath();
        Vector2 path = Vector2.zero;
        int step = 0;
        while(!generateCorrectionPath)
        {
            step++;
            if(step >= 10)
            {
                break;
            }
            Vector3 randomDirection = Random.insideUnitSphere * 25;
            randomDirection += Vector3.zero;
            NavMeshHit hit;
            generateCorrectionPath = NavMesh.SamplePosition(randomDirection, out hit, 25, 1);
            if(generateCorrectionPath)
            {
                Vector3 finalPosition = hit.position;
                Target = finalPosition;
            }
        }
        
    }
    public void Death()
    {
        isActivate = false;
        deathSpirit?.Invoke();
        agent.enabled = false;
        spiderDeathCondition.ActivationCondition();
    }

    public int GetFear() => fear;

    public bool GetActivation() => isActivate;
}
