using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoiceAtk : MonoBehaviour
{
    [SerializeField]GameObject target;
    [SerializeField]GameObject boss;
    float speedSet;
    bool grounded, hit;
    bool controlFlag1 = true;
    bool controlFlag2 = true;
    int hitCount;
    [SerializeField]LayerMask ground,player;
	// Use this for initialization
	void Start () {
        speedSet = 15f;
        target = FindObjectOfType<NewPlayer>().gameObject;
        boss = FindObjectOfType<Kura>().gameObject;
        transform.rotation = Quaternion.Euler(0, 0, CalculateAngle(transform.position,target.transform.position,1));
        StartCoroutine(FakeUpdate());
	}
	
    IEnumerator FakeUpdate(){
        //Debug.Log(hitCount);
        speedSet -= 0.2f;
        transform.Translate((15 /Mathf.Clamp(speedSet, 0.8f,15)) * Time.deltaTime, 0, 0);
        if(grounded)
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, 2f, ground);
            if (transform.position.y > col.bounds.max.y)
            {
                if(controlFlag1)
                {
                    controlFlag1 = false;
                    ColGround();
                }            
            }
            else
            {
                if (controlFlag2)
                {
                    controlFlag2 = false;
                    ColWall();
                }
                
            }
            
        }

        if(Vector3.Distance(transform.position, boss.transform.position) < 1f && !controlFlag2)
        {  
            
            var kurinha = boss.GetComponent<Kura>();
            kurinha.GrabFoice();
            
            Destroy(this.gameObject);

        }
        else if (Vector3.Distance(transform.position, boss.transform.position) >25f)
        {
            ColWall();
        }

        grounded = Physics2D.OverlapCircle(transform.position,1.3f,ground);
        hit = Physics2D.OverlapCircle(transform.position,1.3f,player);
        if(hit)
        {
            target.GetComponent<PlayerHealth>().TakeDamage(1);
        }
        
        yield return new WaitForSeconds(.005f);
        StartCoroutine(FakeUpdate());
    }

    void ColGround()
    {
        if (!controlFlag1)
        {
            speedSet = 15;
            var alt = Random.Range(0, 45);
            if (boss.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180 - alt);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, alt);
            }
        }
        else
        {
            speedSet = 15;
            transform.rotation = Quaternion.Euler(0, 0, CalculateAngle(transform.position, boss.transform.position, 0));
        }
    }

    void ColWall()
    {
        speedSet = 15;
        transform.rotation = Quaternion.Euler(0, 0, CalculateAngle(transform.position,boss.transform.position,0));
    }

    float CalculateAngle(Vector3 thisPos,Vector3 targetPos, float ajust)
    {
        var pos1 = thisPos;
        var pos2 = targetPos;
        var anglezin = Mathf.Atan2(pos2.y - pos1.y + ajust, pos2.x - pos1.x) * 180 / Mathf.PI;
        return anglezin;
    }

}
