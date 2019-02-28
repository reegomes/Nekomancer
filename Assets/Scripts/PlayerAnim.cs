using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    NewPlayer plRef;
    Rigidbody2D rb;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        plRef = GetComponent<NewPlayer>();
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(plRef.bGrounded && Input.GetAxisRaw("Vertical") < 0){
            anim.SetBool("Down", true);
        }
        else{
            anim.SetBool("Down",false);
        }
        if(rb.velocity.y < 0){
            anim.SetBool("Falling",true);
        }
        else{
            anim.SetBool("Falling",false);
            if(rb.velocity.y > 0){
                anim.SetTrigger("Jumping");
            }
        }
        if(rb.velocity.x != 0){
            anim.SetBool("isRunning", true);
        }
        else{
            anim.SetBool("isRunning", false);
        }

        if(!plRef.bGrounded && plRef.bWalled){
            anim.SetBool("Walled", true);
        }
        else{
            anim.SetBool("Walled",false); 
        }

        if(Input.GetKeyDown(KeyCode.X)){
            anim.SetFloat("Atk",Input.GetAxisRaw("Vertical"));
            anim.SetTrigger("SideAttack");

        }
    }
}
