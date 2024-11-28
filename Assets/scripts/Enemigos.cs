using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField]PuntosDeSpawn Spawnpoints;

    [SerializeField] Personajes_SO Char_SO;

    GameObject Posicionjugador;
    [SerializeField]Enemigos_SO Enem_SO;
    Rigidbody rb;
    
    float velocidadEnemigo = 0.5f;

   
    float angulo;
    Vector3 movimiento;
    Vector3 direccion;
    float Distancia;
    float DireccionMagnitud;
    float RadioDeAlcance = 0.1f;
    float RadioDeAlcanceMaximo = 1f;
    public int resistencia;
    
    


    // Start is called before the first frame update
    void Start()
    {

        Posicionjugador = GameObject.FindGameObjectWithTag("Player");
        

        resistencia = Enem_SO.resistencia;

        
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento_de_enemigo();

        
        if (resistencia <= 0)
        {
            PuntosDeSpawn.totalDeEnemigos--;
            Destroy(gameObject);

        }

    }

    private void Movimiento_de_enemigo()
    {
        direccion = Posicionjugador.transform.position - transform.position;
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

    public void enemigo_Recibe_Ataque()//Cuando es llamado por "Eventos_jugador", el enemigo recibe daño
    {
        resistencia = resistencia - Char_SO.ataque_personajes;
        
    }
    
}
