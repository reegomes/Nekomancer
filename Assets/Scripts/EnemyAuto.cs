using UnityEngine;
using UnityEngine.Animations;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAuto : MonoBehaviour
{
    bool onGrou;
    bool dead;
    float movingSpeed = 2f;
    [SerializeField] Transform Tr;
    Animator anim;
    [SerializeField] GameObject rayOne;
    void Start()
    {
        Tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        switch (onGrou)
        {
            case true:
                GetComponent<Rigidbody2D>().velocity = new Vector2(movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
                anim.SetBool("walking", true);
                break;
            case false:
                Flip();
                break;
        }
        if (movingSpeed == -2)
        {
            Tr.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            Tr.eulerAngles = new Vector3(0, 0, 0);
        }
        //Debug.DrawRay(transform.position, Vector2.down, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(rayOne.transform.position, -Vector2.up, 1f);
        if (hit.collider != null)
        {
            onGrou = true;
        }
        else
        {
            onGrou = false;
        }
        if (dead == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    void Flip()
    {
        movingSpeed = movingSpeed * -1;
    }
}