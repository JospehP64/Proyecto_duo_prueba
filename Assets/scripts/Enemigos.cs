using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemigos : MonoBehaviour
{
    bool caminar;
    bool atacar;

    [SerializeField] string variante;
    
    [SerializeField] GameObject EnemySprite;

    [SerializeField] Animator EnemyAnimator;
    public float RadioDeAtaque = 0.75f;
    [SerializeField] public float RadioMaximoDeAtaque = 1f;

    [SerializeField]PuntosDeSpawn Spawnpoints;

    [SerializeField] Personajes_SO Char_SO;

    GameObject Posicionjugador;
    [SerializeField]Enemigos_SO Enem_SO;
    [SerializeField] GameObject Drop_enemigo;
    Rigidbody rb;
    
    [SerializeField]float velocidadEnemigo = 0.5f;

   
    float angulo;
    Vector3 movimiento;
    Vector3 direccion;
    float Distancia;
    float DireccionMagnitud;
    [SerializeField]float RadioDeAlcance = 0.1f;
    [SerializeField]float RadioDeAlcanceMaximo = 5f;
    public int resistencia;
    
    


    // Start is called before the first frame update
    void Start()
    {
        

       Spawnpoints = GetComponent<PuntosDeSpawn>();
        Posicionjugador = GameObject.FindGameObjectWithTag("Player");
        

        resistencia = Enem_SO.resistencia;

        
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        enemigo_detecta_jugador();

        
        if (resistencia <= 0)
        {
            
            PuntosDeSpawn.totalDeEnemigos--;
            Instantiate(Drop_enemigo, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            

        }

    }

    private void enemigo_detecta_jugador()
    {
        direccion = Posicionjugador.transform.position - transform.position;
        if (Physics.SphereCast(transform.position, RadioDeAlcance, direccion, out RaycastHit EnemigoCollHit, RadioDeAlcanceMaximo))
        {
            caminar = true;
        }
        else
        {
            caminar=false;
        }
        Debug.DrawRay(transform.position, transform.forward, Color.red);




        angulo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg;



        movimiento = direccion;

        if (variante == "corredor")
        {

            if (Physics.SphereCast(transform.position, RadioDeAtaque, direccion, out RaycastHit Attackhit, RadioMaximoDeAtaque))//CORREGIR. TEN EN CUENTA QUE, SI ESTA CERCA EL ENEMIGO DEL JUGADOR, NO DEBE MOVERSE, SINO ATACAR
            {
                
                
                 EnemyAnimator.SetTrigger("ataque_corredor");

                
            }
            else
            {

            }
        }
        else if (variante == "tanque")
        {

        }
        else if (variante == "mago")
        {

        }
    }

    private void FixedUpdate()
    {
        movimientoEnemigo();

    }

    void movimientoEnemigo()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (caminar == true)
        {
            if (variante == "corredor")
            {
                EnemyAnimator.SetBool("caminar_corredor", true);
            }
            
            rb.MovePosition(transform.position + (direccion * velocidadEnemigo * Time.deltaTime));

            if (variante == "tanque")
            {
                EnemyAnimator.SetBool("tanque_walk", true);
            }

            rb.MovePosition(transform.position + (direccion * velocidadEnemigo * Time.deltaTime));
        }
        else 
        {
            if (variante == "corredor")
            {
                EnemyAnimator.SetBool("caminar_corredor", false);
            }

            if (variante == "tanque")
            {
                EnemyAnimator.SetBool("tanque_walk", false);
            }


        }
        //Vector3.Distance(Posicionjugador.position, this.transform.position) < 1

    }

    public void ataqueDeEnemigo()
    {
        //ANTIGUO METODO. CORREGIR
       
        
    }

    public void enemigo_Recibe_Ataque()//Cuando es llamado por "Eventos_jugador", el enemigo recibe daño
    {
        resistencia = resistencia - Char_SO.ataque_personajes;
        
    }
    
}
