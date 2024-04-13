using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private IAbility iAbility;
    private float fear;
    private FieldOfView fieldOfView;
    void Start()
    {
        fieldOfView = transform.GetChild(0).GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
        fieldOfView.SetOrigin(transform.position);
    }
}
