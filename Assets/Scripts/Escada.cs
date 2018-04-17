using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escada : personagem {
	//bool Upmovement = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerStay2D(Collider2D escada)
    {
        if (escada.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisão escada ok");
			base.Upmovement = true;
        }
    }
}
