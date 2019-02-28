using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCheckTouch
{
    private Vector2 raycastDirection;
    private Vector2[] offsetPoints;
    private LayerMask layerMask;
    private float raycastLen;

    public RaycastCheckTouch(Vector2 startm, Vector2 end, Vector2 dir, LayerMask mask, Vector2 parallelInSet, Vector2 perpendicularInset, float checkLength){
        this.raycastDirection = dir;
        this.offsetPoints = new Vector2[]{
            startm + parallelInSet + perpendicularInset,
            end - parallelInSet + perpendicularInset,
        };
        this.raycastLen = perpendicularInset.magnitude;
        this.layerMask = mask;
    }

    public Collider2D DoRaycast(Vector2 origin){
        foreach(var offset in offsetPoints){
            RaycastHit2D hit = Raycast(origin + offset, raycastDirection, raycastLen,layerMask);
            if(hit.collider != null){
                return hit.collider;
            }
        }
        return null;
    }

    private RaycastHit2D Raycast(Vector2 start, Vector2 dir, float len, LayerMask mask){
        Debug.DrawLine(start, start + dir * len, Color.red);
        return Physics2D.Raycast(start, dir, len,mask);
    }
    
}
