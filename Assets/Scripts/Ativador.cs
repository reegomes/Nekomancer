using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativador : MonoBehaviour {

    public bool desceJao, rodaTim;
    public float zRotation = 1.0f;
    public GameObject timaoAtivador2;
	// Use this for initialization
	void Start () {
        desceJao = false;
        rodaTim = false;
	}
	
	// Update is called once per frame
	void Update () {
    
    }
    private void OnTriggerStay2D(Collider2D other) {


        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (desceJao == false)
            {
                desceJao = true;
                Debug.Log("Colisão OK");
                rodaTim = true;
            }
            else if (desceJao == true)
            {
                desceJao = false;
                rodaTim = false;
            }
                
        }
    }
}
