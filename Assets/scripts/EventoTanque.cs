using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoTanque : MonoBehaviour
{
    [SerializeField] AudioClip SoundsArray;
    [SerializeField] AudioSource EnemySounds;
    [SerializeField]Enemigos enemigos;
    [SerializeField] Animator TanqueAnimator;
    GameObject Posicionjugador;
    float RangoDeAtaqueminimo, RangoDeAtaqueMaximo;
    
    //Enemigos enemigos;
    // Start is called before the first frame update
    private void Awake()
    {
        Posicionjugador = GameObject.FindGameObjectWithTag("Player");


    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            EnemySounds.Stop();
        }

    }

    public void EventoAtaqueTanque()
    {
        AnimationEvent EnemigoAttackevent = new AnimationEvent();
        
        if (Physics.SphereCast(transform.position, RangoDeAtaqueminimo, transform.right, out RaycastHit Attackhit, RangoDeAtaqueMaximo))//CORREGIR. TEN EN CUENTA QUE, SI ESTA CERCA EL ENEMIGO DEL JUGADOR, NO DEBE MOVERSE, SINO ATACAR
        {
            

            if (Attackhit.transform.gameObject.CompareTag("Player"))
            {
                
                Attackhit.collider.GetComponent<MovimientoPersonaje>().JugadorRecibeAtaque();
                

            }
            

        }
        else
        {

        }
        


    }

    public void RugidoTanque()
    {
        AnimationEvent TanqueRoarEvent = new AnimationEvent();
        if (Time.timeScale != 0)
        {
            EnemySounds.PlayOneShot(SoundsArray);
        }
        

    }

}
