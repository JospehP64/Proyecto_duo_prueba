using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DATOS_MUSICA_y_SONIDO", menuName = "DATOS_MUSICA_y_SONIDO")]
public class MusicaYSonido_SO : ScriptableObject
{
    public AudioClip[] Musica;
    public AudioSource[] sonido;
    public float Volumen_So;


}
