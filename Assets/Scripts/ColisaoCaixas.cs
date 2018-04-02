using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColisaoCaixas : MonoBehaviour

{
    //public float velocidade = 0f;

    void OnCollisionEnter2D(Collision2D caixasacao)
    {
        if (caixasacao.gameObject.CompareTag("ativador"))
        {
         Debug.Log("Colisão ok, falta ação das plataformas");
        // abaixarPlataforma == true;
        }
        if (caixasacao.gameObject.CompareTag("tiro"))
        {

        }
    }
    void OnCollisionExit2D(Collision2D caixasacao)
    {
        if (caixasacao.gameObject.CompareTag("ativador"))
        {
            Destroy(caixasacao.gameObject);
        }
    }
}
