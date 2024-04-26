using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    private Transform playerTransform;
    private Vector3 PlayerPosition
    {
        get{return new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y,-25f);}
        set{}
    }
    private bool isFollow = true;
    [SerializeField] private float speed = 5f;
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(isFollow)
        {
            transform.position = PlayerPosition;
        }
    }
    public void ShakeCamera()
    {
        StartCoroutine(ShakeCameraCoroutine());
    }
    private IEnumerator ShakeCameraCoroutine()
    {
        isFollow = false;
        int qualityShake = Random.Range(4,10);
        for(int i = 0; i < qualityShake; i++)
        {
            Vector3 randomPosition = new Vector3(playerTransform.position.x + Random.Range(-0.3f,0.3f),playerTransform.position.y + Random.Range(-0.5f,0.5f),-25f);
            while(Vector2.Distance(transform.position,randomPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position,randomPosition,speed * Time.deltaTime);
                yield return null;
            }
            while(Vector2.Distance(PlayerPosition,transform.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position,PlayerPosition,speed * Time.deltaTime);
                yield return null;
            }
        }
        isFollow = true;
    }
}
