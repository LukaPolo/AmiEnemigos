using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//En este script genero ataques como proyectiles
public class AttackGenerator : MonoBehaviour
{
    [SerializeField]
    private string attackStatus;
    public string AttackStatus { get => attackStatus; set => attackStatus = value; }
    [SerializeField]
    private AudioSource attackSound;
    [SerializeField]
    private GameObject[] pawnAttack;//el prefab de las garritas
    [SerializeField]
    private float timeRange;//tiempo que ataca entre el ultimo disparo (simple)
    private float inteval;//intervalo entre los ataques seguidos
    [SerializeField]
    private bool isAttacking;
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }

    [SerializeField]
    private int bullet;
    
    void Start()
    {
        
        isAttacking = false;
        attackSound = GetComponent<AudioSource>();
        //estos 2 siguientes que lo vea el equipo de balance xD
        inteval = 0.1f;
        timeRange = 0.4f;
        CheckStatus();
    }
    private void Update()
    {
        if (isAttacking)
        {
            CheckStatus();
            isAttacking = false;
        }    
    }

    void CheckStatus()
    {
        //Attacks pawnAttacks = pawnAttack[].GetComponent<Attacks>();
        switch (attackStatus)
        {
            case "attack1": //los disparos tendran una velocidad en fase 1
                bullet = 0;
                GenerateSimpleAttack();
                break;
            case "attack2"://en fase 2 otra ya que solo se dispara desde un mismo lugar
                CancelInvoke();
                GenerateTargeredAttack();
                break;
            case "stop"://Cancela los disparos
                CancelInvoke();
                attackSound.Stop();
                break;
        }
    }
    void GenerateSimpleAttack()
    {
        InvokeRepeating("GenerateAttack",1f,timeRange);
    }
    void GenerateTargeredAttack()
    {
        int i = Random.Range(1, 11);//Tiramos un random para ver que tipo de ataque se genera 
        if (i == 1)//10% de probabilidad de ataque doble
        {
            bullet = 0;
            Invoke("GenerateAttack",0);
            Invoke("GenerateAttack", inteval);
            Invoke("GenerateTargeredAttack", timeRange+inteval);
        }
        else if (i == 10)//10% de probabilidad de ataque triple
        {
            bullet = 1;
            Invoke("GenerateAttack", 0);
            Invoke("GenerateAttack", inteval);
            Invoke("GenerateAttack", (inteval*2));
            Invoke("GenerateTargeredAttack", timeRange) ;
        }
        else//80% de probabilidad de 1 solo ataque
        {
            bullet = 2;
            Invoke("GenerateAttack", 0);
            Invoke("GenerateTargeredAttack", timeRange);
        }
    }

    void GenerateAttack()
    {
        attackSound.Play();
        Quaternion temporalRotation = transform.rotation;
        Instantiate(pawnAttack[bullet], transform.position, temporalRotation);
    }
}
