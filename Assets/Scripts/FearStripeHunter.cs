using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;

public class FearStripeHunter : MonoBehaviour
{
    [SerializeField] private Image stripe;
    private Transform stripeTransform;
    public event Action isFright;
    private int fear = 0;
    private int fearOld = 0;
    [SerializeField] private float speed;
    private bool animEnd = true;
    private void Start()
    {
        stripeTransform = stripe.transform;
    }
    private void LateUpdate()
    {
        stripeTransform.rotation = Quaternion.identity;
    }
    public void Fear(int fear)
    {
        this.fear += fear;
        if(animEnd)
        {
            animEnd = false;
            StartCoroutine(SetFearCorutine());
        }
    }
    private IEnumerator SetFearCorutine()
    {
        float fearCurrent = fearOld;
        float time = 0;
        if(fear >= 100)
        {
            isFright?.Invoke();
        }
        while(fearCurrent < fear)
        {
            time += Time.deltaTime * speed;
            fearCurrent = Mathf.Lerp(fearOld, fear,time);
            stripe.fillAmount = fearCurrent / 100;
            yield return null;
        }
        fearOld = fear;
        animEnd = true;
    }
}
