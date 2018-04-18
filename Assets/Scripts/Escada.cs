using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escada : MonoBehaviour {
	//bool Upmovement = false;
	// Use this for initialization
	public bool sobe;
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		if (sobe == true){
			transform.Translate(new Vector3(0, 5.0f * Time.deltaTime, 0));
		}
		else
		{
			transform.Translate(new Vector3(0, 0, 0));
			sobe = false;
		}
	}
	public void OnCollisionStay2D(Collision2D escada)
    {
        if (escada.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisão escada ok");
			sobe = true;
		}
    }

		void OnTriggerEnter2D(Collider2D paraescada)
	{
		if (paraescada.gameObject.CompareTag("paraescada"))
		{
		Debug.Log("Colidiu com o para colisao");
		sobe = false;
		}
	}
}
