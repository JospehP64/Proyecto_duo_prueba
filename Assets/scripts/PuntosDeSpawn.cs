using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosDeSpawn : MonoBehaviour
{
    [SerializeField] Transform[] PuntosDeSpawneo;
    [SerializeField] GameObject Enemigos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InvocarEnemigos());
        Instantiate(Enemigos, PuntosDeSpawneo[0].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
        Instantiate(Enemigos, PuntosDeSpawneo[1].position, Quaternion.identity);
        Instantiate(Enemigos, PuntosDeSpawneo[2].position, Quaternion.identity);
        Instantiate(Enemigos, PuntosDeSpawneo[3].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator InvocarEnemigos()
    {
        yield return new WaitForSeconds(1);
    }
}
