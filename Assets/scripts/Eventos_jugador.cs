using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Eventos_jugador : MonoBehaviour
{
    [SerializeField]MovimientoPersonaje MovPersonaje;
    [SerializeField] RawImage rawCorazon;
    [SerializeField] RawImage rawCorazon_2;
    [SerializeField] RawImage rawCorazon_3;
    [SerializeField] Texture[] TexturaCorazon;
    RawImage corazon01;
    RawImage corazon03;
    RawImage corazon02;
    int vidaGUI;
    private void Start()
    {
        vidaGUI = MovPersonaje.vida;
        corazon01 = (RawImage)rawCorazon.GetComponent<RawImage>();
        corazon02 = (RawImage)rawCorazon_2.GetComponent<RawImage>();
        corazon03 = (RawImage)rawCorazon_3.GetComponent<RawImage>();

        

        corazon01.texture = (Texture)TexturaCorazon[0];
        corazon02.texture = (Texture)TexturaCorazon[0];
        corazon03.texture = (Texture)TexturaCorazon[0];

    }
    private void Update()
    {
        vidaGUI =  MovPersonaje.vida;
        if (vidaGUI >= 3)
        {
            corazon01.texture = (Texture)TexturaCorazon[0];
            corazon02.texture = (Texture)TexturaCorazon[0];
            corazon03.texture = (Texture)TexturaCorazon[0];
        }
        else if (vidaGUI == 2)
        {
            corazon01.texture = (Texture)TexturaCorazon[1];
            corazon02.texture = (Texture)TexturaCorazon[0];
            corazon03.texture = (Texture)TexturaCorazon[0];
        }
        else if (vidaGUI == 1)
        {
            corazon01.texture = (Texture)TexturaCorazon[1];
            corazon02.texture = (Texture)TexturaCorazon[1];
            corazon03.texture = (Texture)TexturaCorazon[0];
        }
        else if (vidaGUI <= 0)
        {
            corazon01.texture = (Texture)TexturaCorazon[1];
            corazon02.texture = (Texture)TexturaCorazon[1];
            corazon03.texture = (Texture)TexturaCorazon[1];
        }
    }

    public void player_melee_attack()
    {
        
         
        RaycastHit hit;
        AnimationEvent attackevent = new AnimationEvent();
        
        Physics.Raycast(transform.position, transform.right, 30);
        Debug.DrawLine(transform.position, transform.right, Color.yellow);
        if (Physics.Raycast(transform.position, transform.right, out hit))
        {
            if (hit.transform.gameObject.CompareTag("enemigo"))
            {
                Destroy(hit.transform.gameObject);
            }
        }


    }

}
