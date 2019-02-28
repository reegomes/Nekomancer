using UnityEngine;
public class Player : MonoBehaviour
{
    private enum JumpState
    {
        None = 0, Holding,
    }
    SpriteRenderer sr;
    [SerializeField] private LayerMask platformMask;
    [SerializeField] private float parallelInsetLen;
    [SerializeField] private float perpendicualrInsetLen;
    [SerializeField] private float groundTestLen;
    [SerializeField] private float gravity;
    [SerializeField] private float horizSpeedUpAccel;
    [SerializeField] private float horizSpeedDownAccel;
    [SerializeField] private float horizSnapSpeed;
    [SerializeField] private float horizMaxSpeed;
    [SerializeField] private float jumpInputLeewayPeriod;
    [SerializeField] private float jumpStartSpeed;
    [SerializeField] private float jumpMaxHoldPeriod;
    [SerializeField] private float jumpMinSpeed;
    private Vector2 velocity;
    private RaycastMoveDirection moveDown;
    private RaycastMoveDirection moveLeft;
    private RaycastMoveDirection moveRight;
    private RaycastMoveDirection moveUp;
    private RaycastCheckTouch groundDown;
    public bool grounded, pausePlayer;
    private Vector2 lastStandingOnPos;
    private Vector2 lastStandingOnVel;
    private Collider2D lastStandingOn;
    private float jumpStartTimer;
    private float jumpHoldTimer;
    private bool jumpInputDown;
    private JumpState jumpState;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        moveDown = new RaycastMoveDirection(new Vector2(-0.5f, 0f), new Vector2(0.5f, 0f), Vector2.down, platformMask,
         Vector2.right * parallelInsetLen, Vector2.up * perpendicualrInsetLen);
        moveLeft = new RaycastMoveDirection(new Vector2(-0.5f, 0f), new Vector2(-0.5f, 1.7f), Vector2.left, platformMask,
         Vector2.up * parallelInsetLen, Vector2.right * perpendicualrInsetLen);
        moveUp = new RaycastMoveDirection(new Vector2(-0.5f, 1.7f), new Vector2(0.5f, 1.7f), Vector2.up, platformMask,
         Vector2.right * parallelInsetLen, Vector2.down * perpendicualrInsetLen);
        moveRight = new RaycastMoveDirection(new Vector2(0.5f, 0f), new Vector2(0.5f, 1.7f), Vector2.right, platformMask,
         Vector2.up * parallelInsetLen, Vector2.left * perpendicualrInsetLen);
        groundDown = new RaycastCheckTouch(new Vector2(-0.5f, 0f), new Vector2(0.5f, 0f), Vector2.down, platformMask,
         Vector2.right * parallelInsetLen, Vector2.up * perpendicualrInsetLen, groundTestLen);
    }

    private int GetSign(float v)
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
    private void Update()
    {
        jumpStartTimer -= Time.deltaTime;
        bool jumpBtn = Input.GetButton("Jump");
        if (jumpBtn && jumpInputDown == false)
        {
            jumpStartTimer = jumpInputLeewayPeriod;
        }
        jumpInputDown = jumpBtn;
    }

    private void FixedUpdate()
    {
        if (pausePlayer)
        {
            Collider2D standingOn = groundDown.DoRaycast(transform.position);
            grounded = standingOn != null;
            switch (jumpState)
            {
                case JumpState.None:
                    if (grounded && jumpStartTimer >= 0)
                    {
                        jumpStartTimer = 0;
                        jumpState = JumpState.Holding;
                        jumpHoldTimer = 0;
                        velocity.y = jumpStartSpeed;
                    }
                    break;
                case JumpState.Holding:
                    jumpHoldTimer += Time.deltaTime;
                    if (jumpInputDown == false || jumpHoldTimer >= jumpMaxHoldPeriod)
                    {
                        jumpState = JumpState.None;
                        velocity.y = Mathf.Lerp(jumpMinSpeed, jumpStartSpeed, jumpHoldTimer / jumpMaxHoldPeriod);
                    }
                    break;
            }
            float horizInput = Input.GetAxisRaw("Horizontal");
            if (horizInput < 0)
            {
                sr.flipX = true;
            }
            else if (horizInput > 0)
            {
                sr.flipX = false;
            }
            int wantedDirection = GetSign(horizInput);
            int velocityDirection = GetSign(velocity.x);
            if (wantedDirection != 0)
            {
                if (wantedDirection != velocityDirection)
                {
                    velocity.x = horizSnapSpeed * wantedDirection;
                }
                else
                {
                    velocity.x = Mathf.MoveTowards(velocity.x, horizMaxSpeed * wantedDirection, horizSpeedUpAccel * Time.deltaTime);
                }
            }
            else
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, horizSpeedDownAccel * Time.deltaTime);
            }

            if (jumpState == JumpState.None)
            {
                velocity.y -= gravity * Time.deltaTime;
            }
            Vector2 displacement = Vector2.zero;
            Vector2 wantedDispl = velocity * Time.deltaTime;
            if (standingOn != null)
            {
                if (lastStandingOn == standingOn)
                {
                    lastStandingOnVel = (Vector2)standingOn.transform.position - lastStandingOnPos;
                    wantedDispl += lastStandingOnVel;
                }
                else if (standingOn == null)
                {
                    velocity += lastStandingOnVel / Time.deltaTime;
                    wantedDispl += lastStandingOnVel;
                }
                lastStandingOnPos = standingOn.transform.position;
            }
            lastStandingOn = standingOn;
            if (wantedDispl.x > 0)
            {
                displacement.x = moveRight.DoRaycast(transform.position, wantedDispl.x);
            }
            else if (wantedDispl.x < 0)
            {
                displacement.x = -moveLeft.DoRaycast(transform.position, -wantedDispl.x);
            }
            if (wantedDispl.y > 0)
            {
                displacement.y = moveUp.DoRaycast(transform.position, wantedDispl.y);
            }
            else if (wantedDispl.y < 0)
            {
                displacement.y = -moveDown.DoRaycast(transform.position, -wantedDispl.y);
            }
            if (Mathf.Approximately(displacement.x, wantedDispl.x) == false)
            {
                velocity.x = 0;
            }
            if (Mathf.Approximately(displacement.y, wantedDispl.y) == false)
            {
                velocity.y = 0;
            }
            transform.Translate(displacement);
        }
    }
}