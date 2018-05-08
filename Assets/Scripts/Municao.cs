using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour {
	public float vel;
    public GameObject municao;
	void Update () {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));
	}

    void Start()
    {
        Invoke("Destruindo", 2.5f);    
    }


    void OnCollisionEnter2D(Collision2D outros)
    {
        if (outros.gameObject.CompareTag("caixas"))
        {
            Destroy(outros.gameObject);
            Destroy(municao.gameObject);
        }
        else if (outros.gameObject.CompareTag("plataformas") || outros.gameObject.tag == "void")
        {
            Destroy(municao.gameObject);
        }
        
    }

    void Destruindo()
    {
        Destroy(this.gameObject);
    }

}
