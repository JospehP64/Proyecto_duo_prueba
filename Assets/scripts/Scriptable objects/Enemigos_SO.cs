using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Datos_Enemigos", menuName = "Datos_Enemigos")]
public class Enemigos_SO : ScriptableObject
{
    public int resistencia;
    [SerializeField] float velocidad_enemigos;
    [SerializeField] int ataque_enemigos;
    //[SerializeField] int defensa;//Por ahora, solo se usará la resistencia, que es lo mismo que la vida
}
