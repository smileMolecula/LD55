using System;
using UnityEngine;
public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private Transform healthPanel;
    private Animator animator;
    private int health = 3;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void DecreaseHealth()
    {
        if(health > 0)
        {
            health--;
            healthPanel.GetChild(health).gameObject.SetActive(false);
        }
        if(health == 0)
        {
            FindObjectOfType<UI>().PanelGameOver();
        }
    }
}
