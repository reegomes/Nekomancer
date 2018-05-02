using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiberaPassagem : Ativador {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("caixas"))
        {
            if(sobeJao == true)
            {
                Debug.Log("Colisão ok, falta ação das plataformas");
//              timaoAtivador2.GetComponent<HingeJoint2D>().enableCollision = enabled;
            }
        }
    }
}
