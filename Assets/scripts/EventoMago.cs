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
        StartCoroutine(InvocarBalas());
        direccion = Posicionjugador.transform.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
                
    }
    IEnumerator InvocarBalas() 
    {
        if (Physics.SphereCast(transform.position, RadioDeAtaqueAdistancia, transform.right, out RaycastHit Attackhit, RadioDeAtaqueADistanciaMaximo)) 
        {

        }
        Instantiate(BalaASpawnear, transform.position, quaternion.identity);
        yield return new WaitForSeconds(10);
    }
}
