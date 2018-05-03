using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personagem : MonoBehaviour
{
    public Animator animatorPersonagem;
    public SpriteRenderer srPersonagem;
    public Rigidbody2D rbPersonagem;

    public float velocidade;
    public float forcaPulo;

    float movimentoHorizontal;
    float posicaoHorizontalAtual;
    float posicaoVerticalAtual;
    public bool noChao;
	public int puloDuplo = 2;
    public bool LadoTiro;

    public GameObject municao, municao2, arma, arma2;


    void Start() {
        LadoTiro = true;
    }
    void Update()
	{
        movimentoHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;

    // Tiros

    if (Input.GetKeyDown(KeyCode.C) && LadoTiro == true)
    {
        animatorPersonagem.SetBool("tiro", true);
        Invoke("Teste", 0.5f);
        Instantiate(municao, new Vector3(arma.transform.position.x, arma.transform.position.y, arma.transform.position.z), arma.transform.rotation);
    }
    else if (Input.GetKeyDown(KeyCode.C) && LadoTiro == false)
    {
        animatorPersonagem.SetBool("tiro", true);
        Invoke("Teste", 0.5f);
        Instantiate(municao2, new Vector3(arma2.transform.position.x, arma2.transform.position.y, arma2.transform.position.z), arma2.transform.rotation);
    }
    else
    {
       //animator.SetBool("tiro", false);
    }
}

    void FixedUpdate()
    {
        if (movimentoHorizontal == 0)
        {
            animatorPersonagem.SetBool("corrida", false);
        }
        else
        {
            animatorPersonagem.SetBool("corrida", true);
            if(movimentoHorizontal < 0)
            {
                srPersonagem.flipX = true;
                LadoTiro = false;
                //LadoT();
            }
            else
            {
                srPersonagem.flipX = false;
                LadoTiro = true;
                //LadoT();
            }
        }
        if (!noChao)
        {
            animatorPersonagem.SetBool("pulo", true);
            animatorPersonagem.SetBool("parado", false);
		}

		if (Input.GetKeyDown(KeyCode.Space) && puloDuplo > 0)
        {
            rbPersonagem.velocity = new Vector2(0, 1) * forcaPulo * Time.deltaTime;
			puloDuplo--;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            animatorPersonagem.SetBool("espada",true);
            Invoke("Teste", 0.5f);
        }

        /*if (Input.GetKeyDown(KeyCode.C))
        {
            animatorPersonagem.SetBool("tiro", true);
            Invoke("Teste", 0.5f);

        }*/
          if(Input.GetKeyDown(KeyCode.E))
        {
            animatorPersonagem.SetBool ("ativador",true);
            Invoke("Teste",0.5f);
        }

        posicaoHorizontalAtual = transform.position.x + (movimentoHorizontal * velocidade) * Time.deltaTime;

        transform.position = new Vector2(posicaoHorizontalAtual, transform.position.y);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "plataformas" || col.gameObject.tag == "caixas")
        {
            noChao = true;
            animatorPersonagem.SetBool("pulo", false);  
		}
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "plataformas")
        {
            noChao = false;
        }
    }
	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "plataformas" || col.gameObject.tag == "caixas")
		{
			puloDuplo = 2;
		}
	}

    void Teste()
    {
        animatorPersonagem.SetBool("parado", true);
        animatorPersonagem.SetBool("espada", false);
        animatorPersonagem.SetBool("tiro", false);
        animatorPersonagem.SetBool("ativador",false);
    }
}
