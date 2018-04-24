using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public Animator animatorPersonagem;
    public SpriteRenderer srPersonagem;
    public Rigidbody2D rbPersonagem;

    public float velocidade;
    public float forcaPulo;

    public float movimentoHorizontal;
    public float posicaoHorizontalAtual;
    public float posicaoVerticalAtual;
    public bool noChao;
   
    void Update()
	{
        movimentoHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;

       
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
            }
            else
            {
                srPersonagem.flipX = false;
            }
        }
        if (!noChao)
        {
            animatorPersonagem.SetBool("pulo", true);
            animatorPersonagem.SetBool("parado", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && noChao == true)
        {
            rbPersonagem.velocity = new Vector2(0, 1) * forcaPulo * Time.deltaTime;
            
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            animatorPersonagem.SetBool("espada",true);
            Invoke("Teste", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animatorPersonagem.SetBool("tiro", true);
            Invoke("Teste", 0.5f);
        }

        posicaoHorizontalAtual = transform.position.x + (movimentoHorizontal * velocidade) * Time.deltaTime;

        transform.position = new Vector2(posicaoHorizontalAtual, transform.position.y);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "plataformas")
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

    void Teste()
    {
        animatorPersonagem.SetBool("parado", true);
        animatorPersonagem.SetBool("espada", false);
        animatorPersonagem.SetBool("tiro", false);
    }
}
