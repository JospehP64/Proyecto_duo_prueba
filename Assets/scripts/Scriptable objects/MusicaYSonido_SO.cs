using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "DATOS_MUSICA_y_SONIDO", menuName = "DATOS_MUSICA_y_SONIDO")]
public class MusicaYSonido_SO : ScriptableObject
{
    public AudioClip[] Musica;
    public float Volumen;
    

    private void Awake()
    {
        
    }
    
}
