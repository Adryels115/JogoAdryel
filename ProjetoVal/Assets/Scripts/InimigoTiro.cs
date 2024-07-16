using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class InimigoTiro : MonoBehaviour
{
     public float velocidadekunai;
    public Transform posicaokunai;
    public GameObject kunai;
    public GameObject player;
    private Animator anim;
    private bool verificarDirecao;
    public GameObject direcaokunai;
    public  GameObject inimigotiro;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       InvokeRepeating("atirarMunicao", 0.3f ,0.7f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

     public void atirarMunicao()
    {  if(player.transform.position.x >= inimigotiro.transform.position.x -15 && player.transform.position.x < inimigotiro.transform.position.x)
        {
           
        GameObject temporario = Instantiate(kunai);
        temporario.transform.position = inimigotiro.transform.position;
        temporario.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadekunai, 0);
        anim.SetTrigger("tiroInimigo");   
       
        }
        
        else
        {
            anim.SetTrigger("inimigoParado");
        }
        
    }
     public void direcao()
    {
        verificarDirecao = !verificarDirecao;
        
        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

        velocidadekunai *= -1;
     
        direcaokunai.GetComponent<SpriteRenderer>().flipX = verificarDirecao;
 
       
    }
}
