using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
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
        gameObject.GetComponent<MovimientoPersonaje>().JugadorRecibeAtaque();
    }
}
