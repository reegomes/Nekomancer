using System.Collections;
using UnityEngine;

public class Kura : MonoBehaviour
{
    float side;
    public int pattern1, pattern2;
    [SerializeField] Transform target;
    Animator animator;
    [SerializeField] GameObject foice, skull, magic;
    float setX = 1, setY = 0;
    //magicSet
    [SerializeField] int numberOfProjetiles;
    [SerializeField] float projectileSpeed;
    Vector3 startPoint;
    float radius = 1f;
    float angleSet = 0;
    EnemiesHealth health;
    //States
    enum State { Throw, ChangePos, Invoke, Berseker, None }
    [SerializeField] State state;
    bool bersekerSide, canBerseker;
    float bersekerCount;
    public bool pausePlayer;
    Coroutine berCO;

    bool controlFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        canBerseker = true;
        health = GetComponent<EnemiesHealth>();
        state = State.None;
        animator = GetComponent<Animator>();
        StartCoroutine(FakeUpdate());
        StartCoroutine(FoiceAttackCO());
    }

    IEnumerator FakeUpdate()
    {
        if (state != State.None)
        {
            Debug.Log(canBerseker+ "OIIIIIIIIIIIIII");
            side = transform.position.x - target.position.x;
            if (Mathf.Sign(side) < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (Mathf.Sign(side) > 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            if (bersekerCount >= 4)
            {
                canBerseker = false;
            }
            if (health.life <= 10 && canBerseker)
            {
                state = State.Berseker;
            }
            else if ((pattern1 >= 1 && pattern2 < 2) || (!canBerseker && health.life <= 10))
            {

                state = State.ChangePos;

            }
            else if (pattern2 >= 2)
            {

                state = State.Invoke;
            }
            else
            {
                state = State.Throw;
            }


            if (angleSet >= 180 || angleSet <= -180)
            {

                angleSet = 0;
                bersekerCount++;
                if (bersekerSide)
                {
                    bersekerSide = false;
                }
                else
                {
                    bersekerSide = true;
                }
                StopCoroutine(berCO);
                StartCoroutine(FoiceAttackCO());
            }
        }
        yield return new WaitForSeconds(0.005f);
        StartCoroutine(FakeUpdate());
    }

    IEnumerator FoiceAttackCO()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        if (state == State.Throw)
        {
            animator.SetBool("foiceAtk", true);
            Invoke("throwFoice", 0.4f);

        }
        else if (state == State.ChangePos)
        {
            Invoke("ChangeSideCO", 0.75f);

        }
        else if (state == State.Invoke)
        {
            InvokeSkulls();
        }
        else if (state == State.Berseker)
        {

            berCO = StartCoroutine(BersekerCO());
        }
    }

    void ChangeSideCO()
    {

        var xx = Random.Range(-10, 11);
        var yy = Random.Range(-4, 2);
        transform.position = new Vector3(xx, yy);

        animator.SetBool("changeSide", false);
        if (!canBerseker)
        {
            canBerseker = true;
            bersekerCount = 0;
        }
        StartCoroutine(FoiceAttackCO());

        pattern1 = 0;

    }

    void InvokeSkulls()
    {
        animator.SetTrigger("invoke");
        var numberOfSkulls = Random.Range(1, 5);
        for (int i = 0; i <= numberOfSkulls; i++)
        {
            var posX = Random.Range(-10, 11);
            Instantiate(skull, new Vector3(posX, -6.6f), Quaternion.identity);
        }
        StartCoroutine(FoiceAttackCO());
        pattern1 = 0;
        pattern2 = 0;
    }

    void throwFoice()
    {
        pattern1++;
        pattern2++;
        Instantiate(foice, transform.position, Quaternion.identity);
    }
    public void GrabFoice()
    {
        animator.SetBool("foiceAtk", false);
        StartCoroutine(FoiceAttackCO());
    }


    IEnumerator BersekerCO()
    {
        //transform.position = new Vector3(0,4,0);
        startPoint = transform.position;
        SpawnProjectile(numberOfProjetiles);
        if (bersekerSide)
        {
            angleSet += 12;
        }
        else
        {
            angleSet -= 12;
        }


        yield return new WaitForSecondsRealtime(0.3f);
        berCO = StartCoroutine(BersekerCO());
    }

    void SpawnProjectile(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = angleSet;

        for (int i = 0; i < _numberOfProjectiles; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(magic, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0);

            angle += angleStep;
        }
    }
    public void SoltaOSomDeeJay()
    {
        state = State.Throw;
        if (!controlFlag)
        {
            controlFlag = true;
            StartCoroutine(FoiceAttackCO());
        }
        
    }
}