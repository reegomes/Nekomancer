using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float TimeSet;
    float timeToUp;
    bool flag;
    public LayerMask playerLayer;

    public float xx,yy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var plRef = Physics2D.BoxCast(transform.position,new Vector2(5,1),0f,Vector2.left,0f,playerLayer);
        if((timeToUp<TimeSet && timeToUp >= -1) && !flag )
        {
            timeToUp+=Time.deltaTime;
            transform.position += new Vector3(xx,yy) * Time.deltaTime;
            if(plRef){
                plRef.transform.position += new Vector3(xx,yy) * Time.deltaTime;
            }   
            
        }
        else
        {
            if(timeToUp <0){
                flag = false;
            } 
            else
            {
                flag = true;
            }
            timeToUp -= Time.deltaTime;
            transform.position += new Vector3(-(xx),-(yy)) * Time.deltaTime;
            if(plRef){
                plRef.transform.position += new Vector3(-(xx),-(yy)) * Time.deltaTime;
            } 
        }
    }
}
