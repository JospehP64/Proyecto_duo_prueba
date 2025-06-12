using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_De_Area : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collide)
    {

        if (collide.gameObject.CompareTag("Player") && gameObject.CompareTag("attack_area"))
        {
            collide.GetComponent<MovimientoPersonaje>().JugadorRecibeAtaque();
            
        }
        else if (collide.gameObject.CompareTag("Player") && gameObject.CompareTag("ranged_attack_area"))
        {
            collide.GetComponent<MovimientoPersonaje>().JugadorRecibeAtaque();

        }

    }
    private void OnTriggerStay(Collider collide)
    {
        if (collide.gameObject.CompareTag("Player") && gameObject.CompareTag("ranged_attack_area"))
        {
            collide.GetComponent<MovimientoPersonaje>().JugadorRecibeAtaque();
   
        }
        
    }
}
