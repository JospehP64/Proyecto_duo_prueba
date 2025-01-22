using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PuntosDeSpawn : MonoBehaviour
{
    
    
    

    [SerializeField] TextMeshProUGUI TextoRondas;
    int rondas = 0;
    [SerializeField] Transform[] PuntosDeSpawneo;
    [SerializeField] Transform[] PuntosDeObstaculo;
    [SerializeField] GameObject[] MonstruosASpawnear;
    [SerializeField] GameObject[] ObstaculosASpawnear;
    float TiempoDeEsperaAObstaculos = 0;

    int ObstacleRandomizer, ObstacleLocation;//La posibilidad de que se genere un coche de un tipo y de que se invoque en un generador o "spawner" aleatorio

    int EnemyRandomizer = Random.Range(0, 4);//Para la posibilidad de que un enemigo aleatorio se genere dentro de cada ronda del juego
    
    int SpawnerRandomizer = Random.Range(0, 4);//Para calcular en dónde se generará el nuevo enemigo

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

        ContarObstaculo();

    }

    private void ContarObstaculo()
    {
        if (TiempoDeEsperaAObstaculos >= 5)
        {
            StartCoroutine(InvocarObstaculos());
            TiempoDeEsperaAObstaculos = 0;
        }
        else
        {
            StopCoroutine(InvocarObstaculos());
            TiempoDeEsperaAObstaculos += 1 * Time.deltaTime;
        }
    }

    private void ContarEnemigos()
    {

        if(totalDeEnemigos <= 0 && !enEjecucion)
        {
            
            StartCoroutine(InvocarEnemigos());

        }
        if (rondas == 5 && enEjecucion && totalDeEnemigos <= 0)//Reinicia la cuenta Si sobre pasa el numero de rondas establecido
        {
            enEjecucion = false;

        }
        if (rondas > 4)//Reinicia la cuenta Si sobre pasa el numero de rondas establecido
        {
            rondas = 0;
        }
        
        
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

            for (int spawnCount = 0; spawnCount < 4; spawnCount++)
            {
                
                EnemyRandomizer = Random.Range(0, 4);
                SpawnerRandomizer = Random.Range(0, 4); //0, 1, 2, 3
                if (EnemyRandomizer <= 1)
                {
                    
                    

                    Instantiate(MonstruosASpawnear[0], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                else if (EnemyRandomizer >= 2)
                {
                    
                    
                    Instantiate(MonstruosASpawnear[1], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                else if (EnemyRandomizer >= 3)
                {
                    

                    Instantiate(MonstruosASpawnear[2], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
            }
            
        }
        else if (rondas == 2)
        {
            totalDeEnemigos = 0;
            yield return new WaitForSeconds(1);

            for (int spawnCount = 0; spawnCount < 4; spawnCount++)
            {
                EnemyRandomizer = Random.Range(0, 4);
                SpawnerRandomizer = Random.Range(0, 4); //0, 1, 2, 3
                if (EnemyRandomizer <= 1)
                {
                    
                    

                    Instantiate(MonstruosASpawnear[0], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                else if (EnemyRandomizer >= 2)
                {
                    
                    
                    Instantiate(MonstruosASpawnear[1], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                else if (EnemyRandomizer >= 3)
                {
                    

                    Instantiate(MonstruosASpawnear[2], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
            }


        }
        else if (rondas == 3)
        {
            totalDeEnemigos = 0;
            yield return new WaitForSeconds(1);

            for (int spawnCount = 0; spawnCount < 4; spawnCount++)
            {

                EnemyRandomizer = Random.Range(0, 4);
                SpawnerRandomizer = Random.Range(0, 4); //0, 1, 2, 3
                if (EnemyRandomizer <= 1)
                {



                    Instantiate(MonstruosASpawnear[0], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                else if (EnemyRandomizer >= 2)
                {


                    Instantiate(MonstruosASpawnear[1], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                else if (EnemyRandomizer >= 3)
                {


                    Instantiate(MonstruosASpawnear[2], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
            }
        }
        else if (rondas == 4)
        {
            totalDeEnemigos = 0;
            yield return new WaitForSeconds(1);

            for (int spawnCount = 0; spawnCount < 4; spawnCount++)
            {

                EnemyRandomizer = Random.Range(0, 4);
                SpawnerRandomizer = Random.Range(0, 4); //0, 1, 2, 3
                if (EnemyRandomizer <= 0)
                {

                    

                    Instantiate(MonstruosASpawnear[0], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                else if (EnemyRandomizer >= 1)
                {

                    
                    Instantiate(MonstruosASpawnear[1], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                else
                {
                    

                    Instantiate(MonstruosASpawnear[0], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
            }
        }
        if (totalDeEnemigos >= 0 && enEjecucion)
        {
            enEjecucion = false;

        }
        
        
    }
    IEnumerator InvocarObstaculos()
    {
        yield return new WaitForSeconds(5);
        for (int CARTIME = 0; CARTIME < 6; CARTIME++)
        {
            ObstacleRandomizer = Random.Range(0, 5);
            ObstacleLocation = Random.Range(0, 7);//Punto aleatorio donde se generará el obstáculo
            Instantiate(ObstaculosASpawnear[ObstacleRandomizer], PuntosDeObstaculo[ObstacleLocation].position, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }
}
