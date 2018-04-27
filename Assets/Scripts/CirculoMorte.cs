using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CirculoMorte : PerdeVidas {

    void OnCollisionEnter2D(Collision2D buracomorte)
    {
        PerdeVidas.vidas--;
        if (buracomorte.gameObject.CompareTag("buracomorte") && PerdeVidas.vidas == 0)
        {
            Debug.Log("Perdeu uma vida?" + vidas);
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            Debug.Log("Perdeu uma vida, volta pra tela" + vidas);
            buracomorte.transform.position = posicaoInicial;
        }
    }
}
