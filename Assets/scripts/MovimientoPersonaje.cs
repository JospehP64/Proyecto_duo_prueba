using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class MovimientoPersonaje : MonoBehaviour
{
    int vida;
    int energia;
    float velocidad;
   

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 movimiento = new Vector3(h, 0f, v) * velocidad * Time.deltaTime; ;
        transform.Translate(movimiento);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidad = 6;
        }
        else
        {
            velocidad = 3;
        }


        


    }
}
