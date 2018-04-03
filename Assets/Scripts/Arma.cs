using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

	public GameObject municao;
	public GameObject arma;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.X))
    	{
        	Instantiate(municao, new Vector3(arma.transform.position.x, arma.transform.position.y, arma.transform.position.z), arma.transform.rotation);
    	}
	}
}
