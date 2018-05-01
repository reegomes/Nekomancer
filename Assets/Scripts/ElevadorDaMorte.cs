using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorDaMorte : MonoBehaviour {

	float subindo = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D(Collider2D other) {
		if (this.gameObject.CompareTag("caixas")){
			
		}	
	}
}
