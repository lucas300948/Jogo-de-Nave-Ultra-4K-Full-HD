using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovNave : MonoBehaviour
{
    
    public int Pontos;
    public TextMeshProUGUI TextoPontos;
    public TextMeshProUGUI TextoVida; // Pra fazer texto
    public GameObject Tiro;
    public Transform Postiro;
    public float eixoX; // Variavel
    public float eixoY;
    public Vector2 Dir; // Vetor
    public Rigidbody2D rbd2; // Corpo
    public int vida;
    public float Vel, velandar;
    public float LimiteRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // define bot�o para atirar
        {
            AtirarLaser();
        }
        eixoX = Input.GetAxis("Horizontal") * -1;
        rbd2.AddTorque(eixoX *Vel);
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) // define as teclas de movimenta��o
        {
            eixoY = 1;
        }
        else
        {
            eixoY = 0;
        }
        Dir = this.transform.up  * eixoY *velandar ;
        rbd2.linearVelocity = Dir;

        if (rbd2.angularVelocity <= -LimiteRot)
        {
            rbd2.angularVelocity = -LimiteRot;
        } else if (rbd2.angularVelocity >= LimiteRot)
        {
            rbd2.angularVelocity = LimiteRot;
        }

    }
    public void AtirarLaser()
    {
        GameObject Obj = Instantiate(Tiro, Postiro.position, this.transform.rotation) ;
        Obj.GetComponent<Lazer>().Papoco(this.transform.up);
        
    }
    public void TomaDano(int dano)
    {
        vida = vida - dano;
        TextoVida.text = "Vida:" + vida;
        if (vida <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void AdicionaPontos(int PontosParametro)
    {
        Pontos = Pontos + PontosParametro; // pega a variavel pontos e define que o parametro � igual a pontos e como vai ser o calculo
        TextoPontos.text = "Pontos: " + Pontos; // Mostra os pontos atualizados
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteoro"))
        {
            TomaDano(collision.gameObject.GetComponent<Meteoro>().dano);
        }
    }
}
