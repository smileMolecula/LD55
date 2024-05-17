using System;
using UnityEngine;

public class FlashlightCollider : MonoBehaviour
{
    public event Action<Vector2> seePlayer;
    public event Action<Vector2,int> seeMysticism;
    [SerializeField] private LayerMask layerMask;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(Physics2D.Raycast(transform.position,(other.transform.position - transform.position).normalized).collider.CompareTag("Player"))
            {
                seePlayer?.Invoke(other.transform.position);
                PlayerController player = FindObjectOfType<PlayerController>();
                player.ihealth.DecreaseHealth();
                player.SeeHunter();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Friend"))
        {
            if(Physics2D.Raycast(transform.position,(other.transform.position - transform.position).normalized,layerMask).collider.CompareTag("Friend"))
            {
                IMystical mysticalObject = other.GetComponent<IMystical>();
                if(mysticalObject.GetActivation())
                {
                    other.GetComponent<ISpirit>()?.Death();
                    seeMysticism?.Invoke(other.transform.position,mysticalObject.GetFear());
                }
            }
        }
    }
}