using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGenerator : MonoBehaviour
{
    [SerializeField]
    private string status;
    [SerializeField]
    private AudioSource attackSound;
    [SerializeField]
    private GameObject pawnAttack;
    [SerializeField]
    private float timeRange;
    public string Status { get => status; set => status = value; }

    void Start()
    {
        status = "ataque2";
        attackSound = GetComponent<AudioSource>();
        Invoke("CheckStatus", 0.4f);
    }
    private void Update()
    {
        //Esto debe de ser controlado por la maquina de estado y no por el Update
        if (Input.GetKeyDown(KeyCode.E))
        {
            status = "ataque1";
            CheckStatus();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            status = "stop";
            CancelInvoke();
            CheckStatus();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            status = "ataque2";
            CheckStatus();
        }
    }

    void CheckStatus()
    {
        switch (status)
        {
            case "ataque1":
                GenerateSimpleAttack();
                break;
            case "ataque2":
                GenerateTargeredAttack();
                break;
            case "stop":
                attackSound.Stop();
                break;
        }
    }
    void GenerateSimpleAttack()
    {
        //Debug.Log("Paso por ATAQUE 1");
        attackSound.Play();
        GenerateAttack();
        Invoke("GenerateSimpleAttack", timeRange);
    }
    void GenerateTargeredAttack()
    {
        //Debug.Log("Paso por ATAQUE 2");
        int i = Random.Range(1, 11);
        Instantiate(pawnAttack, transform.position, transform.rotation);

        if (i == 1)
        {
            Invoke("GenerateAttack", 0);
            attackSound.Play();
            Invoke("GenerateAttack", 0.1f);
            attackSound.Play();
            Invoke("GenerateTargeredAttack", 0.6f);
            attackSound.Play();

        }
        else if (i == 10)
        {
            Invoke("GenerateAttack", 0);
            attackSound.Play();
            Invoke("GenerateAttack", 0.1f);
            attackSound.Play();
            Invoke("GenerateAttack", 0.2f);
            attackSound.Play();
            Invoke("GenerateTargeredAttack", 0.7f);
        }
        else
        {
            Invoke("GenerateAttack", 0);
            attackSound.Play();
            Invoke("GenerateTargeredAttack", 0.5f);
        }
    }

    void GenerateAttack()
    {
        Quaternion temporalRotation = transform.rotation;
        Instantiate(pawnAttack, transform.position, temporalRotation);
    }
}
