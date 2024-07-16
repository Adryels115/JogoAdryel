using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float velocidadeInimigo;
    public float velocidadeAtual;
    public bool verificarDirecao;
   
    // Start is called before the first frame update
    void Start()
    {
        velocidadeInimigo = velocidadeAtual;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= 44 && verificarDirecao == true)
        {
            velocidadeInimigo = velocidadeAtual;
            direcao();
       
        }
        else if(transform.position.x >=63 && verificarDirecao == false)
        {
            velocidadeInimigo = -velocidadeAtual;
            direcao();
           
        }
        
        transform.Translate(new Vector2(velocidadeInimigo, 0) * Time.deltaTime);
       
    }
    public void direcao()
    {
         verificarDirecao = !verificarDirecao;
        
        float x = transform.localScale.x *-1;

        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

    }
   
}
