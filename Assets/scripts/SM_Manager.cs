using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SM_Manager : MonoBehaviour
{


    public AudioSource AudioManager;

    [SerializeField] AudioClip[] AudioClipManager;
    [SerializeField] int EscenaActual;
    [SerializeField] bool MuteMusicAndSound;
    [SerializeField] GUI_SO MusicAndSoundManagerGUI;
    



    public SM_Manager Sm_instance;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.mute = false;
        AudioManager = GetComponent<AudioSource>();
        
        EscenaActual = SceneManager.GetActiveScene().buildIndex;
        


        if (EscenaActual != 1)
        {

            
            AudioManager.PlayOneShot(AudioClipManager[0]);

        }
        
        else 
        {
           
            
            AudioManager.PlayOneShot(AudioClipManager[3]);
        }



         
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (EscenaActual == 1 && MusicAndSoundManagerGUI.PlayerWins == true && MusicAndSoundManagerGUI.PlayeLoses == false)
        {


            AudioManager.Stop();
            AudioManager.PlayOneShot(AudioClipManager[1]);

        }
        else if (EscenaActual == 1 && MusicAndSoundManagerGUI.PlayerWins == false && MusicAndSoundManagerGUI.PlayeLoses == true)
        {
            AudioManager.Stop();
            AudioManager.PlayOneShot(AudioClipManager[2]);

        }
    }
    
    public void MuteVolumen()
    {
        if (AudioManager.mute == true)
        {
            
            AudioManager.mute = false;
        }
        else
        {
            AudioManager.mute = true;
            
        }
        
    }
}
