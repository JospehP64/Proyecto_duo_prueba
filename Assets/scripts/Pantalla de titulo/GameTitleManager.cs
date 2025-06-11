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
    public float VolumeUnit;
    [SerializeField] Scrollbar MusicScrollBar;
    public static GameTitleManager gametitleInstance;
    [SerializeField]GUI_SO MusicAndSoundManagerGUI;
    PuntosDeSpawn SpawnpointScript;
    int rondaInicial;
    [SerializeField]int EscenaActual;
    [SerializeField] bool MuteMusicAndSound;
    [SerializeField]AudioSource AudioManager;
    [SerializeField]AudioClip[] AudioClipManager;
    [SerializeField] MusicaYSonido_SO MusicaYSonido_SO;//NO CONFUNDIR CON MUSICAndSpundManagerGUI
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
        
        
        AudioManager = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
        
        AudioManager.mute = MuteMusicAndSound;
        EscenaActual = SceneManager.GetActiveScene().buildIndex;
        if (EscenaActual != 1)
        {
            
            
            
            AudioManager.PlayOneShot(AudioClipManager[0]);

        }
        else if (EscenaActual == 1 && MusicAndSoundManagerGUI.PlayerWins == true  && MusicAndSoundManagerGUI.PlayeLoses == false)
        {



            AudioManager.PlayOneShot(AudioClipManager[1]);

        }
        else if (EscenaActual == 1 && MusicAndSoundManagerGUI.PlayerWins == false && MusicAndSoundManagerGUI.PlayeLoses == true)
        {
           
            
            AudioManager.PlayOneShot(AudioClipManager[2]);

        }
        else if (EscenaActual == 1 && MusicAndSoundManagerGUI.PlayerWins == false  && MusicAndSoundManagerGUI.PlayeLoses == false)
        {
            
            
            AudioManager.PlayOneShot(AudioClipManager[3]);
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
    public void ComoJugar()
    {

        SceneManager.LoadScene(3);

    }
    public void MuteMusicAndAudio()
    {
        
        if (MuteMusicAndSound == true)
        {
            MuteMusicAndSound = false;
        }
        else
        {
            MuteMusicAndSound = true;

        }
    }
    
}
