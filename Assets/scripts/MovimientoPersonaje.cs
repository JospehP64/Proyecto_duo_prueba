using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

using Unity.Burst.CompilerServices;
using System.Security.Cryptography;

public class MovimientoPersonaje : MonoBehaviour
{
    public bool PlayerIsDefeated;
    [SerializeField]GameObject sprite_personaje;
    Enemigos enemy;
   [SerializeField] Personajes_SO valor_personajes;
   [SerializeField]Animator animatorPlayer;
    public int vida;
    int energia;
    float velocidad;
    [SerializeField] TextMeshProUGUI TextVida;
    [SerializeField] TextMeshProUGUI TextEnergia;
    Vector3 salto = new Vector3(0, 2f, 0);
    public bool PlayerTakesDamage;
   
    
    


    Rigidbody rb;

    // Start is called before the first frame update
    
    void Start()
    {
        PlayerTakesDamage = false;
        PlayerIsDefeated = false;
        sprite_personaje.transform.eulerAngles = new Vector3(0, 180, 0);
        vida = valor_personajes.vida_personajes;
        energia =  valor_personajes.energia_personajes;
        rb = GetComponent<Rigidbody>();
        //animatorPlayer = GetComponent<Animator>.GetAnimatorPlayer();
    }

    // Update is called once per frame
    void Update()
    {



        TextVida.SetText("Vida: " + vida);
        TextEnergia.SetText("energ�a: " + energia);
        //
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            animatorPlayer.SetTrigger("attack");

        }

        Movimiento(h, v);

        Salto();

    }

    private void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, new Vector3(0, -0.1f, 0), 1, LayerMask.GetMask("suelo")))
        {
            
            
                rb.AddForce(salto * 5, ForceMode.Impulse);
            animatorPlayer.SetBool("jump", true);
            Debug.Log("has saltado");

        }
        else
        {
            if (Physics.Raycast(transform.position, new Vector3(0, -0.1f, 0), 1, LayerMask.GetMask("suelo"))|| Physics.Raycast(transform.position, new Vector3(0, -0.1f, 0), 1, LayerMask.GetMask("enemigo")))
            {
                animatorPlayer.SetBool("on air", false);
                animatorPlayer.SetBool("jump", false);

            }
            else
            {
                animatorPlayer.SetBool("on air", true);
                animatorPlayer.SetBool("jump", false);
                Debug.Log("est�s en el aire");
            }
        }
    }

    private void Movimiento(float h, float v)
    {
        Vector3 movimiento = new Vector3(h, 0f, v) * velocidad * Time.deltaTime; 
        transform.Translate(movimiento);
        if (h > 0 || h > 0  && v > 0 || h > 0 && v < 0 )
        {
            animatorPlayer.SetBool("walking", true);
            sprite_personaje.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (h < 0 || h < 0 && v > 0 || h < 0 && v < 0)
        {
            animatorPlayer.SetBool("walking", true);
            sprite_personaje.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (v > 0 || v < 0 )
        {
            animatorPlayer.SetBool("walking", true);
        }
        else
        {
            animatorPlayer.SetBool("walking", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidad = 8;
        }
        else
        {
            velocidad = 3;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       //if (collision.gameObject.CompareTag("enemigo"))
       //{
       //    vida--;
       //    animatorPlayer.SetTrigger("recieve damage");
       //}
       //if (vida <= 0)
       //{
       //    Destroy(gameObject);
       //    
       //
       //}
        
    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (vida < 3 && vida > 0)
        {
            if (trigger.gameObject.CompareTag("curable"))
            {
                vida++;
                Destroy(trigger.gameObject);
            }
            
        }
        if (trigger.gameObject.CompareTag("vacio")) 
        {
            transform.position = new Vector3(-3, 4, -5);

        }
        
        
    }

    public void JugadorRecibeAtaque()
    {
        
        vida--;
        animatorPlayer.SetTrigger("recieve damage");
        animatorPlayer.GetComponent<Eventos_jugador>().PlayerRecievesAttack();
        if (vida <= 0)
        {
            PlayerIsDefeated = true;
            Destroy(gameObject);
        }
        
    }


}
