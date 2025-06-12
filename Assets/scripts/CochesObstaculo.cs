using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CochesObstaculo : MonoBehaviour
{

    [SerializeField] AudioClip SoundsArray;
    [SerializeField] AudioSource ObstacleSounds;
    Rigidbody rb;
    [SerializeField] Datos_Balas Balas_SO;//Scriptable Object para las balas o proyectiles
    [SerializeField] float VelocidadDeCoches;// velocidad de esta bala   
    GameObject PlayerTargetPosition;
    Vector3 direccionCoche;
    [SerializeField] string TagDeObjetivo;
    float tiempodeBala = 0;//variable para el tiempo de vida de la bala
    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale != 0)
        {
            ObstacleSounds.PlayOneShot(SoundsArray);
        }

        PlayerTargetPosition = GameObject.FindGameObjectWithTag(TagDeObjetivo);


        rb = gameObject.GetComponent<Rigidbody>();

        direccionCoche = PlayerTargetPosition.transform.position - transform.position;
        tiempodeBala = Balas_SO.tiempoDeVida;
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovimientoDeCoche();
    }
    
    void MovimientoDeCoche()
    {
        if (Time.timeScale == 0)
        {
            ObstacleSounds.Stop();
        }
        direccionCoche = direccionCoche.normalized;
        rb.MovePosition(transform.position + (direccionCoche * VelocidadDeCoches * Time.fixedDeltaTime));
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
