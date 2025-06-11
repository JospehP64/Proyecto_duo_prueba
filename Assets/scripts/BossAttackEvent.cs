using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossAttackEvent : MonoBehaviour
{
    [SerializeField] GameObject AtaqueEnemigo;
    [SerializeField] Transform BossAttackSPawn;
    [SerializeField] Animator BossAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BossAtaqueLaser()
    {
        
        AnimationEvent BossShotEven = new AnimationEvent();
        Instantiate(AtaqueEnemigo, BossAttackSPawn.position, Quaternion.identity);
        BossAnimation.SetBool("is_idling", true);
        BossAnimation.SetBool("is_charging", false);


    }
}
