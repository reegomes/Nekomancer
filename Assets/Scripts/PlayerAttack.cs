using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{ 
    NewPlayer playerRef;  
    float timeBtwAttack;
    [SerializeField] float startTimeBtwAttack;
    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask whatIsEnemies;
    public int damage;

    [SerializeField] Rigidbody2D rb;

    public bool atkTime, kick;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GetComponent<NewPlayer>();
        StartCoroutine(FakeUpdate());
    }

    IEnumerator FakeUpdate()
    {
        if(timeBtwAttack <= 0)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                atkTime = true;             
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
            
        if(atkTime)
        {
            if(Input.GetAxisRaw("Vertical") == 0){
                SideAttack();
            }
            else if(Input.GetAxisRaw("Vertical") > 0){
                UpAttack();
            }
            else if(Input.GetAxisRaw("Vertical") < 0){
                DownAttack();
            }
        }      
        yield return new WaitForSeconds(0.005f);
        StartCoroutine(FakeUpdate());
    }

    IEnumerator AttackTimeCO(){
        yield return new WaitForSecondsRealtime(0.3f);
        atkTime=false;
        kick = false;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,new Vector3(1,2.5f,1));
    }

    void SideAttack(){
        StartCoroutine(AttackTimeCO());
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(2,1),0,whatIsEnemies);
        for(int i = 0; i< enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemiesHealth>().TakeDamage(damage);
        }
    }

    void UpAttack(){
        StartCoroutine(AttackTimeCO());
        var offset = new Vector3(0,1.7f);
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(transform.position + offset, new Vector2(1,2.5f),0,whatIsEnemies);
        for(int i = 0; i< enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemiesHealth>().TakeDamage(damage);
        }
    }

    void DownAttack(){
        StartCoroutine(AttackTimeCO());
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(transform.position, new Vector2(1,2.5f),0,whatIsEnemies);
        for(int i = 0; i< enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemiesHealth>().TakeDamage(damage);
        }
        if(Physics2D.OverlapBox(transform.position, new Vector2(1,2.5f),0,whatIsEnemies) && atkTime){
            if(!kick){
                kick = true;
                rb.velocity = new Vector2(rb.velocity.x, 25);
            }
        }
        
        
    }
}
