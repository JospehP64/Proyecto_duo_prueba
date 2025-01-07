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

        DispararDentroDeAlcance();

    }

    // Update is called once per frame
    void Update()
    {
        //DispararDentroDeAlcance();

    }

    private void DispararDentroDeAlcance()
    {
        if (Physics.SphereCast(transform.position, RadioDeAtaqueAdistancia, transform.right, out RaycastHit Attackhit, RadioDeAtaqueADistanciaMaximo))
        {
            StartCoroutine(InvocarBalas());
            direccion = Posicionjugador.transform.position - transform.position;
            
            

        }
        else
        {
            StopCoroutine(InvocarBalas());
        }
    }

    IEnumerator InvocarBalas() 
    {
        while (Physics.SphereCast(transform.position, RadioDeAtaqueAdistancia, transform.right, out RaycastHit Attackhit, RadioDeAtaqueADistanciaMaximo))
        {
            yield return new WaitForSeconds(1);
            Instantiate(BalaASpawnear, transform.position, quaternion.identity);
            yield return new WaitForSeconds(3);
        }
        
        

    }
}
