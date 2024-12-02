using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosDeSpawn : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextoRondas;
    int rondas = 1;
    [SerializeField] Transform[] PuntosDeSpawneo;
    [SerializeField] GameObject Enemigos;
    public static int totalDeEnemigos; //URGENTE

    private bool enEjecucion = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(InvocarEnemigos());
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rondas);
        TextoRondas.SetText("Ronda: " + rondas);
        Debug.Log(totalDeEnemigos);
        ContarEnemigos();

    }

    private void ContarEnemigos()
    {

        if(totalDeEnemigos <= 0 && !enEjecucion)
        {
            rondas += 1;
            StartCoroutine(InvocarEnemigos());
        }

        //enemycount = totalDeEnemigos;

        //if (totalDeEnemigos < 4)
        //{
        //    for (int spawntime = 0; spawntime < 4 || spawntime <= 0; spawntime ++)//URGENTE. ERROR
        //    {
        //        if (spawntime >= 4)
        //        {
                    
        //            StartCoroutine(InvocarEnemigos());
        //            spawntime = 0;
        //        }
        //        else
        //        {

        //        }
        //    }
        //}
        //else if (totalDeEnemigos >= 4)
        //{

        //}
    }

    IEnumerator InvocarEnemigos()
    {
        
        enEjecucion = true;
        if (rondas == 1)
        {
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[0].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[1].position, Quaternion.identity);
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[2].position, Quaternion.identity);
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[3].position, Quaternion.identity);
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
        }
        else if (rondas == 2)
        {
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[0].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[1].position, Quaternion.identity);
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[2].position, Quaternion.identity);
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[3].position, Quaternion.identity);
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[0].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[1].position, Quaternion.identity);
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[2].position, Quaternion.identity);
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
        }
        

        enEjecucion = false;
    }
}
