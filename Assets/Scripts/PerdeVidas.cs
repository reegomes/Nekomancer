using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerdeVidas : MonoBehaviour {

	public Vector3 posicaoInicial;
    public static int vidas = 7;

    private void OnTriggerEnter2D(Collider2D fimdatela)
    {
        PerdeVidas.vidas--;
        if (fimdatela.gameObject.CompareTag("fundodatela") && PerdeVidas.vidas == 0)
        {
            Debug.Log("Perdeu uma vida?" + vidas);
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            Debug.Log("Perdeu uma vida, volta pra tela" + vidas);
            fimdatela.transform.position = posicaoInicial;
        }
    }
}

