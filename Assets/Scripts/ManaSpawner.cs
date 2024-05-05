using UnityEngine.AI;
using UnityEngine;
using NavMeshPlus.Components;
using System.Threading.Tasks;
using System.Collections;

public class ManaSpawner : MonoBehaviour
{
    private NavMeshSurface navMeshAgent;
    [SerializeField] private Vector2 size;
    [SerializeField] private GameObject manaPrefab;
    [SerializeField] private int maxCountMana = 10;
    [SerializeField] private float minimumTimeCreateMana = 2f;
    [SerializeField] private float maxmumTimeCreateMana = 10f;
    private int manaCount;
    private bool isActivity;
    private void Start()
    {
        StartCoroutine(RandomCreateMana());
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,size);
    }
    private IEnumerator RandomCreateMana()
    {
        isActivity = true;
        while(manaCount <= maxCountMana)
        {
            yield return new WaitForSeconds(Random.Range(minimumTimeCreateMana,maxmumTimeCreateMana));
            Vector2 randomPosition = new Vector2(Random.Range(-size.x / 2,size.x / 2) + transform.position.x, Random.Range(-size.y / 2,size.y / 2) + transform.position.y);
            Mana mana = Instantiate(manaPrefab,randomPosition,Quaternion.identity).transform.GetChild(0).GetComponent<Mana>();
            mana.tookMana += MinusMana;
            manaCount++;
        }
        isActivity = false;
    }
    private void MinusMana()
    {
        manaCount--;
        if(isActivity)
        {
            StartCoroutine(RandomCreateMana());
        }
    }
}
