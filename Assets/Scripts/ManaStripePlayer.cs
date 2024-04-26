using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaStripePlayer : MonoBehaviour
{
    [SerializeField] private Image stripeImage;
    [field: SerializeField] public float Mana { get; private set;} = 0f;
    [SerializeField] private float speedRecovery = 1f;
    void Update()
    {
        if(Mana < 100)
        {
            Mana += speedRecovery * Time.deltaTime;
            stripeImage.fillAmount = Mana / 100;
        }
    }
    public void TakeMana(float Mana)
    {
        this.Mana -= Mana;
    }
}
