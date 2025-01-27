using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVENTOSJUEGO : MonoBehaviour
{
    public static EVENTOSJUEGO EventosDeJuego;
    [SerializeField] Canvas CanvasGameOver;
    [SerializeField] Canvas CanvasPausa;

    MovimientoPersonaje PlayerScript;
     bool JuegoEnPausa = false;
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
        CanvasPausa.enabled = false;
        CanvasGameOver.enabled = false;
        
    }
    private void Update()
    {
        PausarJuego();
    }

    // Update is called once per frame
    void PausarJuego()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && JuegoEnPausa == false && PlayerScript.vida > 0)
        {
            CanvasPausa.enabled = true;
            JuegoEnPausa = true;
            Time.timeScale = 0;
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && JuegoEnPausa == true && PlayerScript.vida > 0)
        {
            CanvasPausa.enabled = false;
            Time.timeScale = 1;
            JuegoEnPausa = false;
        }
       
        
    }
    public void BotonPausarJuego()
    {
        if (JuegoEnPausa == false && PlayerScript.vida > 0)
        {
            CanvasPausa.enabled = true;
            JuegoEnPausa = true;
            Time.timeScale = 0;

        }
        else if ( JuegoEnPausa == true && PlayerScript.vida > 0)
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
