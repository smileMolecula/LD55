using System;
using UnityEngine;

public class FlashlightCollider : MonoBehaviour
{
    public event Action seePlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(Physics2D.Raycast(transform.position,(other.transform.position - transform.position).normalized).collider.CompareTag("Player"))
            {
                seePlayer?.Invoke();
                FindObjectOfType<PlayerController>().ihealth.DecreaseHealth();
            }
        }
    }
}
