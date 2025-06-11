using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosEnemigo : MonoBehaviour
{
    
    Enemigos enemigos;

    GameObject Posicionjugador;
    float RangoDeAtaqueTomado = 0;
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
        
    }

    public void EventoAtaqueEnemigo()
    {
        AnimationEvent EnemigoAttackevent = new AnimationEvent();
        if (Physics.SphereCast(transform.position, 0.5f, transform.right, out RaycastHit Attackhit, 0.75f))//CORREGIR. TEN EN CUENTA QUE, SI ESTA CERCA EL ENEMIGO DEL JUGADOR, NO DEBE MOVERSE, SINO ATACAR
        {

            if (Attackhit.transform.gameObject.CompareTag("Player"))
            {
                
                Attackhit.collider.GetComponent<MovimientoPersonaje>().JugadorRecibeAtaque();

            }

        }
        
        
    }
}
