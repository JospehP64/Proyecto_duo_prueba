using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField]Transform Posicionjugador;
    Enemigos_SO Enem_SO;
    Rigidbody rb;
    
    float velocidadEnemigo = 0.5f;

    int vida_enemigo;
    float angulo;
    Vector3 movimiento;
    Vector3 direccion;
    float Distancia;
    float DireccionMagnitud;
    float RadioDeAlcance = 0.1f;
    float RadioDeAlcanceMaximo = 1f;
    [SerializeField] int resistencia;
    
    


    // Start is called before the first frame update
    void Start()
    {
        
        
        rb = GetComponent<Rigidbody>();
         
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento_de_enemigo();

    }

    private void Movimiento_de_enemigo()
    {
        direccion = Posicionjugador.position - transform.position;
        Physics.SphereCast(transform.position, RadioDeAlcance, direccion, out RaycastHit EnemigoCollHit, 10);
        Debug.DrawRay(transform.position, transform.forward, Color.red);




        angulo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg;



        movimiento = direccion;
    }

    private void FixedUpdate()
    {
        movimientoEnemigo();
    }

    void movimientoEnemigo()
    {
         
        if(Physics.SphereCast(transform.position, RadioDeAlcance, direccion, out RaycastHit EnemigoCollHit, 5))
        {
            rb.MovePosition(transform.position + (direccion * velocidadEnemigo * Time.deltaTime));
        }
        else
        {
            
        }
        //Vector3.Distance(Posicionjugador.position, this.transform.position) < 1

    }
    
}
