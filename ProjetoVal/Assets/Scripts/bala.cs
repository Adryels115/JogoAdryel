using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;


public class bala : MonoBehaviour
{
    
     private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("dano"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        
    }
   
}
