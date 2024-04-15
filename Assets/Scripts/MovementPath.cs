using System.Collections.Generic;
using UnityEngine;
public class MovementPath : MonoBehaviour
{

    [SerializeField] private enum PathTypes
    {
        linear,
        loop
    }
    [SerializeField] private PathTypes pathType;
    private int movingTo = 0;
    private bool reverseDirection = false;
    [SerializeField] private Transform[] PathElements;
    public void OnDrawGizmos()
    {
        if(PathElements == null || PathElements.Length < 2)
        {
            return;
        }
        for (int i = 1; i < PathElements.Length; i++)
        {
            Gizmos.DrawLine(PathElements[i - 1].position,PathElements[i].position);
        }
        if(pathType == PathTypes.loop)
        {
            Gizmos.DrawLine(PathElements[0].position,PathElements[PathElements.Length - 1].position);
        }
    }
    public void NextPathPoint()
    {
        if(pathType == PathTypes.loop)
        {
            if(movingTo < PathElements.Length - 1)
            {
                movingTo++;
            }
            else
            {
                movingTo = 0;
            }  
        }
        else
        {
            if(!reverseDirection)
            {
                if(movingTo < PathElements.Length - 1)
                {
                    movingTo++;
                }
                else
                {
                    reverseDirection = !reverseDirection;
                    movingTo--;
                }
            }
            else
            {
                if(movingTo > 0)
                {
                    movingTo--;
                }
                else
                {
                    reverseDirection = !reverseDirection;
                    movingTo++;
                }
                
            }
        }
    }
    public Vector3 GetPointPosition()
    {
        return PathElements[movingTo].position;
    }
}