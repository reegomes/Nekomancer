using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    enum State { Normal, Wall, Dash }

    [SerializeField]
    LayerMask lmWalls;
    [SerializeField]
    float fJumpVelocity = 5;

    Rigidbody2D rigid;

    float fJumpPressedRemember = 0;
    [SerializeField]
    float fJumpPressedRememberTime = 0.2f;

    float fGroundedRemember = 0;
    [SerializeField]
    float fGroundedRememberTime = 0.25f;

    [SerializeField] float fHorizontalAccel;
    [SerializeField] float fHorizontalDeccel;
    [SerializeField] float snapSpeed;

    [SerializeField]
    [Range(0, 1)]
    float fCutJumpHeight = 0.5f;

    float horizDir;
    [SerializeField] float horizMaxSpeed;
    [SerializeField] Transform groundCheckPos, wallCheckPos, side;
    [SerializeField] Vector2 groundCheckSize;

    public bool bGrounded, down, bWalled;

    State myState;

    //WallJump
    float fWallJump;
    float fWallJumpValue = 0.25f;
    bool bWallJump = false;

    //Dash
    float fDash;
    float fDashValue = 0.1f;
    bool bDash = false;

    //Flip
    [SerializeField] Transform animTr;
    #region Controller
    public bool pausePlayer;
    #endregion
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pausePlayer = true;
    }
    void Update()
    {
        if (!pausePlayer)
        {
            bGrounded = Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, lmWalls);
            bWalled = Physics2D.OverlapBox(wallCheckPos.position, groundCheckSize, 0, lmWalls);
            if (myState == State.Normal)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    animTr.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    animTr.eulerAngles = new Vector3(0, 180, 0);
                }

                fGroundedRemember -= Time.deltaTime;
                if (bGrounded)
                {
                    fGroundedRemember = fGroundedRememberTime;
                }

                fJumpPressedRemember -= Time.deltaTime;
                if (Input.GetButtonDown("Jump"))
                {
                    fJumpPressedRemember = fJumpPressedRememberTime;
                }

                if (Input.GetButtonUp("Jump"))
                {
                    if (rigid.velocity.y > 0)
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * fCutJumpHeight);
                    }
                }

                if ((fJumpPressedRemember > 0) && (fGroundedRemember > 0))
                {
                    fJumpPressedRemember = 0;
                    fGroundedRemember = 0;
                    rigid.velocity = new Vector2(rigid.velocity.x, fJumpVelocity);
                }
            }
            if (myState == State.Wall)
            {
                if (!bWalled)
                {
                    if (Input.GetAxisRaw("Horizontal") > 0)
                    {
                        animTr.eulerAngles = new Vector3(0, 0, 0);
                    }
                    else if (Input.GetAxisRaw("Horizontal") < 0)
                    {
                        animTr.eulerAngles = new Vector3(0, 180, 0);
                    }
                }

                float dir;
                if (animTr.rotation.y == 0)
                {
                    dir = -1;
                }
                else
                {
                    dir = 1;
                }

                if ((Input.GetKeyDown(KeyCode.Space) && bGrounded == true) || (Input.GetKeyDown(KeyCode.Space) && bWalled == true))
                {
                    rigid.velocity = new Vector2(10 * dir, 15);
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                myState = State.Dash;
            }

            if (myState == State.Dash)
            {

                float dir;
                if (animTr.rotation.y == 0)
                {
                    dir = 1;
                }
                else
                {
                    dir = -1;
                }
                rigid.gravityScale = 0;
                if (!bDash)
                {
                    fDash = fDashValue;
                    bDash = true;
                }
                else
                {
                    fDash -= Time.deltaTime;
                }
                if (fDash > 0)
                {
                    rigid.velocity = new Vector2(50 * dir, 0);
                }
                else
                {
                    bDash = false;
                    rigid.gravityScale = 8;
                    myState = State.Normal;

                }

            }
        }
    }

    void FixedUpdate()
    {
        if (!pausePlayer)
        {
            float horizInput = Input.GetAxisRaw("Horizontal");

            int wantedDir = GetSign(horizInput);
            int velDir = GetSign(rigid.velocity.x);

            if (myState == State.Normal)
            {
                if (bGrounded && Input.GetAxisRaw("Vertical") < 0)
                {
                    down = true;
                }
                else
                {
                    down = false;
                }
                if (!down)
                {
                    if (wantedDir != 0)
                    {
                        if (wantedDir != velDir)
                        {
                            horizDir = snapSpeed * wantedDir;
                        }
                        else
                        {
                            horizDir = Mathf.MoveTowards(horizDir, horizMaxSpeed * horizInput, fHorizontalAccel * Time.deltaTime);
                        }
                    }
                    else
                    {
                        horizDir = Mathf.MoveTowards(horizDir, 0, fHorizontalDeccel * Time.deltaTime);
                    }
                    rigid.velocity = new Vector2(horizDir, rigid.velocity.y);
                }
            }


            if (!bGrounded && bWalled && Input.GetAxisRaw("Horizontal") != 0)
            {
                myState = State.Wall;
                if (!bWallJump)
                {
                    fWallJump = fWallJumpValue;
                    bWallJump = true;
                }
                else
                {
                    fWallJump -= Time.deltaTime;
                }

                if (fWallJump > 0)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, 0);
                }

                rigid.gravityScale = 0.5f;

            }
            else
            {
                bWallJump = false;
                rigid.gravityScale = 8;

            }
            if (!bDash && bGrounded)
            {
                myState = State.Normal;
            }
        }
    }

    int GetSign(float v)
    {
        if (Mathf.Approximately(v, 0))
        {
            return 0;
        }
        else if (v > 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

}