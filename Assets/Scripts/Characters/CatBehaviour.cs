using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject attackGenerator;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Transform[] checkpoint; //Arraylist que contiene las posiciones de los puntos del objeto)
    private float timeSearching;
    [SerializeField]
    private float speed;
    private Vector3 lastPos;
    private Vector3 nuevaPosicion;
    [SerializeField]
    private string catStatus;
    public string CatStatus { get => catStatus; set => catStatus = value; }
    [SerializeField]
    private bool changeStatus;
    public bool ChangeStatus { get => changeStatus; set => changeStatus = value; }


    // Start is called before the first frame update
    void Start()
    {
        changeStatus = false;
        speed = 6f;
        timeSearching = 3f;
        catStatus = "phase1";
        CheckStatus();
    }
    // Update is called once per frame
    void Update()
    {
        if (changeStatus)
        {
            CheckStatus();
            changeStatus = false;
        }
        /*if (Input.GetKeyUp(KeyCode.E))
        {
            catStatus = "phase1";
            speed = 6f;
            CheckStatus();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            catStatus = "phase2";
            CheckStatus();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            catStatus = "phase3";
            speed = 20;
            CheckStatus();
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            catStatus = "phase4";
            speed = 3;
            CheckStatus();
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            catStatus = "phase5";
            speed = 0;
            CheckStatus();
        }*/
    }

    void CheckStatus()
    {
        AttackGenerator attackGen = attackGenerator.GetComponent<AttackGenerator>();
        switch (catStatus)
        {
            case "phase1":
                attackGen.AttackStatus = "attack1";
                attackGen.IsAttacking = true;
                StartCoroutine("MoveBetweenCheckPoints");
                break;
            case "phase2":
                attackGen.AttackStatus = "attack2";
                attackGen.IsAttacking = true;
                StopCoroutine("MoveBetweenCheckPoints");
                StartCoroutine("MoveToCenter");
                break;
            case "phase3":
                speed = 20;
                attackGen.AttackStatus = "stop";
                attackGen.IsAttacking = true;
                StopCoroutine("LookingForPlayer");
                StartCoroutine("ChargedAttack");
                break;
            case "phase4":
                speed = 3;
                StopCoroutine("ChargedAttack");
                StartCoroutine("FollowPlayer");
                break;
            case "phase5":
                StopCoroutine("FollowPlayer");
                break;
        }
    }

    IEnumerator MoveBetweenCheckPoints()
    {
        int i = 1;
        nuevaPosicion = new Vector3(checkpoint[i].position.x, transform.position.y, transform.position.z);
        while (true)
        {
            while (transform.position != nuevaPosicion)
            {
                transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, speed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSecondsRealtime(0.1f);
            
            if (i >= 1)
            {
                i = 0;
            }
            else
            {
                i++;
            }            
            nuevaPosicion = new Vector3(checkpoint[i].position.x, transform.position.y, transform.position.z);
        }
    }

    IEnumerator MoveToCenter()
    {
        nuevaPosicion = new Vector3(checkpoint[2].position.x, transform.position.y, transform.position.z);
        while (transform.position != nuevaPosicion)
        {
            transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, speed * Time.deltaTime);
            yield return null;
        }
        StopCoroutine("MoveToCenter");
        StartCoroutine("LookingForPlayer");
    }

    IEnumerator LookingForPlayer()
    {
        while (true)
        {
            LookAtPlayer();
            yield return null;
        }
    }

    IEnumerator ChargedAttack()
    {

        while (true)
        {
            // Bucle que se ejecutará mientras el tiempo restante sea mayor que 0
            while (timeSearching > 0)
            {
                LookAtPlayer();
                timeSearching -= Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSecondsRealtime(0.1f);
            lastPos = target.transform.position;
            while (transform.position != lastPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, lastPos, speed * Time.deltaTime);
                yield return null;
            }
            timeSearching = 3f;
        }
    }

    IEnumerator FollowPlayer()
    {
        while (true)
        {
            LookAtPlayer();
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            yield return null;
        }
    }

    void LookAtPlayer()
    {
        Vector3 look = transform.InverseTransformPoint(target.transform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg + 90;
        transform.Rotate(0, 0, angle);        
    }
}
