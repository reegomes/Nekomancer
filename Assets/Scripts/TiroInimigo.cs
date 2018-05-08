using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigo : MonoBehaviour {

    float speed;
    Vector2 _direction;
    bool isReady;

	// Use this for initialization
	void Awake () {
        speed = 5f;
        isReady = false;
	}

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;
        }

        if (this.gameObject.transform.position.x < 150f || this.gameObject.transform.position.y < -80f)
        {
            Destroy(this.gameObject);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }*/
}
