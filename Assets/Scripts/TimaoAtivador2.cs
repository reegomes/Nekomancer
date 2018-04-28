using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimaoAtivador2 : MonoBehaviour {

    public GameObject timaoAtivador2;
    public bool desceJao;

	// Use this for initialization
	void Start () {
        desceJao = false;
	}
	
	// Update is called once per frame
	void Update () {
        //timaoAtivador2.GetComponent<HingeJoint2D>().useMotor = true;
        timaoAtivador2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
