using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorDaMorte : MonoBehaviour {

	public bool sobe, desce;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		if (sobe == true){
			transform.Translate(new Vector3(0, 5.0f * Time.deltaTime, 0));
			desce = false;
		}
		else if (desce == true)
		{
			transform.Translate(new Vector3(0, -5.0f * Time.deltaTime, 0));
			sobe = false;
		}
		else
		{
		desce = false;
		sobe = false;
		}
	}
	public void OnCollisionExit2D(Collision2D caixas)
	{
		if (caixas.gameObject.CompareTag("caixas"))
		{
			Debug.Log("Saida da caixa ok");
			sobe = true;
		}
	}
	public void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("paraescada"))
		{
			Debug.Log("Colidiu com o para colisao");
			sobe = false;
			desce = true;
		}
		if (other.gameObject.CompareTag("sobearmadilha"))
		{
			desce = false;
			sobe = true;
		}
	}
}
