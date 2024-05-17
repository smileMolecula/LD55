using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [field: SerializeField] public Vector2 size{get; private set;}
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,size);
    }
}
