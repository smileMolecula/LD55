using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private IAbility iAbility;
    private float fear;
    [SerializeField] private FieldOfView fieldOfView;
    void Start()
    {
        fieldOfView.seePlayer += SeePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetAimDirection(transform.up);
    }
    private void SeePlayer()
    {
        Debug.Log("Мы увидели игрока");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SeePlayer();
        }
    }
}
