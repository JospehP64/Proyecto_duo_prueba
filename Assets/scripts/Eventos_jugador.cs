using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Eventos_jugador : MonoBehaviour
{
    PuntosDeSpawn SpawnPoints;// Coge la variable Spawnpoints.totalDeEnemigos para que, al destruir a un enemigo, se reste el numero de enemigos en escena y, si hay menos del total, se spawneen
    Enemigos Enemy;
    [SerializeField] Personajes_SO Char_SO;
    //[SerializeField]int Enemy_life;
    GameObject enemigos_ajenos;
    public int player_damage;
    [SerializeField]MovimientoPersonaje MovPersonaje;
    [SerializeField] RawImage rawCorazon;
    [SerializeField] RawImage rawCorazon_2;
    [SerializeField] RawImage rawCorazon_3;
    [SerializeField] Texture[] TexturaCorazon;
    RawImage corazon01;
    RawImage corazon03;
    RawImage corazon02;
    int vidaGUI;
    private void Start()
    {

        
        //Enemy = GameObject.FindAnyObjectByType<Enemigos>(); //Para tomar el valor del codigo del enemigo //IMPORTANTE
        


        //player_damage = Char_SO.ataque_personajes;

        vidaGUI = MovPersonaje.vida;
        corazon01 = (RawImage)rawCorazon.GetComponent<RawImage>();
        corazon02 = (RawImage)rawCorazon_2.GetComponent<RawImage>();
        corazon03 = (RawImage)rawCorazon_3.GetComponent<RawImage>();

        

        corazon01.texture = (Texture)TexturaCorazon[0];
        corazon02.texture = (Texture)TexturaCorazon[0];
        corazon03.texture = (Texture)TexturaCorazon[0];

        
    }
    private void Update()
    {
        

        vidaGUI =  MovPersonaje.vida;
        if (vidaGUI >= 3)
        {
            corazon01.texture = (Texture)TexturaCorazon[0];
            corazon02.texture = (Texture)TexturaCorazon[0];
            corazon03.texture = (Texture)TexturaCorazon[0];
        }
        else if (vidaGUI == 2)
        {
            corazon01.texture = (Texture)TexturaCorazon[1];
            corazon02.texture = (Texture)TexturaCorazon[0];
            corazon03.texture = (Texture)TexturaCorazon[0];
        }
        else if (vidaGUI == 1)
        {
            corazon01.texture = (Texture)TexturaCorazon[1];
            corazon02.texture = (Texture)TexturaCorazon[1];
            corazon03.texture = (Texture)TexturaCorazon[0];
        }
        else if (vidaGUI <= 0)
        {
            corazon01.texture = (Texture)TexturaCorazon[1];
            corazon02.texture = (Texture)TexturaCorazon[1];
            corazon03.texture = (Texture)TexturaCorazon[1];
        }
    }

    public void player_melee_attack()
    {
        


        AnimationEvent attackevent = new AnimationEvent();

        
        if (Input.GetMouseButton(0))
        {
            if (Physics.SphereCast(transform.position, 0.75f, transform.right, out RaycastHit playerhit, 3f))
            {
                if (playerhit.transform.gameObject.CompareTag("enemigo"))
                {

                    // Destroy(playerhit.transform.gameObject);

                    Enemy.resistencia = Enemy.resistencia - 1;
                }
                    
            }
        }
       

        


    }

}
