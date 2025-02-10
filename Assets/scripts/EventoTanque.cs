using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoTanque : MonoBehaviour
{

    Enemigos enemigos;
    bool ObjetivoLocalizado = false;
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

    public void EventoAtaqueTanque()
    {
        AnimationEvent EnemigoAttackevent = new AnimationEvent();
        ObjetivoLocalizado = true;
        if (Physics.SphereCast(transform.position, 0.5f, new Vector3(3,3,3), out RaycastHit Attackhit, 3f))//CORREGIR. TEN EN CUENTA QUE, SI ESTA CERCA EL ENEMIGO DEL JUGADOR, NO DEBE MOVERSE, SINO ATACAR
        {

            if (Attackhit.transform.gameObject.CompareTag("Player"))
            {

                Attackhit.collider.GetComponent<MovimientoPersonaje>().JugadorRecibeAtaque();

            }

        }
        


    }

    private void OnTriggerEnter(Collider objetivo)
    {
        if (objetivo.transform.gameObject.CompareTag("Player"))
        {
            objetivo.GetComponent<MovimientoPersonaje>().JugadorRecibeAtaque();
            ObjetivoLocalizado &= false;
        }
    }

}
