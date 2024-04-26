using System;
using UnityEngine;

public class FlashlightCollider : MonoBehaviour
{
    public event Action<Vector2> seePlayer;
    public event Action<Vector2,int> seeMysticism;
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
            if(Physics2D.Raycast(transform.position,(other.transform.position - transform.position).normalized).collider.CompareTag("Friend"))
            {
                IInteractive interactiveObject = other.GetComponent<IInteractive>();
                if(interactiveObject.GetActivation())
                {
                    seeMysticism?.Invoke(other.transform.position,interactiveObject.GetFear());
                    other.GetComponent<IFriend>().Death();
                }
            }
        }
    }
}
