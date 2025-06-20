using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Eventos_jugador : MonoBehaviour
{
    [SerializeField] AudioClip[] SoundsArray;
    [SerializeField] AudioSource characterSounds;
    MovimientoPersonaje PlayerMovementsScript;
    
    PuntosDeSpawn SpawnPoints;// Coge la variable Spawnpoints.totalDeEnemigos para que, al destruir a un enemigo, se reste el numero de enemigos en escena y, si hay menos del total, se spawneen
    Enemigos Enemy;
    [SerializeField] Personajes_SO Char_SO;
    //[SerializeField]int Enemy_life;
    GameObject enemigos_ajenos;
    public int player_damage;
    [SerializeField] MovimientoPersonaje MovPersonaje;
    [SerializeField] RawImage rawCorazon;
    [SerializeField] RawImage rawCorazon_2;
    [SerializeField] RawImage rawCorazon_3;
    public RawImage playerFace_icon;
    [SerializeField] Texture[] TexturaCorazon;
    public Texture[] Rostro_jugador;

    public RawImage PlayFace;
    RawImage corazon01;
    RawImage corazon03;
    RawImage corazon02;
    int vidaGUI;
    bool PlayerGetsHurt;

    
    private void Start()
    {
        characterSounds = GetComponent<AudioSource>();

        // Enemy = GameObject.FindAnyObjectByType<Enemigos>(); //Para tomar el valor del codigo del enemigo //IMPORTANTE



        //player_damage = Char_SO.ataque_personajes;

        vidaGUI = MovPersonaje.vida;
        PlayFace = (RawImage)playerFace_icon.GetComponent<RawImage>();
        corazon01 = (RawImage)rawCorazon.GetComponent<RawImage>();
        corazon02 = (RawImage)rawCorazon_2.GetComponent<RawImage>();
        corazon03 = (RawImage)rawCorazon_3.GetComponent<RawImage>();



        corazon01.texture = (Texture)TexturaCorazon[0];
        corazon02.texture = (Texture)TexturaCorazon[0];
        corazon03.texture = (Texture)TexturaCorazon[0];
        PlayFace.texture = (Texture)Rostro_jugador[0];

    }
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            characterSounds.Stop();
        }

        vidaGUI = MovPersonaje.vida;
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

    public void PlayerRecievesAttack()
    {
        
            PlayFace.texture = (Texture)Rostro_jugador[2];
        
        
    }
    public void player_melee_attack()
    {
        


        AnimationEvent attackevent = new AnimationEvent();

        
        if (Input.GetMouseButton(0))
        {
            PlayFace.texture = (Texture)Rostro_jugador[1];
            if (Physics.SphereCast(transform.position, 0.75f, transform.right, out RaycastHit playerhit, 3f))
            {
                if (playerhit.transform.gameObject.CompareTag("enemigo"))
                {

                    
                    playerhit.collider.gameObject.GetComponent<Enemigos>().enemigo_Recibe_Ataque();//Llama al metodo "Enemig_Recibe_Ataque" del script "Enemigos"
                }
                else if (playerhit.transform.gameObject.CompareTag("boss"))
                {


                    playerhit.collider.gameObject.GetComponent<Boss_Script>().bossRecibeAtaque();//Llama al metodo "Enemig_Recibe_Ataque" del script "Enemigos"
                }


            }
        }
        else if (!Input.GetMouseButton(0))
        {
            PlayFace.texture = (Texture)Rostro_jugador[0];
        }
       

        


    }
    public void SonidoSalto()
    {
        characterSounds.PlayOneShot(SoundsArray[3]);
    }
    public void Sonidocaminar()
    {
        characterSounds.PlayOneShot(SoundsArray[0]);
    }
    public void SonidoGolpear()
    {
        characterSounds.PlayOneShot(SoundsArray[2]);
    }
    public void SonidoRecibirAtaque()
    {
        characterSounds.PlayOneShot(SoundsArray[1]);
    }
}
