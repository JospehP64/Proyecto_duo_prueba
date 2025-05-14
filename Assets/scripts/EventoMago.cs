using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class EventoMago : MonoBehaviour
{
    [SerializeField] Animator MagoAnimator;
    [SerializeField] float RadioDeAtaqueAdistancia, RadioDeAtaqueADistanciaMaximo;
    [SerializeField] Transform Posicionjugador;
    Vector3 direccion;
    [SerializeField] GameObject BalaASpawnear;
    Enemigos code_enemigo;
    float radioMaximoMago, radioMinMago;
    


    // Start is called before the first frame update
    void Start()
    {
        MagoAnimator = GetComponent<Animator>();
        code_enemigo = GameObject.FindAnyObjectByType<Enemigos>();
        

        radioMinMago = code_enemigo.RadioDeAtaque;
        radioMaximoMago = code_enemigo.RadioMaximoDeAtaque;

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
        

    }


    private IEnumerator DispararDentroDeAlcance()
    {

        while (true)
        {

            yield return new WaitForSeconds(1);
            Instantiate(BalaASpawnear, transform.position, quaternion.identity);
            yield return new WaitForSeconds(3);


            //if (Physics.SphereCast(transform.position, RadioDeAtaqueAdistancia, direccion, out RaycastHit Attackhit, RadioDeAtaqueADistanciaMaximo))
            //{
            //    StartCoroutine(InvocarBalas());
            //    direccion = Posicionjugador.transform.position - transform.position;

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DispararDentroDeAlcance());

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    public void CargaDeAtaqueDeMagoEnemigo()
    {


        {
            if (Physics.SphereCast(transform.position, radioMinMago, transform.right, out RaycastHit Attackhit, radioMaximoMago))//CORREGIR. TEN EN CUENTA QUE, SI ESTA CERCA EL ENEMIGO DEL JUGADOR, NO DEBE MOVERSE, SINO ATACAR
            {
                MagoAnimator.SetBool("MagoAttackCharge", false);
                MagoAnimator.SetBool("Mago_attacking", true);




            }
            else
            {
                MagoAnimator.SetBool("MagoAttackCharge", false);
                MagoAnimator.SetBool("MagoAttackCharge", false);
                
            }


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
