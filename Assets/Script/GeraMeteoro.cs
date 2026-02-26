using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraMeteoro : MonoBehaviour
{
    public GameObject meteoroPrefab;
    public List<Transform> posParaCriar; // lista onde cria os meteoros
    public float Timer, TempoParaCriar;
    public float TempoMin, TempoMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime; // Cria um timer para criar o meteoro
        if (Timer >= TempoParaCriar)
        {
            CriaMeteoro();
            Timer = 0;
            TempoParaCriar = Random.Range(TempoMin, TempoMax);
           
        }
    }
    public void CriaMeteoro() // cria o meteoro
    {
        GameObject obj = Instantiate(meteoroPrefab, posParaCriar[Random.Range(0, posParaCriar.Count)].position, this.transform.rotation );
        obj.GetComponent<Meteoro>().VoaMeteoro(Vector3.zero);
    }
}
