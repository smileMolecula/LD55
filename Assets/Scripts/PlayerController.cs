using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public IHealth ihealth;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
        ihealth = GetComponent<IHealth>();
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
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit.collider != null && hit.collider.CompareTag("Friend"))
        {
            hit.collider.transform.GetComponentInParent<IFriend>().Activation();

        }
    }

}
