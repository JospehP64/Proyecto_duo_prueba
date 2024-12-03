using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosDeSpawn : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextoRondas;
    int rondas = 0;
    [SerializeField] Transform[] PuntosDeSpawneo;
    [SerializeField] GameObject Enemigos;
    [SerializeField] GameObject MiniBoss;
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
        Debug.Log("Rondas: " + rondas);
        TextoRondas.SetText("Ronda: " + rondas);
        Debug.Log("Total de enemigos " + totalDeEnemigos);
        Debug.Log("RondasEnejecución: " + enEjecucion);
        ContarEnemigos();

    }

    private void ContarEnemigos()
    {

        if(totalDeEnemigos <= 0 && !enEjecucion)
        {
            
            StartCoroutine(InvocarEnemigos());

        }
        if (rondas == 3 && enEjecucion && totalDeEnemigos <= 0)
        {
            enEjecucion = false;

        }
        if (rondas > 4)
        {
            rondas = 0;
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

        if (totalDeEnemigos <= 0 && !enEjecucion)
        {
            enEjecucion = true;

        }
        rondas += 1;
        if (rondas == 1)
        {
            totalDeEnemigos = 0;
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
            Instantiate(MiniBoss, PuntosDeSpawneo[3].position, Quaternion.identity);
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
        else if (rondas == 3)
        {
            totalDeEnemigos = 0;
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
            Instantiate(Enemigos, PuntosDeSpawneo[3].position, Quaternion.identity);
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
            Instantiate(Enemigos, PuntosDeSpawneo[4].position, Quaternion.identity);
            totalDeEnemigos += 1;
            yield return new WaitForSeconds(1);
        }
        else if (rondas == 4)
        {
            totalDeEnemigos = 0;
            yield return new WaitForSeconds(1);
            Instantiate(MiniBoss, PuntosDeSpawneo[0].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
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
        if (totalDeEnemigos >= 0 && enEjecucion)
        {
            enEjecucion = false;

        }
        
        
    }
}
