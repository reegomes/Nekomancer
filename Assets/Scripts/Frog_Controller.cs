using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//vitotoso
public class Frog_Controller : MonoBehaviour
{
    #region vars
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject target;
    [SerializeField] Vector2 size;
    [SerializeField] Vector3 offset;
    [SerializeField] private Collider2D raytarget;
    [SerializeField] private RaycastHit2D col;
    [SerializeField] private LayerMask l;
    private bool isJumping;
    private int direction;
    Vector3 relative;
    PlayerHealth heath;
    #endregion
    #region start
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        anim.GetComponent<Animator>();
        StartCoroutine("IaController");
        heath = target.GetComponent<PlayerHealth>();
    }
    #endregion
    #region ienumerator
    IEnumerator IaController()
    {
        float dis = Vector2.Distance(transform.position, target.transform.position);
        col = Physics2D.BoxCast(transform.position + offset, size, 0, Vector2.zero, 100, l);
        Vector2 relative = transform.InverseTransformPoint(target.transform.position);
        float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        raytarget = col.collider;


        if (angle > 90)
        {
            //Right
            direction = 1;
            transform.Rotate(new Vector3(0, 180, 0));

        }
        if (angle < -90)
        {
            //left
            direction = -1;
            transform.Rotate(new Vector3(0, 0, 0));

        }

        if (dis < 5)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        if (col)
        {
            heath.TakeDamage(1);
        }

        if (isJumping)
        {
            anim.SetBool("isJumping", true);
            transform.Translate(direction * Time.deltaTime, 0, 0);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        yield return new WaitForSeconds(0.005f);
        StartCoroutine("IaController");
    }
    #endregion
    #region methods
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + offset, size);
    }

    void Damage()
    {
        anim.SetTrigger("isDying");
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
    #endregion
}
