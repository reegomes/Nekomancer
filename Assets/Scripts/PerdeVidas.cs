
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 public class PerdeVidas : Personagem {

	public Vector3 posicaoInicial;
    // Use this for initialization

    void OnCollisionEnter2D(Collision2D fimdatela)
    {
        vida.size -= 0.10f;        
        if (fimdatela.gameObject.CompareTag("fundodatela") && vida.size == 0)
        {
            Debug.Log("Perdeu uma vida?" + vida.size);
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            Debug.Log("Perdeu uma vida, volta pra tela" + vida.size);
            fimdatela.transform.position = posicaoInicial;
        }
    }
}
