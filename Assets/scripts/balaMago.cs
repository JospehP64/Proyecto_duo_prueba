using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaMago : MonoBehaviour
{


    [SerializeField] AudioClip SoundsArray;
    [SerializeField] AudioSource bulletSounds;
    Rigidbody rb;
 [SerializeField] Datos_Balas Balas_SO;//Scriptable Object para las balas o proyectiles
 [SerializeField]float VelocidadDeBalasDeMago;// velocidad de esta bala   
  GameObject PlayerTargetPosition;
 Vector3 direccionBala;
  float tiempodeBala = 0;//variable para el tiempo de vida de la bala


    // Start is called before the first frame update

    void Start()
    {
        if (Time.timeScale != 0)
        {
            bulletSounds.PlayOneShot(SoundsArray);
        }
        
        PlayerTargetPosition = GameObject.FindGameObjectWithTag("Player");
       

        rb = gameObject.GetComponent<Rigidbody>();
        
        direccionBala = PlayerTargetPosition.transform.position - transform.position;
        
        tiempodeBala = Balas_SO.tiempoDeVida;
    
         
    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {
       
        
        MovimientoDeBala();
    }
    void MovimientoDeBala()
    {
        if (Time.timeScale == 0)
        {
            bulletSounds.Stop();
        }
        direccionBala = direccionBala.normalized;
        rb.MovePosition(transform.position + (direccionBala * VelocidadDeBalasDeMago * Time.fixedDeltaTime));
        Destroy(gameObject, 5);

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

