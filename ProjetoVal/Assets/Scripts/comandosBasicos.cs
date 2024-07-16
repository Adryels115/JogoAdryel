using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEditor.Callbacks;


public class comandosBasicos : MonoBehaviour
{
    public float velocididadePersonagem;
    private Rigidbody2D rbPlayer;
    private float movimentoHorizontal;
    private Animator anim;
    private bool verificarDirecao;
    public float jump;
    public Transform posicaoSensor;
    private bool sensor;
    public int vida;
    public int municao;
    public int coin;
    public TextMeshProUGUI textovida;
    public TextMeshProUGUI textomunicao; 
    public TextMeshProUGUI textocoin;
    public GameObject painelGameOver;
    //munição
    public float velocidadeBala;
    public Transform posicaoBala;
    public GameObject municao01;
    public GameObject direcaoMunicao;
    public float pauseDelay = 3.0f;
    private AudioManager audioManager;
    public GameObject espada;
    public Transform hitbox;

 
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        vida = 2;
        municao = 5;
        audioManager = FindObjectOfType(typeof(AudioManager)) as AudioManager;
    }

    // Update is called once per frame
    void Update()
    {
        movimentoHorizontal = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(movimentoHorizontal*velocididadePersonagem, rbPlayer.velocity.y);
        anim.SetInteger("run", (int)movimentoHorizontal);

       
        pular();
        detectarChao(); 
        anim.SetBool("sensor", sensor);

        textovida.text = vida.ToString();
        textomunicao.text = municao.ToString();
        textocoin.text = coin.ToString();

        if(vida > 0)
        {
            if(movimentoHorizontal > 0 && verificarDirecao == true)
            {
            direcao();
            }
            else if(movimentoHorizontal < 0 && verificarDirecao == false)
            {
            direcao();
            }
            
        }
        else
        {
            anim.SetTrigger("morte");
            velocididadePersonagem = 0;
           painelGameOver.SetActive(true);
            audioManager.SFXManager(audioManager.SFXMorte, 0.7f);
            StartCoroutine(Die());
            
            
        }
        
        if(Input.GetMouseButtonDown(0) && municao>0)
        {
            audioManager.SFXManager(audioManager.SFXTiro, 0.3f);
            atirarMunicao();
            municao--;
            anim.SetTrigger("AtirarParado");
        }
         if(Input.GetMouseButtonDown(1))
         {
             atacar();

         }

    }

    public void direcao()
    {
        verificarDirecao = !verificarDirecao;
        
        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

        velocidadeBala *= -1;
     
        direcaoMunicao.GetComponent<SpriteRenderer>().flipX = verificarDirecao;
 
       
    }

    public void pular()
    {
        if(Input.GetButtonDown("Jump") && sensor == true)
        {
            rbPlayer.AddForce(new Vector2(0,jump));
           
        }
    }

    public void detectarChao()
    {
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.25f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.CompareTag("coin"))
        {
           coin++; 
           Destroy(collision.gameObject);
           audioManager.SFXManager(audioManager.SFXColetar, 0.3f);
        }
        if(collision.gameObject.CompareTag("porta") && coin >=3)
        {   
            SceneManager.LoadScene("Fase2");
            Time.timeScale = 1;
           
        }
        if(collision.gameObject.CompareTag("coletavel"))
        {
            vida +=1;
            Destroy(collision.gameObject);
            audioManager.SFXManager(audioManager.SFXColetar, 0.3f);
        }

        else if(collision.gameObject.CompareTag("municao"))
        {
            municao++;
            Destroy(collision.gameObject);
            audioManager.SFXManager(audioManager.SFXColetar, 0.3f);
        }

        if(collision.gameObject.CompareTag("dano"))
        {
            vida --;
            audioManager.SFXManager(audioManager.SFXDano, 0.3f);

            
        }
       if(collision.CompareTag("kunai"))
        {
            Destroy(collision.gameObject);
            vida --;
            audioManager.SFXManager(audioManager.SFXDano, 0.3f);
        }
         if(collision.CompareTag("agua"))
        {
            vida -=50;
        }
         if(collision.CompareTag("suprimentos"))
        {
            Destroy(collision.gameObject);
            audioManager.SFXManager(audioManager.SFXColetar, 0.3f);
            vida += 5;
            municao+=5;
        }    
    }
    public void reiniciarJogo()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    } 

  
    public void sairJogo()
    {
        SceneManager.LoadScene("TelaInicial"); 
    }
    public void atirarMunicao()
    {
        GameObject temporario = Instantiate(municao01);
        temporario.transform.position = posicaoBala.transform.position;
        temporario.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeBala, 0);
    }

    IEnumerator Die()
    {
        
        yield return new WaitForSeconds(pauseDelay); 
        Time.timeScale = 0;
        audioManager.SFXManager(audioManager.SFXMorte, 0f);
    }
    public void atacar()
{
    if (Input.GetMouseButtonDown(1))
    {
        anim.SetTrigger("ataque");
        Instantiate(espada, hitbox.position, Quaternion.identity);

    }
   
}

} 

