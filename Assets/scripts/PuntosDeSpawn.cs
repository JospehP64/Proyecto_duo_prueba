using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosDeSpawn : MonoBehaviour
{
    [SerializeField] Transform[] PuntosDeSpawneo;
    [SerializeField] GameObject Enemigos;
    public static int totalDeEnemigos; //URGENTE
    [SerializeField] int enemycount;
    
    // Start is called before the first frame update
    void Start()
    {
        enemycount = totalDeEnemigos;
        StartCoroutine(InvocarEnemigos());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (totalDeEnemigos < 4 && totalDeEnemigos > 0)
        {
            for (int spawntime = 0; spawntime < 20; spawntime++)//URGENTE. ERROR
            {
                if (spawntime <= 20)
                {

                    StartCoroutine(InvocarEnemigos());

                }
                else
                {

                }
            }
        }
        else if (totalDeEnemigos >= 4)
        {

        }
        
    }
    IEnumerator InvocarEnemigos()
    {
        
        Instantiate(Enemigos, PuntosDeSpawneo[0].position, Quaternion.identity);//RECUERDA: .POSITION AL LADO DE LOS PUNTOS DEL SPAWNEO. QUATERNION.IDENTITY PARA FIJAR LA ROTACIÓN DETERMINADA DEL OBJETO.
        totalDeEnemigos++;
        yield return new WaitForSeconds(1);
        Instantiate(Enemigos, PuntosDeSpawneo[1].position, Quaternion.identity);
        totalDeEnemigos++;
        yield return new WaitForSeconds(1);
        Instantiate(Enemigos, PuntosDeSpawneo[2].position, Quaternion.identity);
        totalDeEnemigos++;
        yield return new WaitForSeconds(1);
        Instantiate(Enemigos, PuntosDeSpawneo[3].position, Quaternion.identity);
        totalDeEnemigos++;
        yield return new WaitForSeconds(1);
    }
}
