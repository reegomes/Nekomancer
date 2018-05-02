using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativador : MonoBehaviour {

    public bool desceJao, rodaTim, sobeJao;
    public float zRotation = 1.0f;
    public GameObject timaoAtivador2;
	// Use this for initialization
	void Start () {
        desceJao = false;
        rodaTim = false;
        sobeJao = false;
	}
	
	// Update is called once per frame
	void Update () {
    
    }
    private void OnTriggerStay2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E)){
                desceJao = true;
                Debug.Log("Colisão OK");
                rodaTim = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("CaixaAtivadora")){
            sobeJao = true;
            Debug.Log("SobeJãoDeveriaIniciar");
        }
    }
}
