using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class personagem : MonoBehaviour
{
    
    private float velocidade = 5f; // Velocidade
    public bool noChao = false; // Variavel para ver se o personagem está no chao
    public Transform verificaChao; // var pra detectar a colisao
    float raiodochao = 0.2f; // determina o raio do alcance do collider
    public LayerMask plataforma; // marca o que é e o que não é plataforma
    float pulo = 250.0f; // força do pulo
    public bool giraSprite = true; // gira o sprite caso ele vire de um lado para o outro
	//public static int vidas = 7;
	public Animator animator;
	public GameObject Espada;
    public Scrollbar vida, stamina;
    //public float vidaScroll, staminaScroll; Rapha, você ta usando isso? tinha 0 referencias e a gente gosta de trabalhar com referencias. ehauehua
    //teste ao vivo
    void Start()
    {
        //Inicia o animator
		animator = GetComponent<Animator>();
		Espada.SetActive(false);
        vida.size = 1f;
        stamina.size = 1f;
    }
    void Update()
	{
        if (vida.size == 1f)
        {
        
        }
        if (stamina.size < 1f)
        {
            stamina.size += 0.05f * Time.deltaTime;
            
        }
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))
        {
            stamina.size -= 0.20f;
        }
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
				
		noChao = Physics2D.OverlapCircle (verificaChao.position, raiodochao, plataforma);

		if (noChao && Input.GetKeyDown(KeyCode.Space)) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, pulo));
            animator.SetBool("pulo", true);
            //animator.SetBool("parado", false);
		} else {
			//animator.SetBool ("pulo", false);
            //animator.SetBool("parado", true);
		}

        // Teste Espada
        if (Input.GetKey(KeyCode.C))
        {
            Espada.SetActive(true);
            animator.SetBool("espada", true);
            animator.SetBool("parado", false);
        }
        else
        {
            Espada.SetActive(false);
            animator.SetBool("espada", false);
        }


	}
    void Flip()
	{
		giraSprite = !giraSprite;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}