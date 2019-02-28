using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spines : MonoBehaviour
{
    PlayerHealth p;
    [SerializeField] Collider2D target;
    [SerializeField] Vector2 size;
    [SerializeField] LayerMask l;

    void FixedUpdate()
    {
        target = Physics2D.OverlapBox(transform.position, size, 0,l);
        if (target)
        {
            p = target.GetComponent<PlayerHealth>();
            p.TakeDamage(1);
        }
      
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
