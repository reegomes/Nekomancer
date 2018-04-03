using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiros : MonoBehaviour {

    // Use this for initialization
    public float timer = 0.1f;
    public GameObject tiro;
    public float zRotation = 1.0f;
    //public float yPosition = 1.0f;
    Vector3 velocity = new Vector3(1.0f, 0.0f, 0.0f);

    void OnCollisionEnter2D(Collision2D outros)
    {
        if(outros.gameObject.CompareTag("plataformas"))
        {
            Destroy(outros.gameObject);
            Destroy(tiro.gameObject);
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        zRotation--;
        tiro.transform.eulerAngles = new Vector3(10, 0, zRotation);
        tiro.transform.position += velocity * Time.fixedDeltaTime;

        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(tiro, new Vector3(2.0f, 0, 0), Quaternion.identity);
        }
    }
}
