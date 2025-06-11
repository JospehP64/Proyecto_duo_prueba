using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNocivo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay(Collider collide )
    {
        if (collide.gameObject.CompareTag("Player") && gameObject.CompareTag("bala"))
        {
            collide.GetComponent<MovimientoPersonaje>().JugadorRecibeAtaque();
            Destroy(gameObject);
        }
        else if (collide.gameObject.CompareTag("Player") && (gameObject.CompareTag("coche")))
        {
            collide.GetComponent<MovimientoPersonaje>().JugadorRecibeAtaque();


        }
    }
}
