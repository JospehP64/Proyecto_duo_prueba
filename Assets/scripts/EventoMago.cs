using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EventoMago : MonoBehaviour
{
    
    [SerializeField]float RadioDeAtaqueAdistancia, RadioDeAtaqueADistanciaMaximo;
    [SerializeField]Transform Posicionjugador;
    Vector3 direccion;
    [SerializeField]GameObject BalaASpawnear;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DispararDentroDeAlcance());
    }

    // Update is called once per frame
    void Update()
    {
        //DispararDentroDeAlcance();

    }

    private IEnumerator DispararDentroDeAlcance()
    {
        while(true)
        {
            
                Instantiate(BalaASpawnear, transform.position, quaternion.identity);
                yield return new WaitForSeconds(1);


            //if (Physics.SphereCast(transform.position, RadioDeAtaqueAdistancia, direccion, out RaycastHit Attackhit, RadioDeAtaqueADistanciaMaximo))
            //{
            //    StartCoroutine(InvocarBalas());
            //    direccion = Posicionjugador.transform.position - transform.position;



            //}
        }
   
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
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
    //IEnumerator InvocarBalas() 
    //{
    //    while (Physics.SphereCast(transform.position, RadioDeAtaqueAdistancia, direccion, out RaycastHit Attackhit, RadioDeAtaqueADistanciaMaximo))
    //    {
    //        yield return new WaitForSeconds(1);
    //        yield return new WaitForSeconds(3);
    //    }



    //}
}
