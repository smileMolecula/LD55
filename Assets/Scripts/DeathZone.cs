using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private float positionY;
    private void Update()
    {
        if(transform.position.y - 5f < positionY)
        {
            Destroy(gameObject);
        }
    }
}
