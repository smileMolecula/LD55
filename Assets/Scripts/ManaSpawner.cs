using UnityEngine.AI;
using UnityEngine;
using NavMeshPlus.Components;
using System.Threading.Tasks;
using System.Collections;

public class ManaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject manaPrefab;
    [SerializeField] private int maxCountMana = 10;
    [SerializeField] private float minimumTimeCreateMana = 2f;
    [SerializeField] private float maxmumTimeCreateMana = 10f;
    private Vector2 size;
    private int manaCount;
    private bool isActivity;
    [SerializeField] private float radius;
    private void Start()
    {
        StartCoroutine(RandomCreateMana());
        size = FindObjectOfType<Home>().size;
        radius = manaPrefab.GetComponent<CircleCollider2D>().radius;
    }
    private IEnumerator RandomCreateMana()
    {
        isActivity = true;
        while(manaCount <= maxCountMana)
        {
            yield return new WaitForSeconds(Random.Range(minimumTimeCreateMana,maxmumTimeCreateMana));
            Vector2 randomPosition = Vector2.zero;
            for(int i = 0;i < 100; i++)
            {
                randomPosition = new Vector2(Random.Range(-size.x / 2,size.x / 2) + transform.position.x, Random.Range(-size.y / 2,size.y / 2) + transform.position.y);
                if(Physics2D.Raycast(randomPosition,Vector2.up,0.5f) || Physics2D.Raycast(randomPosition,Vector2.down,0.5f) || Physics2D.Raycast(randomPosition,Vector2.left,0.5f) || Physics2D.Raycast(randomPosition, Vector2.right,0.5f))
                {
                    if(i + 1 == 100)
                    {
                        Debug.Log("Неудачный спавн");
                        yield break;
                    }
                    continue;
                }
                Debug.Log("Удачный спавн через " + i + " шагов");
                break;
            }
            Mana mana = Instantiate(manaPrefab,randomPosition,Quaternion.identity).transform.GetChild(0).GetComponent<Mana>();
            mana.tookMana += MinusMana;
            manaCount++;
        }
        isActivity = false;
    }
    private void MinusMana()
    {
        manaCount--;
        if(!isActivity)
        {
            StartCoroutine(RandomCreateMana());
        }
    }
}
