using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameTitleManager : MonoBehaviour
{
    public static GameTitleManager gametitleInstance;

    PuntosDeSpawn SpawnpointScript;
    int rondaInicial;
    
    
    
    public static GameTitleManager GameManager;


    // Start is called before the first frame update

    private void Awake()
    {
        if (gametitleInstance == null)
        {
            gametitleInstance = this;
            DontDestroyOnLoad(gametitleInstance);
        }
        else
        {
            Destroy(gametitleInstance);
        }


        
    }
    private void Update()
    {
        
        
       
        





    }
    // Update is called once per frame
    public void ComenzarPartidaNueva()
    {
        
        SceneManager.LoadScene(1);
        
    }
    public void IrAOpciones()
    {
        SceneManager.LoadScene(2);
    }
    public void VolverAPantallaDeTitulo()

    {
        
        SceneManager.LoadScene(0);
        
    }
    public void SalirDelJuego()
    {
        Application.Quit();
    }
    public void ComoJugar()
    {

        SceneManager.LoadScene(3);

    }
    
    
}
