using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private event Action decreaseHealth;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
        decreaseHealth += GetComponent<IHealth>().DecreaseHealth;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            ActivationFriend();
        }
    }
    private void ActivationFriend()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit.collider != null && hit.collider.CompareTag("Friend"))
        {
            hit.collider.GetComponent<IFriend>().Activation();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            decreaseHealth?.Invoke();
        }
    }
}
