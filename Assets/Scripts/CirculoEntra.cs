using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CirculoEntra : PerdeVidas {

    void OnCollisionEnter2D(Collision2D buracoentra)
    {
        if (buracoentra.gameObject.CompareTag("buracoentra") && PerdeVidas.vidas == 0)
        {
            Debug.Log("Perdeu uma vida?" + vidas);
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            Debug.Log("Perdeu uma vida, volta pra tela" + vidas);
            buracoentra.transform.position = posicaoInicial;
        }
    }
}
