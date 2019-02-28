using System.Collections;
using UnityEngine;

public class EnemiesGravity : MonoBehaviour
{
       [SerializeField] float speed, gravity, checkRange;
    float walkDir;

    public bool isGrounded;
    [SerializeField] Transform feetPos;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    [SerializeField] GameObject target;
    Animator animator;

    EnemiesHealth healthRef;

    //Wall Detection
    [SerializeField] LayerMask whatsIsWall, player;
    public bool theresAWall, followAtk, hit;
    [SerializeField] Transform frontPos;

    public bool alive;
    EnemiesHealth life;

    Vector3 walk;

    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<EnemiesHealth>();
        alive = true;
        followAtk = false;
        healthRef = GetComponent<EnemiesHealth>();
        target = FindObjectOfType<NewPlayer>().gameObject;
        animator = GetComponent<Animator>();
        StartCoroutine(FakeUpdate());
        Invoke("CdAtk", 1f);
    }

    IEnumerator FakeUpdate()
    {
        if (life.life <= 0)
        {
            alive = false;
        }
        else
        {
            alive = true;
        }
        if (alive)
        {
            //gravity check
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

            if (!healthRef.hitFlag)
            {
                hit = Physics2D.OverlapCircle(frontPos.position, checkRadius, player);
            }

            if(hit){
                Collider2D playerCo = Physics2D.OverlapCircle(frontPos.position, checkRadius, player);
                playerCo.GetComponent<PlayerHealth>().TakeDamage(1);
            }


            if (!isGrounded)
            {
                var gravityForce = new Vector3(0, -(1f) / Mathf.Clamp(gravity, 4, 20));
                transform.position += gravityForce;
            }
            else
            {
                if (!healthRef.hitFlag)
                {
                    walkDir = target.transform.position.x - transform.position.x;
                    if (followAtk)
                    {
                        
                        
                        animator.SetBool("walking", true);

                        if (!theresAWall && followAtk)
                        {
                            
                            transform.position += walk;
                            
                        }
                    }
                    else
                    {
                        animator.SetBool("walking", false);
                        walk = new Vector3(Mathf.Sign(walkDir) * speed * Time.deltaTime, 0);
                        if(Mathf.Sign(walkDir)  > 0)
                        {
                            transform.eulerAngles = new Vector3(0,0,0);
                        }   
                        else if (Mathf.Sign(walkDir)  < 0)
                        {
                            transform.eulerAngles = new Vector3(0,180,0);
                        }
                    }
                }
                else{
                    followAtk = false;
                }
                
            }

            theresAWall = Physics2D.OverlapCircle(frontPos.position, checkRadius, whatsIsWall);
        }
        
        yield return new WaitForSecondsRealtime(0.005f);
        StartCoroutine(FakeUpdate());
    }

    void CdAtk()
    {
        followAtk = true;
        Invoke("CdWait", 3f);
    }

    void CdWait()
    {

        followAtk = false;
        Invoke("CdAtk", 1f);
    }

}