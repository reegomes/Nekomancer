using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMoveDirection
{
    private Vector2 raycastDirection;
    private Vector2[] offsetPoints;
    private LayerMask layerMask;
    private float addLenght;

    public RaycastMoveDirection(Vector2 startm, Vector2 end, Vector2 dir, LayerMask mask, Vector2 parallelInSet, Vector2 perpendicularInset){
        this.raycastDirection = dir;
        this.offsetPoints = new Vector2[]{
            startm + parallelInSet + perpendicularInset,
            end - parallelInSet + perpendicularInset,
        };
        this.addLenght = perpendicularInset.magnitude;
        this.layerMask = mask;
    }


    public float DoRaycast(Vector2 origin, float distance){
        float minDistance = distance;
        foreach(var offset in offsetPoints){
            RaycastHit2D hit = Raycast(origin + offset, raycastDirection, distance + addLenght,layerMask);
            if(hit.collider != null){
                MoveThroughPlatform mtp = hit.collider.GetComponent<MoveThroughPlatform>();
                if(mtp == null || Vector2.Dot(raycastDirection, mtp.permitDirection) < mtp.dotLeeway)
                {
                    minDistance = Mathf.Min(minDistance, hit.distance - addLenght);
                }
                
            }
        }
        return minDistance;
    }

    private RaycastHit2D Raycast(Vector2 start, Vector2 dir, float len, LayerMask mask){
        Debug.DrawLine(start, start + dir * len, Color.blue);
        return Physics2D.Raycast(start, dir, len,mask);
    }
}
