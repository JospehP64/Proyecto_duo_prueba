using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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
}
