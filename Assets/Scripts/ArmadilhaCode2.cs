using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilhaCode2 : MonoBehaviour
{
    public bool liberaArmadilha;
    public GameObject armadilha;
    void Start()
    {
        liberaArmadilha = false;
    }
    void Update()
    {
        if (liberaArmadilha == true)
        {
            armadilha.GetComponent<FixedJoint2D>().breakForce = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            liberaArmadilha = true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("plataformas"))
        {
            //Destroy(this.gameObject, 5.0f);
        }
    }
}
