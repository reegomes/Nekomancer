using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColAndGravity : MonoBehaviour
{
    [Header("COLISION AND GRAVITY")]
    [SerializeField] private LayerMask platformMask;
    [SerializeField] private Vector2 dimMin,dimMax;   
    [SerializeField] private float parallelInsetLen;
    [SerializeField] private float perpendicualrInsetLen;
    [SerializeField] private float groundTestLen;
    [SerializeField] private float gravity;

    protected Vector2 velocity;
    protected RaycastMoveDirection moveDown;
    protected RaycastMoveDirection moveLeft;
    protected RaycastMoveDirection moveRight;
    protected RaycastMoveDirection moveUp;

    public RaycastCheckTouch groundDown;
    // Start is called before the first frame update
    protected void Awake()
    {
        moveDown = new RaycastMoveDirection(new Vector2(-0.5f,0f),new Vector2(0.5f,0f), Vector2.down,platformMask,
         Vector2.right * parallelInsetLen, Vector2.up * perpendicualrInsetLen);
        moveLeft = new RaycastMoveDirection(new Vector2(-0.5f,0f),new Vector2(-0.5f,1.7f), Vector2.left,platformMask,
         Vector2.up * parallelInsetLen, Vector2.right * perpendicualrInsetLen);
        moveUp = new RaycastMoveDirection(new Vector2(-0.5f,1.7f),new Vector2(0.5f,1.7f), Vector2.up,platformMask,
         Vector2.right * parallelInsetLen, Vector2.down * perpendicualrInsetLen);
        moveRight = new RaycastMoveDirection(new Vector2(0.5f,0f),new Vector2(0.5f,1.7f), Vector2.right,platformMask,
         Vector2.up * parallelInsetLen, Vector2.left * perpendicualrInsetLen);

        groundDown = new RaycastCheckTouch(new Vector2(-0.5f,0f),new Vector2(0.5f,0f), Vector2.down,platformMask,
         Vector2.right * parallelInsetLen, Vector2.up * perpendicualrInsetLen, groundTestLen);

    }

    protected void FixedUpdate(){
        Debug.Log("entrou no Update da bagaça");
        bool grounded = groundDown.DoRaycast(transform.position);

        if(!grounded){
            velocity.y -= gravity * Time.deltaTime;
        }
        else{
            velocity.y = 0;
        }

        Vector2 displacement = Vector2.zero;

        if(velocity.x > 0){
            displacement.x = moveRight.DoRaycast(transform.position,velocity.x * Time.deltaTime);
        }
        else if(velocity.x < 0){
            displacement.x = -moveLeft.DoRaycast(transform.position, -velocity.x *Time.deltaTime);
        }
        if(velocity.y > 0){
            displacement.y = moveRight.DoRaycast(transform.position,velocity.y * Time.deltaTime);
        }
        else if(velocity.y < 0){
            displacement.y = -moveLeft.DoRaycast(transform.position, -velocity.y *Time.deltaTime);
        }
        transform.Translate(displacement);

    }
}
