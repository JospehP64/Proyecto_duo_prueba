using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class EventoMago : MonoBehaviour
{
    [SerializeField] AudioClip SoundsArray;
    [SerializeField] AudioSource EnemySounds;
    [SerializeField] Animator MagoAnimator;
    
    GameObject Posicionjugador;
    Vector3 direccion;
    [SerializeField] GameObject BalaASpawnear;
    Enemigos code_enemigo;
    float radioMaximoMago, radioMinMago;
    Vector3 direccionDeAtaque;
    Enemigos enemigos;


    // Start is called before the first frame update
    void Start()
    {
        EnemySounds = GetComponent<AudioSource>();
        MagoAnimator = GetComponent<Animator>();
        code_enemigo = GameObject.FindAnyObjectByType<Enemigos>();
        

        radioMinMago = code_enemigo.RadioDeAtaque;
        radioMaximoMago = code_enemigo.RadioMaximoDeAtaque;
        Posicionjugador = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        //if (Physics.SphereCast(transform.position, radioMinMago, transform.right, out RaycastHit Attackhit, radioMaximoMago) && MagoAnimator.GetBool("Mago_attacking"))
        //{
        //    
        //}
        //else
        //{
        //    StopAllCoroutines();
        //    MagoAnimator.SetBool("MagoAttackCharge", false);
        //    MagoAnimator.SetBool("MagoAttackCharge", false);
        //}
        if (Time.timeScale == 0)
        {
            EnemySounds.Stop();
        }

        direccionDeAtaque = Posicionjugador.transform.position - transform.position;
        

    }


    private IEnumerator DispararDentroDeAlcance()
    {

        if (MagoAnimator.GetBool("Mago_attacking") == true)
        {
            if (Time.timeScale != 0)
            {
                EnemySounds.PlayOneShot(SoundsArray);
            }
            
            Instantiate(BalaASpawnear, transform.position, quaternion.identity);
            yield return new WaitForSeconds(1);
            MagoAnimator.SetBool("Mago_attacking", false);
            yield return new WaitForSeconds(1);
            StopAllCoroutines();
        }
            

        //if (Physics.SphereCast(transform.position, RadioDeAtaqueAdistancia, direccion, out RaycastHit Attackhit, RadioDeAtaqueADistanciaMaximo))
        //{
        //    StartCoroutine(InvocarBalas());
        //    direccion = Posicionjugador.transform.position - transform.position;



    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
        }
    }

    public void CargaDeAtaqueDeMagoEnemigo()
    {
        if (MagoAnimator.GetBool("MagoAttackCharge") == true)
        {
            MagoAnimator.SetBool("MagoAttackCharge", false);
            MagoAnimator.SetBool("Mago_attacking", true);
        }
        
      
        //IEnumerator InvocarBalas() 
        //{
        //    while (Physics.SphereCast(transform.position, RadioDeAtaqueAdistancia, direccion, out RaycastHit Attackhit, RadioDeAtaqueADistanciaMaximo))
        //    {
        //        yield return new WaitForSeconds(1);
        //        yield return new WaitForSeconds(3);
        //    }



        //}
    }
}
