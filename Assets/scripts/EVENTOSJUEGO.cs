using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVENTOSJUEGO : MonoBehaviour
{
    public static EVENTOSJUEGO EventosDeJuego;
    [SerializeField] Canvas CanvasGameOver;
    [SerializeField] Canvas CanvasPausa;
    [SerializeField]PuntosDeSpawn Spawnpoints;
    [SerializeField]MovimientoPersonaje PlayerScript;
    int vidaJugador;
     bool JuegoEnPausa = false;
    bool JugadorDerrotado;
    
    // Start is called before the first frame update
    private void Awake()
    {
        
        
        
        if (EventosDeJuego == null)
        {
            EventosDeJuego = this;
            DontDestroyOnLoad(EventosDeJuego);
        }
        else
        {
            Destroy(EventosDeJuego);
        }
        JuegoEnPausa = false;
        Time.timeScale = 1.0f;
    }
    void Start()
    {
        
        JugadorDerrotado = PlayerScript.PlayerIsDefeated;

        vidaJugador = PlayerScript.vida;

        CanvasPausa.enabled = false;
        CanvasGameOver.enabled = false;
        
    }
    private void Update()
    {
        PausarJuego();
        PantallaDeGameOver();
    }

    // Update is called once per frame
    void PausarJuego()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && JuegoEnPausa == false && vidaJugador > 0)
        {
            CanvasPausa.enabled = true;
            JuegoEnPausa = true;
            Time.timeScale = 0;
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && JuegoEnPausa == true && vidaJugador > 0)
        {
            CanvasPausa.enabled = false;
            Time.timeScale = 1;
            JuegoEnPausa = false;
        }
       
        
    }
    public void BotonPausarJuego()
    {
        if (JuegoEnPausa == false && vidaJugador > 0)
        {
            CanvasPausa.enabled = true;
            JuegoEnPausa = true;
            Time.timeScale = 0;

        }
        else if ( JuegoEnPausa == true && vidaJugador > 0)
        {
            CanvasPausa.enabled = false;
            Time.timeScale = 1;
            JuegoEnPausa = false;
        }


    }
    void PantallaDeGameOver()
    {
        if (PlayerScript.PlayerIsDefeated == true)
        {
            CanvasGameOver.enabled = true;
            CanvasPausa.enabled = false;
            
        }
    }

}
