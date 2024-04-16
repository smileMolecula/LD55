using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;

public class FearStripeHunter : MonoBehaviour
{
    [SerializeField] Image stripe;
    public event Action isFright;
    private float fear;
    [SerializeField] private float speed;
    [SerializeField] private Transform canvasTransform;
    public void SetFear()
    {
        StartCoroutine(SetFearCorutine());
    }
    private void LateUpdate()
    {
        canvasTransform.position = transform.position;
    }
    private IEnumerator SetFearCorutine()
    {
        float fearNew = fear - 20f;
        float fearCurrent = fearNew;
        if(fear <= 0)
        {
            isFright?.Invoke();
        }
        while(fearCurrent > fearNew)
        {
            fearCurrent = Mathf.Lerp(fear,fearNew,speed * Time.deltaTime);
            stripe.fillAmount = fearCurrent;
            yield return null;
        }
        fear = fearNew;
    }
}
