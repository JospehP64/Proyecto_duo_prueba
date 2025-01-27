using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTitleManager : MonoBehaviour
{
    public static GameTitleManager GameManager;
 
    // Start is called before the first frame update
    private void Awake()
    {

        if (GameManager == null)
        {
            GameManager = this;
            DontDestroyOnLoad(GameManager);
        }
        else
        {
            Destroy(gameObject);
            
        }
        
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
}
