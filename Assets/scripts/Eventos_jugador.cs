using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Eventos_jugador : MonoBehaviour
{
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
