using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerdeVidas : MonoBehaviour {

	public Vector3 posicaoInicial;
    public static int vidas = 7;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D other){

		personagem.vidas--;

		if (personagem.vidas == 0) 
		{
			SceneManager.LoadScene("GameOver");
		}
		else 
		{
			other.transform.position = posicaoInicial;
		}

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

