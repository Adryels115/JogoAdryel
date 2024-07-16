using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene", 0);
        Time.timeScale = 1;
    } 
     public void QuitGame()
    {
       Application.Quit();
    } 
}
