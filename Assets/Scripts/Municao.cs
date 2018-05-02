using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour {
	public float vel;
    public GameObject municao;
	void Update () {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));
	}

    void OnCollisionEnter2D(Collision2D outros)
    {
        if (outros.gameObject.CompareTag("caixas"))
        {
            Destroy(outros.gameObject);
            Destroy(municao.gameObject);
        }
    }
}
