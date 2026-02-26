using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Meteoro : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float vel;
    public int dano;
    public int Pontos;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3f); // destroi o obijeto
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void VoaMeteoro(Vector3 pos)
    {
        Vector3 dir = pos - this.gameObject.transform.position ;
        rb2d.linearVelocity = dir * vel;    
    }
    

}
