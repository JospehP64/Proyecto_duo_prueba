using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.TimeZoneInfo;
using Unity.VisualScripting;

public class EVENTOSJUEGO : MonoBehaviour
{
    [SerializeField]int transitionTimer;
    
    public static EVENTOSJUEGO EventosDeJuego;
    [SerializeField] GameObject PlayerInGame;
    [SerializeField] Canvas CanvasGameOver;
    [SerializeField] Canvas VictoryScreen;
    [SerializeField] Canvas CanvasTransition;
    [SerializeField] Canvas CanvasPausa;
    [SerializeField]PuntosDeSpawn Spawnpoints;
    [SerializeField]MovimientoPersonaje PlayerScript;
    [SerializeField] RawImage AvisoCoches;
    [SerializeField] GUI_SO gui_SO_data;
    [SerializeField] Texture[] TexturaRondas;
    [SerializeField] Texture[] TexturasGameOverScreen;
    [SerializeField] Texture[] TexturasVictoryScreen;
    [SerializeField] RawImage AvisoRondas;
    [SerializeField] RawImage RawGameOverTransition;
    [SerializeField] RawImage RawGameVictoryTransition;
    
    RawImage GameOverTrans;
    RawImage VictoryTrans;
    RawImage rondasImage;
    int rondasSeguidas;
    bool DesactivarPausa;

    int vidaJugador;
     bool JuegoEnPausa = false;
   [SerializeField] bool JugadorDerrotado;
    bool PlayerWonTheGame;
    [SerializeField ]bool AvisarDePeligro;
    
    // Start is called before the first frame update
    private void Awake()
    {
        
        DesactivarPausa = false;
        rondasSeguidas = gui_SO_data.rondas_gui;
        rondasImage = (RawImage)AvisoRondas.GetComponent<RawImage>();
        GameOverTrans = (RawImage)RawGameOverTransition.GetComponent<RawImage>();
        VictoryTrans = (RawImage)RawGameVictoryTransition.GetComponent<RawImage>();
        rondasImage.texture = (Texture)TexturaRondas[0];


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
        
        AvisoRondas.texture = (Texture)TexturaRondas[0];
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[0];
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[0];

        

        vidaJugador = PlayerScript.vida;

        CanvasPausa.enabled = false;
        VictoryScreen.enabled = false;
        CanvasTransition.enabled = false;
        CanvasGameOver.enabled = false;
        AvisoCoches.enabled = false;
        RawGameVictoryTransition.enabled = false;
        RawGameOverTransition.enabled = false;

    }
    private void Update()
    {
        PausarJuego();
        PantallaDeGameOver();
        AvisoDePeligroDeVehiculos();
        PasarRondas();
        PantallaDeVictoria();
    }

    // Update is called once per frame
    void PausarJuego()
    {
        if (DesactivarPausa != true && Input.GetKeyDown(KeyCode.Escape) && JuegoEnPausa == false && vidaJugador > 0)
        {
            CanvasPausa.enabled = true;
            JuegoEnPausa = true;
            Time.timeScale = 0;
            
        }
        else if (DesactivarPausa != true && Input.GetKeyDown(KeyCode.Escape) && JuegoEnPausa == true && vidaJugador > 0)
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
        JugadorDerrotado = gui_SO_data.PlayeLoses;
        if (JugadorDerrotado == true)
        {
            CanvasTransition.enabled = true;
            StartCoroutine(CoorutinaDerrota());
        }
    }
    void PantallaDeVictoria()
    {
        PlayerWonTheGame = gui_SO_data.PlayerWins;

        if (PlayerWonTheGame == true)
        {
            CanvasTransition.enabled = true;
            StartCoroutine(CoorutinaVictoria());


        }
    }
    public void AvisoDePeligroDeVehiculos()
    {
        AvisarDePeligro = gui_SO_data.AvisoDeCoche;
        if (AvisarDePeligro == true)
        {
            AvisoCoches.enabled = true;
        }
        else if  (AvisarDePeligro == false)
        {
            AvisoCoches.enabled = false;
        }
        
    }
    public void PasarRondas ()
    {
        rondasSeguidas = gui_SO_data.rondas_gui;
        if (rondasSeguidas == 0)
        {
            rondasImage.texture = (Texture)TexturaRondas[0];
        }
        else if (rondasSeguidas == 1)
        {
            rondasImage.texture = (Texture)TexturaRondas[0];
        }
        else if (rondasSeguidas == 2)
        {
            rondasImage.texture = (Texture)TexturaRondas[1];
        }
        else if (rondasSeguidas == 3)
        {
            rondasImage.texture = (Texture)TexturaRondas[2];
        }
    }
    
    IEnumerator CoorutinaVictoria()
    {
        DesactivarPausa = true;
        gui_SO_data.PlayerWins = false;
        RawGameVictoryTransition.enabled = true;

        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[0];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[1];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[2];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[3];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[4];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[5];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[6];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[7];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[8];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[9];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[10];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[11];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[12];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[13];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[14];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[15];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[16];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[17];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[18];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[19];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[20];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[21];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[22];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[23];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[24];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[25];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[26];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[27];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[28];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[29];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[30];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[31];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[32];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[33];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[34];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[35];
        yield return new WaitForSeconds(0.1f);
        RawGameVictoryTransition.texture = (Texture)TexturasVictoryScreen[36];
        yield return new WaitForSeconds(0.1f);
            
        CanvasTransition.enabled = false;
        VictoryScreen.enabled = true;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0;
        StopAllCoroutines();
    }
    IEnumerator CoorutinaDerrota()
    {
        DesactivarPausa = true;
        gui_SO_data.PlayeLoses = false;
        
        RawGameOverTransition.enabled = true;
        
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[0];
        yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[1];
        yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[2];
        yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[3];
        yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[4];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[5];
        yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[6];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[7];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[8];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[9];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[10];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[11];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[12];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[13];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[14];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[15];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[16];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[17];
         yield return new WaitForSeconds(0.1f);
        RawGameOverTransition.texture = (Texture)TexturasGameOverScreen[18];
         yield return new WaitForSeconds(0.1f);
        CanvasTransition.enabled = false;
        CanvasGameOver.enabled = true;
         yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0;
        StopAllCoroutines();





    }
}

