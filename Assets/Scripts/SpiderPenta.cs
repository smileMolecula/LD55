using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPenta : MonoBehaviour , IInteractive
{
    [SerializeField] private GameObject spiritPrefab;
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
            material.SetFloat("_Arc1", 360f);
            Spirit spirit = Instantiate(spiritPrefab,transform.position,Quaternion.identity).GetComponent<Spirit>();
            spirit.deathSpirit += DeathSpirit;
        }
    }
    private void OnDestroy()
    {
        material.SetFloat("_Arc1", 0f);
    }
    public void DeathSpirit()
    {
        isActivate = false;
        StartCoroutine(Recharge());
    }
    private IEnumerator Recharge()
    {
        float time = timeRecharge;
        while(time > 0)
        {
            time -= Time.deltaTime;
            material.SetFloat("_Arc1", 360f / timeRecharge * time);
            yield return null;
        }
        isClickable = true;
    }
    public float TakeMana() => mana;
}
