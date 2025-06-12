using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossAttackEvent : MonoBehaviour
{
    [SerializeField] AudioClip[] SoundsArray;
    [SerializeField] AudioSource BossSounds;

    [SerializeField] GameObject AtaqueEnemigo;
    [SerializeField] Transform BossAttackSPawn;
    [SerializeField] Animator BossAnimation;
    // Start is called before the first frame update
    void Start()
    {
        BossSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            BossSounds.Stop();
        }
    }
    public void BossAtaqueLaser()
    {
        
        AnimationEvent BossShotEven = new AnimationEvent();
        Instantiate(AtaqueEnemigo, BossAttackSPawn.position, Quaternion.identity);
        BossAnimation.SetBool("is_idling", true);
        BossAnimation.SetBool("is_charging", false);


    }
    public void BossPrepareAttackSound()
    {
        if (Time.timeScale != 0)
        {
            BossSounds.Stop();
            BossSounds.PlayOneShot(SoundsArray[1]);
        }
        
    }
    public void BossIdleSound()
    {
        if (Time.timeScale != 0)
        {
            BossSounds.Stop();
            BossSounds.PlayOneShot(SoundsArray[0]);
        }
        
    }
}
