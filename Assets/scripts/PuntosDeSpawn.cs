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
    [SerializeField] GameObject[] MonstruosASpawnear;
    
    int EnemyRandomizer;//Para la posibilidad de que un enemigo aleatorio se genere dentro de cada ronda del juego
    
    int SpawnerRandomizer;//Para calcular en dónde se generará el nuevo enemigo

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
                
                EnemyRandomizer = Random.Range(0, 2);
                if (EnemyRandomizer <= 0)
                {
                    
                    SpawnerRandomizer = Random.Range(0, 5);

                    Instantiate(MonstruosASpawnear[0], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                else if (EnemyRandomizer >= 1)
                {
                    
                    SpawnerRandomizer = Random.Range(0, 5);
                    Instantiate(MonstruosASpawnear[1], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                EnemyRandomizer = Random.Range(0, 2);
            }
            
        }
        else if (rondas == 2)
        {

            

        }
        else if (rondas == 3)
        {
            
        }
        else if (rondas == 4)
        {
            
        }
        if (totalDeEnemigos >= 0 && enEjecucion)
        {
            enEjecucion = false;

        }
        
        
    }
}
