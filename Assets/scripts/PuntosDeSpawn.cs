using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PuntosDeSpawn : MonoBehaviour
{
    [SerializeField]EVENTOSJUEGO GameEvents;


    
    [SerializeField] bool PlayerDefeatsBoss;
    [SerializeField] TextMeshProUGUI TextoRondas;
    public int rondas = 0;
    [SerializeField] GameObject Objeto_PuntosDeSpawneoDeBoss;
    [SerializeField] Transform[] PuntosDeSpawneo;
    [SerializeField] GameObject[] PuntosDeSpawneoDeEnemigos;
    [SerializeField] Transform PuntosDeSpawneoDeBoss;
    [SerializeField] Transform[] PuntosDeObstaculo;
    [SerializeField] GameObject[] MonstruosASpawnear;
    [SerializeField] GameObject[] ObstaculosASpawnear;
    [SerializeField] GameObject BossASpawnear;

    [SerializeField] GUI_SO GUI_SO_data_spawn;

    [SerializeField]bool AvisarDeCoche;

    float TiempoDeEsperaAObstaculos = 0;

    int ObstacleRandomizer, ObstacleLocation;//La posibilidad de que se genere un coche de un tipo y de que se invoque en un generador o "spawner" aleatorio

    int EnemyRandomizer;

    int SpawnerRandomizer;

    public static int totalDeEnemigos; //URGENTE

    private bool enEjecucion = false;

    private void Awake()
    {
        PuntosDeSpawneoDeEnemigos[0].SetActive(false);
        PuntosDeSpawneoDeEnemigos[1].SetActive(false);
        PuntosDeSpawneoDeEnemigos[2].SetActive(false);
        PuntosDeSpawneoDeEnemigos[3].SetActive(false);
        Objeto_PuntosDeSpawneoDeBoss.SetActive(false);
        GUI_SO_data_spawn.rondas_gui = rondas;
        rondas = 0;
        
        EnemyRandomizer = Random.Range(0, 4);

        SpawnerRandomizer = Random.Range(0, 4);
    }

    // Start is called before the first frame update
    void Start()
    {
        GUI_SO_data_spawn.PlayerWins = PlayerDefeatsBoss;
        rondas = 0;
        //GameEvents  = GameObject.Find("Admin de Puntos de spawn").GetComponent<EVENTOSJUEGO>();

        AvisarDeCoche = false;
        totalDeEnemigos = 0;
        
        enEjecucion = false;



        StartCoroutine(InvocarEnemigos());
        
    }

    // Update is called once per frame
    void Update()
    {
        GUI_SO_data_spawn.PlayerWins = PlayerDefeatsBoss;
        GUI_SO_data_spawn.rondas_gui = rondas;
        GUI_SO_data_spawn.AvisoDeCoche = AvisarDeCoche;
        
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
        if (rondas > 3 && totalDeEnemigos <= 0)//Reinicia la cuenta Si sobre pasa el numero de rondas establecido
        {

            PlayerDefeatsBoss = true;

        }
        
        
    }


    IEnumerator InvocarEnemigos()
    {
       

        if (totalDeEnemigos <= 0 && enEjecucion == false)
        {
            
            enEjecucion = true;

        }
        if (totalDeEnemigos <= 0 && rondas <= 3)
        {
            rondas += 1;
        }
        
        if (rondas == 1)
        {
            
            totalDeEnemigos = 0;
            yield return new WaitForSeconds(1);
            PuntosDeSpawneoDeEnemigos[0].SetActive(true);
            PuntosDeSpawneoDeEnemigos[1].SetActive(true);
            PuntosDeSpawneoDeEnemigos[2].SetActive(true);
            PuntosDeSpawneoDeEnemigos[3].SetActive(true);
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
                else if (EnemyRandomizer == 2 && EnemyRandomizer < 3)
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
            PuntosDeSpawneoDeEnemigos[0].SetActive(false);
            PuntosDeSpawneoDeEnemigos[1].SetActive(false);
            PuntosDeSpawneoDeEnemigos[2].SetActive(false);
            PuntosDeSpawneoDeEnemigos[3].SetActive(false);

        }
        else if (rondas == 2)
        {
            totalDeEnemigos = 0;
            yield return new WaitForSeconds(1);
            PuntosDeSpawneoDeEnemigos[0].SetActive(true);
            PuntosDeSpawneoDeEnemigos[1].SetActive(true);
            PuntosDeSpawneoDeEnemigos[2].SetActive(true);
            PuntosDeSpawneoDeEnemigos[3].SetActive(true);
            for (int spawnCount = 0; spawnCount < 6; spawnCount++)
            {
                EnemyRandomizer = Random.Range(0, 4);
                SpawnerRandomizer = Random.Range(0, 4); //0, 1, 2, 3
                if (EnemyRandomizer <= 1)
                {
                    
                    

                    Instantiate(MonstruosASpawnear[0], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                else if (EnemyRandomizer == 2 && EnemyRandomizer < 3)
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
            PuntosDeSpawneoDeEnemigos[0].SetActive(false);
            PuntosDeSpawneoDeEnemigos[1].SetActive(false);
            PuntosDeSpawneoDeEnemigos[2].SetActive(false);
            PuntosDeSpawneoDeEnemigos[3].SetActive(false);


        }
        else if (rondas == 3)
        {
            totalDeEnemigos = 0;
            yield return new WaitForSeconds(1);
            PuntosDeSpawneoDeEnemigos[0].SetActive(true);
            PuntosDeSpawneoDeEnemigos[1].SetActive(true);
            PuntosDeSpawneoDeEnemigos[2].SetActive(true);
            PuntosDeSpawneoDeEnemigos[3].SetActive(true);
            Objeto_PuntosDeSpawneoDeBoss.SetActive(true);
            
            
            yield return new WaitForSeconds(3);
            Objeto_PuntosDeSpawneoDeBoss.SetActive(false);
            Instantiate(BossASpawnear, PuntosDeSpawneoDeBoss.position, Quaternion.identity);
            totalDeEnemigos += 1;
            for (int spawnCount = 0; spawnCount < 8; spawnCount++)
            {
               
                EnemyRandomizer = Random.Range(0, 4);
                SpawnerRandomizer = Random.Range(0, 4); //0, 1, 2, 3
                if (EnemyRandomizer <= 1)
                {



                    Instantiate(MonstruosASpawnear[0], PuntosDeSpawneo[SpawnerRandomizer].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
                    totalDeEnemigos += 1;
                    yield return new WaitForSeconds(1);
                }
                else if (EnemyRandomizer == 2  && EnemyRandomizer < 3)
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
            
            yield return new WaitForSeconds(1);
            PuntosDeSpawneoDeEnemigos[0].SetActive(false);
            PuntosDeSpawneoDeEnemigos[1].SetActive(false);
            PuntosDeSpawneoDeEnemigos[2].SetActive(false);
            PuntosDeSpawneoDeEnemigos[3].SetActive(false);
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
            if ( PlayerDefeatsBoss == false)
            {
                AvisarDeCoche = false;
                ObstacleRandomizer = Random.Range(0, 5);
                ObstacleLocation = Random.Range(0, 7);//Punto aleatorio donde se generará el obstáculo

                yield return new WaitForSeconds(8);
                AvisarDeCoche = true;
                Instantiate(ObstaculosASpawnear[ObstacleRandomizer], PuntosDeObstaculo[ObstacleLocation].position, Quaternion.identity);
                yield return new WaitForSeconds(1);
                
            }
            


        }
    }
}
