using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool isRun = true;
    public bool IsRun 
    { 
        private get
        {
            return isRun;
        } 
        set
        { 
            isRun = value;
            rb.velocity = Vector2.zero; 
        } 
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(IsRun)
        {    
            moveInput = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
            rb.velocity = moveInput * speed;
        }
    }
}
