using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    

    [SerializeField] GameObject EnemySprite;

    [SerializeField] Animator EnemyAnimator;

    [SerializeField] bool[] Variantes;//Variante 01: corredor; variante 02: mago; variante 03; tanque
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
        Physics.SphereCast(transform.position, RadioDeAlcance, direccion, out RaycastHit EnemigoCollHit, RadioDeAlcanceMaximo);
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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Physics.SphereCast(transform.position, RadioDeAlcance, direccion, out RaycastHit EnemigoCollHit, RadioDeAlcanceMaximo))
        {


            

            if ( Posicionjugador.transform.position.x > 0 || Posicionjugador.transform.position.x> 0 && Posicionjugador.transform.position.y > 0 || Posicionjugador.transform.position.x > 0 && Posicionjugador.transform.position.y < 0)
            {
                EnemyAnimator.SetBool("caminar_corredor", true);
                EnemySprite.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (transform.position.x < 0 || Posicionjugador.transform.position.x < 0 && Posicionjugador.transform.position.y > 0 || Posicionjugador.transform.position.x < 0 && Posicionjugador.transform.position.y < 0)
            {
                EnemyAnimator.SetBool("caminar_corredor", true);
                EnemySprite.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (Posicionjugador.transform.position.x > 0 || Posicionjugador.transform.position.y < 0)
            {
                EnemyAnimator.SetBool("caminar_corredor", true);
            }

            rb.MovePosition(transform.position + (direccion * velocidadEnemigo * Time.deltaTime));
        }
        else
        {
            EnemyAnimator.SetBool("caminar_corredor", false);
        }
        //Vector3.Distance(Posicionjugador.position, this.transform.position) < 1

    }

    public void enemigo_Recibe_Ataque()//Cuando es llamado por "Eventos_jugador", el enemigo recibe daño
    {
        resistencia = resistencia - Char_SO.ataque_personajes;
        
    }
    
}
