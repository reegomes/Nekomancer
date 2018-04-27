using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CirculoVolta : PerdeVidas {

    void OnCollisionEnter2D(Collision2D buracovolta)
    {
        if (buracovolta.gameObject.CompareTag("buracovolta") && PerdeVidas.vidas == 0)
        {
            Debug.Log("Perdeu uma vida?" + vidas);
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            Debug.Log("Perdeu uma vida, volta pra tela" + vidas);
            buracovolta.transform.position = posicaoInicial;
        }
    }
}
