using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwo : MonoBehaviour
{
    [SerializeField] GameObject plataformL, plataformR, plPOINT, prPOINT, whell, doorclosed, dooropen, loki, b1, b2, b3, player;
    [SerializeField]private bool islocked, roll, solved, activate;
    [SerializeField] Transform p1, p2, p3;
    [SerializeField] Vector3 b1t, b2t, b3t;
    [SerializeField] Quaternion  wheell;
    [SerializeField] Vector2 size;
    [SerializeField] Collider2D p1c, p2c, p3c;
    [SerializeField] LayerMask l;
    [SerializeField] Animator anim;
    [SerializeField] float dis;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        solved = false;
        islocked = false;
        roll = false;
        anim.GetComponent<Animator>();
        doorclosed.SetActive(true);
        dooropen.SetActive(false);
        wheell = whell.transform.rotation;
        b1t = b1.transform.position;
        b2t = b2.transform.position;
        b3t = b3.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        plataformL.transform.position = plPOINT.transform.position;
        plataformR.transform.position = prPOINT.transform.position;
        p1c = Physics2D.OverlapBox(p1.transform.position, size, 0,l);
        p2c = Physics2D.OverlapBox(p2.transform.position, size, 0,l);
        p3c = Physics2D.OverlapBox(p3.transform.position, size, 0,l);
        dis = Vector2.Distance(player.transform.position, whell.transform.position);

        if (p1c && islocked && roll == true)
        {
            //door open
            doorclosed.SetActive(false);
            dooropen.SetActive(true);
            solved = true;
        }
        if (p2c)
        {
            roll = true;
        }
        else
        {
            roll = false;
        }
        if (p3c)
        {
            islocked = true;
            loki.transform.Rotate(0, 0, 1);
        }
        else
        {
            islocked = false;
        }
        anim.SetBool("roll", roll);

        if (dis < 15)
        {
            activate = true;
        }

        if (solved == false && dis > 25 && activate == true)
        {
                //Debug.Log("reseting");
                ResetPuzzle();
        }
    }
    void ResetPuzzle()
    {
        whell.transform.rotation = wheell;
        b1.transform.position = b1t;
        b2.transform.position = b2t;
        b3.transform.position = b3t;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(p1.transform.position, size);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(p2.transform.position, size);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(p3.transform.position, size);
    }
}
