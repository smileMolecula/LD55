using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDisable : MonoBehaviour
{
    public void Disable()
    {
        GetComponent<Animator>();
        gameObject.SetActive(false);
    }
}
