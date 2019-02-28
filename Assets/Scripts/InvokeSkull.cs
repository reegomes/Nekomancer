using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeSkull : MonoBehaviour
{
    [SerializeField] GameObject skull;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("InvokeSkullMet",1f);
        
    }

    void InvokeSkullMet(){
        Destroy(this.gameObject,0.5f);
        Instantiate(skull,transform.position,Quaternion.identity);
    }
}
