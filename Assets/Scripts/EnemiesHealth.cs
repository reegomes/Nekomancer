using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    [SerializeField]  public int life;
    [SerializeField]SpriteRenderer sr;
    [SerializeField]Animator animator;
    bool recallFlag;
    public bool hitFlag;
    Drop drop;
    // Start is called before the first frame update
    void Start()
    {
        recallFlag = true;
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        drop = FindObjectOfType<Drop>();
    }
    public void TakeDamage(int damage)
    {
        if(recallFlag == true)
        {
            hitFlag = true;
            recallFlag = false;
            sr.color = Color.red;
            life -= damage;
            if(life <= 0)
            {
                animator.SetTrigger("dead");
                //drop.DropUp(this.gameObject);
                Destroy(this.gameObject,1f);
            }
            Invoke("ResetSprite",0.3f);
            Invoke("ResetHit",1f);
            Invoke("Recall",0.5f);
        }
    }

    void ResetSprite(){
        sr.color = Color.white;
    }

    void Recall(){
        recallFlag = true;

    }

    void ResetHit(){
        hitFlag = false;
    }
}
