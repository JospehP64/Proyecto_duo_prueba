using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVENTOSJUEGO : MonoBehaviour
{
    [SerializeField] Canvas CanvasPausa;
    bool JuegoEnPausa = false;
    // Start is called before the first frame update
    void Start()
    {
        CanvasPausa.enabled = false;
    }
    private void Update()
    {
        PausarJuego();
    }

    // Update is called once per frame
    void PausarJuego()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && JuegoEnPausa == false)
        {
            CanvasPausa.enabled = true;
            JuegoEnPausa = true;
            Time.timeScale = 0;
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && JuegoEnPausa == true)
        {
            CanvasPausa.enabled = false;
            Time.timeScale = 1;
            JuegoEnPausa = false;
        }
       
        
    }
    public void BotonPausarJuego()
    {
        if (JuegoEnPausa == false)
        {
            CanvasPausa.enabled = true;
            JuegoEnPausa = true;
            Time.timeScale = 0;

        }
        else if ( JuegoEnPausa == true)
        {
            CanvasPausa.enabled = false;
            Time.timeScale = 1;
            JuegoEnPausa = false;
        }


    }
}
