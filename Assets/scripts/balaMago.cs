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
  float tiempodeBala = 0;//variable para el tiempo de vida de la bala


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
        
    }
     private void OnTriggerEnter(Collider collide) 
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

