using System.Collections;
using System.Collections.Generic;
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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion = Posicionjugador.position - transform.position;
        angulo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg;
        
        movimiento = direccion;
        
    }
    private void FixedUpdate()
    {
        movimientoEnemigo();
    }

    void movimientoEnemigo()
    {
        if(angulo >= 0.10f)
        {
            rb.MovePosition(transform.position + (direccion * velocidadEnemigo * Time.deltaTime));
        }
        else if(angulo <= 0.5f)
        {

        }
        
    }
}
