using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vilao : MonoBehaviour {

	public float vel = 1.0f;
	public bool liberap = false;
	public float distancia;
	public Transform Momochi;
	public bool face = true;
	Animator animator;
    public AudioSource amaterasu;
    public AudioClip amate;
    public GameObject tiroInimigo;
    public int vidaVilao = 15;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Ver distancia
		distancia = Vector2.Distance(this.transform.position, Momochi.transform.position);
		// Flip
		if ((Momochi.transform.position.x > this.transform.position.x) && !face)
		{
			Flip();
		}
		else if ((Momochi.transform.position.x < this.transform.position.x) && face)
		{
			Flip();
		}
		// Perseguir
		if ((liberap == true) && (distancia > 12.8f && distancia < 19.0f))
		{
			if(Momochi.transform.position.x < this.transform.position.x)
			{
				transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
			}
			else if (Momochi.transform.position.x > this.transform.position.x)
			{
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
			}
            GameObject tiro = (GameObject)Instantiate(tiroInimigo);
            tiro.transform.position = new Vector2(transform.position.x - 5,transform.position.y);
            Vector2 direction = Momochi.transform.position - tiro.transform.position;
            tiro.GetComponent<TiroInimigo>().SetDirection(direction);
		}
		// Animações
		if (liberap == true) 
		{
			animator.SetBool ("voidmovendo", true);
			animator.SetBool ("voidparado", false);
            amaterasu.Play();
		}
		else
		{
			animator.SetBool ("voidmovendo", false);
			animator.SetBool ("voidparado", true);
		}
		// Ataque Braço
		if ((liberap == true) && distancia < 2.8f)
		{
			animator.SetBool ("voidatqbraco", true);
		}
		else 
		{
			animator.SetBool("voidatqbraco", false);
		}
		// Atirando
		if ((liberap == true) && (distancia > 10.0f))
		{
			animator.SetBool ("voidparado", false);
			animator.SetBool ("voidgiro", true);
		}
        if (vidaVilao <= 0){
            animator.SetBool("voidMorreu",true);
            Invoke("Death", 1f);
        }
	}
	void Flip()
	{
		face = !face;
		Vector3 scala = this.transform.localScale;
		scala.x *= -1;
		this.transform.localScale = scala;
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")){
			liberap = true;
		}
       
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "tiro")
        {
            vidaVilao--;
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
