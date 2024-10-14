using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //Raton prop y movimiento
    public static int objetos = 0;
    public static float velx = 220;
    public Rigidbody2D rigid2d;
    float angle;
    private bool isRotating = false; // si la rotación está activa

    Vector2 input;
    public float rotInter = 0.4f;

    [SerializeField]
    private float multVel;

    public float MultVel { get => multVel; set => multVel = value; }

    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        multVel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        movimiento();
    }
    private void FixedUpdate()
    {
        rigid2d.velocity = input * velx * multVel * Time.deltaTime;
    }

    public void movimiento()
    {
        if (input == Vector2.zero)
        {
            if (isRotating) // Si el objeto estaba rotando, ahora deja de rotar
            {
                isRotating = false;
            }
            return; // No hacemos nada si no hay input
        }

        Vector2 lookDir = new Vector2(-input.x, input.y);
        angle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg;

        if (rigid2d.rotation <= -90 && angle >= 90)
        {
            rigid2d.rotation += 360;
        }
        else if (rigid2d.rotation >= 90 && angle <= -90)
        {
            rigid2d.rotation -= 360;
        }

        if (!Mathf.Approximately(rigid2d.rotation, angle))// comparamos el nuevo angulo con el actual si no son iguales
        {
            isRotating = true; // Se detectó un cambio, por lo que ahora está rotando
            rigid2d.rotation = Mathf.Lerp(rigid2d.rotation, angle, rotInter);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("food"))
        {
            Foods food = collision.GetComponent<Foods>();
            multVel = food.Debuff;
        }
    }
}
