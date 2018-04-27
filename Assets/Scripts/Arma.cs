using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

	public GameObject municao;
	public GameObject arma;
	public Animator animator;
	public float distancia;
	public Transform projetil;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	void Update(){
		//distancia = Vector2.Distance(arma.transform.position, projetil.transform.position);
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.C)) {
			animator.SetBool ("tiro", true);
			animator.SetBool ("parado", false);
			Instantiate (municao, new Vector3 (arma.transform.position.x, arma.transform.position.y, arma.transform.position.z), arma.transform.rotation);
			Debug.Log("Teste, tiro instanciado");
		} 
		else 
		{
			animator.SetBool ("tiro", false);
		}

		if (distancia >= 1.5f)
		{

            //Destroy(municao.gameObject);
		}
	}
}