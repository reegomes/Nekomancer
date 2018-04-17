using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour {

	//public GameObject rangeEspada;
	//Animator animator;
	// Use this for initialization
	void Start () {
		//animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () { /* 
		if (Input.GetKeyDown (KeyCode.C)) {
			rangeEspada.SetActive(true);
			animator.SetBool ("espada", true);
			animator.SetBool ("parado", false);
		} 
		else 
		{
			animator.SetBool ("espada", false);
		}*/
    }

	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.CompareTag("caixas")){
            Destroy(other.gameObject);
		}
	}
}
