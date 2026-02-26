using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int dano;
    public int vel;
    internal Color color;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3f); // destroi depois de 3 segundos
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Papoco(Vector2 Dir)
    {
        rb2d.AddForce(Dir *vel); // da força para o tiro ir a algum lugar
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteoro")) // caso o tiro acerte alguem com a teg meteoro
        {
            GameObject.FindWithTag("Player").gameObject.GetComponent<MovNave>().AdicionaPontos(collision.gameObject.GetComponent<Meteoro>().Pontos); // acha o player e da pontos para ele
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
;
    }
}
