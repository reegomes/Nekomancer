using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMagicSkill : MonoBehaviour
{
    bool hit;
    [SerializeField] GameObject target;
    [SerializeField] LayerMask player;
    void Start()
    {
        target = FindObjectOfType<NewPlayer>().gameObject;
        Destroy(this.gameObject, 5f);
    }
    
    void Update(){
        hit = Physics2D.OverlapCircle(transform.position,0.25f,player);
        if(hit)
        {
            target.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
