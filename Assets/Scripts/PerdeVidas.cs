using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerdeVidas : MonoBehaviour {

	public Vector3 posicaoInicial;
    public static int vidas = 6;
    // Use this for initialization

    void OnCollisionEnter2D(Collision2D fimdatela)
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
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

