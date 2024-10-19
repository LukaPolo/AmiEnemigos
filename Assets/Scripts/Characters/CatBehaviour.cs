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

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        changeStatus = false;
        speed = 6f;
        timeSearching = 3f;
        catStatus = "phase4";
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
    }

    void CheckStatus()
    {
        AttackGenerator attackGen = attackGenerator.GetComponent<AttackGenerator>();
        switch (catStatus)
        {
            case "phase1":
                animator.SetBool("isAttacking", true);
                animator.SetBool("isIdle", false);
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
                animator.SetBool("isAttacking", false);
                animator.SetBool("isIdle", true);
                transform.rotation = Quaternion.identity;
                speed = 20;
                attackGen.AttackStatus = "stop";
                attackGen.IsAttacking = true;
                StopCoroutine("LookingForPlayer");
                StartCoroutine("ChargedAttack");
                break;
            case "phase4":
                animator.SetBool("isIdle", true);
                animator.SetBool("isJumpingRight", false);
                animator.SetBool("isJumpingLeft", false);
                animator.SetBool("isMoving",true);
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
        animator.SetBool("isIdle", false);
        while (true)
        {
            
            // Bucle que se ejecutará mientras el tiempo restante sea mayor que 0
            while (timeSearching > 0)
            {
                WaitForPlayer();
                timeSearching -= Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSecondsRealtime(0.1f);
            animator.SetBool("isIdle", false);

            
            lastPos = target.transform.position;

            while (transform.position != lastPos)
            {
                Vector2 direction = (target.transform.position - transform.position).normalized;

                // Movimiento más hacia los lados
                if (direction.x >= 0)
                {
                    // Movimiento hacia la derecha
                    animator.SetBool("isJumpingRight", true);
                    animator.SetBool("isJumpingLeft", false);
                }
                else
                {
                    // Movimiento hacia la izquierda
                    animator.SetBool("isJumpingLeft", true);
                    animator.SetBool("isJumpingRight", false);
                }
                transform.position = Vector3.MoveTowards(transform.position, lastPos, speed * Time.deltaTime);
                yield return null;
            }
            animator.SetBool("isJumpingLeft", false);
            animator.SetBool("isJumpingRight", false);
            timeSearching = 3f;
            
        }
    }

    IEnumerator FollowPlayer()
    {
        while (true)
        {


            //LookAtPlayer();            
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            Vector2 direction = (target.transform.position - transform.position).normalized;
            // Comparar la dirección en el eje X y el eje Y
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Movimiento más hacia los lados
                if (direction.x > 0)
                {
                    // Movimiento hacia la derecha
                    animator.SetBool("Right", true);
                    animator.SetBool("Left", false);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);
                }
                else
                {
                    // Movimiento hacia la izquierda
                    animator.SetBool("Left", true);
                    animator.SetBool("Right", false);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);
                }
            }
            else
            {
                // Movimiento más hacia arriba o hacia abajo
                if (direction.y > 0)
                {
                    // Movimiento hacia arriba
                    animator.SetBool("Up", true);
                    animator.SetBool("Down", false);
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", false);
                }
                else
                {
                    // Movimiento hacia abajo
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", true);
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", false);
                }
            }
            yield return null;
        }
    }

    void LookAtPlayer()
    {
        
        Vector3 look = transform.InverseTransformPoint(target.transform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg + 90;
        transform.Rotate(0, 0, angle);
    }

    void WaitForPlayer()
    {        
        animator.SetBool("isIdle", true);
    }
}
