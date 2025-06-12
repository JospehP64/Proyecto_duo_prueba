using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControlVolumen : MonoBehaviour
{
    public static ControlVolumen ControlVolume_instance;
    


    [SerializeField] AudioMixer SM_audioMixer, SM_soundMixer;
    
    // Start is called before the first frame update

   
    
    public void ControlarVolumenDeMusica(float UnidadVolumen)
    {
        
        SM_audioMixer.SetFloat("VolumenDeMusica", math.log10(UnidadVolumen) * 20);
      

    }
    public void conrolarVolumenDeSonido(float UnidadSonido)
    {
        SM_soundMixer.SetFloat("VolumenDeSonido", math.log10(UnidadSonido) * 20);
    }
}
