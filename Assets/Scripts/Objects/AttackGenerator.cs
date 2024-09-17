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
    private GameObject pawnAttack;//el prefab de las garritas
    [SerializeField]
    private float timeRange;//tiempo que ataca entre el ultimo disparo (simple)
    private float inteval;//intervalo entre los ataques seguidos
    [SerializeField]
    private bool isAttacking;
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    
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
        Attacks pawnAttacks = pawnAttack.GetComponent<Attacks>();
        switch (attackStatus)
        {
            case "attack1": //los disparos tendran una velocidad en fase 1
                pawnAttacks.Velocity = 4f;                
                GenerateSimpleAttack();
                break;
            case "attack2"://en fase 2 otra ya que solo se dispara desde un mismo lugar
                pawnAttacks.Velocity = 6f;
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
        GenerateAttack();
        Invoke("GenerateSimpleAttack", timeRange);
    }
    void GenerateTargeredAttack()
    {
        Instantiate(pawnAttack, transform.position, transform.rotation);
        int i = Random.Range(1, 11);//Tiramos un random para ver que tipo de ataque se genera 
        GenerateAttack();
        if (i == 1)//10% de probabilidad de ataque doble
        {                       
            Invoke("GenerateAttack", inteval);
            Invoke("GenerateTargeredAttack", timeRange+inteval);
        }
        else if (i == 10)//10% de probabilidad de ataque triple
        {
            Invoke("GenerateAttack", inteval);
            Invoke("GenerateAttack", inteval + inteval);
            Invoke("GenerateTargeredAttack", timeRange + inteval + inteval + inteval);
        }
        else//80% de probabilidad de 1 solo ataque
        {
            Invoke("GenerateTargeredAttack", timeRange);
        }
    }

    void GenerateAttack()
    {
        attackSound.Play();
        Quaternion temporalRotation = transform.rotation;
        Instantiate(pawnAttack, transform.position, temporalRotation);
    }
}
