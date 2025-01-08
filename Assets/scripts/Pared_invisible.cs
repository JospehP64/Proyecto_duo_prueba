using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared_invisible : MonoBehaviour
{
    //NOTA: LAS PAREDES INVISIBLES SOLO SIRVEN PARA PREVENIR QUE LAS BALAS Y LOS OBSTACULOS SALGAN AFUERA DEL ESCENARIO Y, EN CONTACTO CON ESTAS "PAREDES", SE DESTRUYAN AL INSTANTE
    
    private void OnTriggerEnter(Collider collisionPared)
    {
        if (collisionPared.gameObject.CompareTag("coche") || collisionPared.gameObject.CompareTag("bala"))
        {
            Destroy(collisionPared.gameObject);
        }
    }
}
