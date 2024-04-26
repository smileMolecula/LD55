using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPenta : MonoBehaviour , IInteractive , IFriend
{
    [SerializeField] private Condition spiderCreateCondition;
    [SerializeField] private Condition spiderDeathCondition;
    [SerializeField] private int fear = 20;
    [SerializeField] private float timeRecharge = 5f;
    [SerializeField] private float mana = 1f;
    private bool isActivate = false;
    private bool isClickable = true;
    private Material material;
    private void Start()
    {
        material = GetComponent<SpriteRenderer>().sharedMaterial;
    }
    public void Activation()
    {
        if(isClickable)
        {
            isActivate = true;
            isClickable = false;
            spiderCreateCondition.gameObject.SetActive(true);
            spiderCreateCondition.ActivationCondition();
        }
    }
    public bool GetActivation() => isActivate;
    public void Death()
    {
        isActivate = false;
        spiderDeathCondition.ActivationCondition();
        StartCoroutine(Recharge());
    }
    public int GetFear() => fear;
    private IEnumerator Recharge()
    {
        float time = timeRecharge;
        while(time > 0)
        {
            time -= Time.deltaTime;
            material.SetFloat("_Arc1", 360 / timeRecharge * time);
            yield return null;
        }
        isClickable = true;
    }
    public float TakeMana() => mana;
}
