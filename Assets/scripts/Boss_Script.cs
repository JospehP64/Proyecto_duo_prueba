using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Boss_Script : MonoBehaviour
{
    
    float HurtTime;
    [SerializeField] Personajes_SO Player_SO;
    [SerializeField] Enemigos_SO Enem_SO;
    [SerializeField] int ResistenciaDeBoss;
    [SerializeField]Animator BossAnimator;
    [SerializeField]SpriteRenderer BossSprite;
    [SerializeField] PuntosDeSpawn EnemySpawn;
    
    


    // Start is called before the first frame update
    
    void Start()
    {
        


        BossSprite.color = Color.white;
        BossAnimator.SetBool("is_idling", true);
        BossAnimator.SetBool("is_charging", false);

        StartCoroutine(SistemaDeAtaque());
    }

    // Update is called once per frame
    void Update()
    {
        BossIsDefeated();
    }
    public void bossRecibeAtaque()
    {

        StartCoroutine(ParpadearAlRecibirAtaque());




    }
    IEnumerator SistemaDeAtaque()
    {

        while (true)
        {
            if (ResistenciaDeBoss <= 50)
            {
                
                Debug.Log("EL BOSS ESTÁ INMOBIL");
                yield return new WaitForSeconds(1);

                Debug.Log("EL BOSS ESTÁ CARGANDO SU ATAQUE");
                BossAnimator.SetBool("is_charging", true);
                BossAnimator.SetBool("is_idling", false);
                yield return new WaitForSeconds(3);
                Debug.Log("EL BOSS DISPARA EL ATAQUE");
                BossAnimator.SetBool("is_charging", false);
                
                BossAnimator.SetTrigger("Is_shooting");
                BossAnimator.SetBool("is_idling", false);
                yield return new WaitForSeconds(3);
            }
            else
            {

                Debug.Log("EL BOSS ESTÁ INMOBIL");
                yield return new WaitForSeconds(3);

                Debug.Log("EL BOSS ESTÁ CARGANDO SU ATAQUE");
                BossAnimator.SetBool("is_charging", true);
                BossAnimator.SetBool("is_idling", false);
                yield return new WaitForSeconds(3);
                Debug.Log("EL BOSS DISPARA EL ATAQUE");
                BossAnimator.SetBool("is_charging", false);
                
                BossAnimator.SetTrigger("Is_shooting");
                BossAnimator.SetBool("is_idling", false);
                yield return new WaitForSeconds(3);
            }
            
            
        }
        

    }
    IEnumerator ParpadearAlRecibirAtaque()
    {
        BossSprite.color = Color.red;
        ResistenciaDeBoss--;
        yield return new WaitForSeconds(1);
        BossSprite.color = Color.white;

    }
    void BossIsDefeated()
    {
       
        if (ResistenciaDeBoss <= 0)
        {
            PuntosDeSpawn.totalDeEnemigos--;
            Destroy(gameObject);
        }
        else
        {
             
        }
    }
}
