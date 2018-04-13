using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

	public GameObject municao;
	public GameObject arma;
	public Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.X)) {
			animator.SetBool ("tiro", true);
			animator.SetBool ("parado", false);
			Instantiate (municao, new Vector3 (arma.transform.position.x, arma.transform.position.y, arma.transform.position.z), arma.transform.rotation);
		} 
		else 
		{
			animator.SetBool ("tiro", false);
		}
	}
}
