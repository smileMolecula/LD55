using System;
using UnityEngine;

public class FlashlightCollider : MonoBehaviour
{
    public event Action<Vector2> seePlayer;
    public event Action<Vector2> seeMysticism;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(Physics2D.Raycast(transform.position,(other.transform.position - transform.position).normalized).collider.CompareTag("Player"))
            {
                seePlayer?.Invoke(other.transform.position);
                FindObjectOfType<PlayerController>().ihealth.DecreaseHealth();
            }
        }
        if(other.CompareTag("Friend"))
        {
            if(Physics2D.Raycast(transform.position,(other.transform.position - transform.position).normalized).collider.CompareTag("Friend"))
            {
                if(other.GetComponent<IFriend>().GetActivation())
                seeMysticism?.Invoke(other.transform.position);
            }
        }
    }
}
