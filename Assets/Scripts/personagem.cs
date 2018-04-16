using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personagem : MonoBehaviour
{
    
    public float velocidade = 0f; // Velocidade
    public bool noChao = false; // Variavel para ver se o personagem está no chao
    public Transform verificaChao; // var pra detectar a colisao
    float raiodochao = 0.2f; // determina o raio do alcance do collider
    public LayerMask plataforma; // marca o que é e o que não é plataforma
    public float pulo; // força do pulo
    public bool giraSprite = true; // gira o sprite caso ele vire de um lado para o outro
	public static int vidas = 7;
	public bool Upmovement;
	public Animator animator;

    void Start()
    {
        //Inicia o animator
		animator = GetComponent<Animator>();
		Upmovement = false;
    }
    void Update()
	{ 
		//Puxa a animação do animator
		if (Input.GetAxis ("Horizontal") != 0) 
		{
			animator.SetBool ("corrida", true);
			animator.SetBool ("parado", false);
		} 
		else
		{
			animator.SetBool ("corrida", false);
			animator.SetBool ("parado", true);
		}

		float movimento = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (movimento * velocidade, GetComponent<Rigidbody2D> ().velocity.y);
		if (movimento > 0 && !giraSprite) 
		{
			Flip ();
		} else if (movimento < 0 && giraSprite) 
		{
			Flip ();
		}
		
		/*
		noChao = Physics2D.OverlapCircle (verificaChao.position, raiodochao, plataforma);

		if (noChao && Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, pulo));
			animator.SetBool ("pulo", true);
			animator.SetBool ("parado", false);
		} else 
		{
			animator.SetBool ("pulo", false);
		}*/

	}
    void Flip()
	{
		giraSprite = !giraSprite;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void Subir()
	{

    }
}
