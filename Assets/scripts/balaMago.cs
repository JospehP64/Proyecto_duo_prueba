using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class balaMago : MonoBehaviour
{
    Rigidbody rb;
 [SerializeField] Datos_Balas Balas_SO;//Scriptable Object para las balas o proyectiles
 [SerializeField]float VelocidadDeBalasDeMago;// velocidad de esta bala   
  GameObject PlayerTargetPosition;
 Vector3 direccionBala;
 [SerializeField]float tiempodeBala;//variable para el tiempo de vida de la bala


    // Start is called before the first frame update

    void Start()
    {
       PlayerTargetPosition = GameObject.FindGameObjectWithTag("Player");
       VelocidadDeBalasDeMago = Balas_SO.velocidadDeBala;

        rb = gameObject.GetComponent<Rigidbody>();
        VelocidadDeBalasDeMago = Balas_SO.velocidadDeBala;
        direccionBala = PlayerTargetPosition.transform.position - transform.position;
        tiempodeBala = Balas_SO.tiempoDeVida;
    
         
    }

    // Update is called once per frame
    void Update()
    {
     MovimientoDeBala();

    }

    void MovimientoDeBala()
    {
        rb.MovePosition(transform.position + (direccionBala * VelocidadDeBalasDeMago * Time.deltaTime));
        for (float TV = 0; TV < 20; TV++) 
        {
            if (TV >= 20) 
            {
                Destroy(gameObject);
            }
        }
    }
     private void OnTriggerEnter(Collider collide) 
     {
        if (collide.gameObject.CompareTag("invisible_wall")) 
        {
            
            Destroy(gameObject);

        }
        if (collide.gameObject.CompareTag("Player")) 
        {
            collide.GetComponent<MovimientoPersonaje>().JugadorRecibeAtaque();
            Destroy(gameObject);
        }
     }
}

