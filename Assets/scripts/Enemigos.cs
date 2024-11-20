using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField]Transform Posicionjugador;
    Rigidbody rb;
    float vidaEnemigo;//es como la resistencia del enemigo
    float velocidadEnemigo = 0.5f;
    float ataqueEnemigo;
    float rangoDeAlcance;
    float angulo;
    Vector3 movimiento;
    Vector3 direccion;
    float Distancia;
    float DireccionMagnitud;
    float RadioDeAlcance = 0.1f;
    float RadioDeAlcanceMaximo = 1f;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
         
    }

    // Update is called once per frame
    void Update()
    {
        direccion = Posicionjugador.position - transform.position;
        Physics.SphereCast(transform.position, RadioDeAlcance, direccion, out RaycastHit EnemigoCollHit, 10);
        Debug.DrawRay(transform.position,transform.forward, Color.red);
        
        
        

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
