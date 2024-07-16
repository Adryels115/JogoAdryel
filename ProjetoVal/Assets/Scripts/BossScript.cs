using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
     public float velocidadeInimigo;
    public float velocidadeAtual;
    public bool verificarDirecao;
    public GameObject player;
    public bool spriteBoss;
    public int vidaBoss;
    private Animator anim;
    public float distancia;
    void Start()
    {
          velocidadeInimigo = velocidadeAtual;
          vidaBoss=50;
          anim = this.transform.Find("model").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
       
        distancia = Vector3.Distance(player.transform.position, transform.position);
        if(vidaBoss>0)
        {
        if(distancia <= 20)
        {


        if(transform.position.x <= 48 && verificarDirecao == true)
        {
            velocidadeInimigo = velocidadeAtual;
            direcao();
       
        }
        else if(transform.position.x >=77 && verificarDirecao == false)
        {
            velocidadeInimigo = -velocidadeAtual;
            direcao();
           
        }
        
        transform.Translate(new Vector2(velocidadeInimigo, 0) * Time.deltaTime);
        }
    }
        
    else if(vidaBoss <=0)
    {
        anim.SetTrigger("morteboss");
        
    }
    }
         
      public void direcao()
    {
         verificarDirecao = !verificarDirecao;
        
        float x = transform.localScale.x *-1;

        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bala"))
        {
            vidaBoss -= 50;
        }
    }
}
