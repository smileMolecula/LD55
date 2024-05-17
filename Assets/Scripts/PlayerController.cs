using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public IHealth ihealth{get;private set;}
    private Camera cam;
    private int numbersHunters;
    private PlayerMovement playerMovement;
    private FollowCamera followCamera;
    private ManaStripePlayer manaStripe;
    public int NumbersHunters
    {
        get{return numbersHunters;}
        set
        {
            numbersHunters = value;
            if(numbersHunters == 0)
            {
                StartCoroutine(Win());
            }
        }    
    }
    void Start()
    {
        cam = Camera.main;
        ihealth = GetComponent<IHealth>();
        NumbersHunters = FindObjectsOfType<Hunter>().Length;
        playerMovement = GetComponent<PlayerMovement>();
        followCamera = cam.GetComponent<FollowCamera>();
        manaStripe = GetComponent<ManaStripePlayer>();
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
        if(hit.collider != null && hit.collider.GetComponent<IInteractive>() != null)
        {
            IInteractive interactiveObject = hit.collider.GetComponent<IInteractive>();
            if(manaStripe.Mana > interactiveObject.TakeMana())
            {
                interactiveObject.Activation();
                manaStripe.UseMana(interactiveObject.TakeMana());
            }   
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Mana"))
        {
            Mana mana = other.GetComponent<Mana>();
            manaStripe.TakeMana(mana.TookMana());
            Destroy(mana.gameObject);
        }
    }
    private IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<UI>().PanelWin();
    }
    public void SeeHunter()
    {
        followCamera.ShakeCamera();
        StartCoroutine(Stupor());
    }
    private IEnumerator Stupor()
    {
        playerMovement.IsRun = false;
        yield return new WaitForSeconds(2f);
        playerMovement.IsRun = true;
    }
}
