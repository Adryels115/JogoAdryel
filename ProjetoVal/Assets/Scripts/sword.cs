using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirEspada : MonoBehaviour
{
    public GameObject espada;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(espada.gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void destruirEspada()
    {
        Destroy(espada.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("dano"))
        {
            Destroy(collision.gameObject);
           
        }
        
    }
}