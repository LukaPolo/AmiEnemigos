using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public static int objetos = 0;
    public float velx = 220;
    public Rigidbody2D rigid2d;
    float angle;

    Vector2 input;
    public float rotInter = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        movimiento();
        alimento();
    }
    private void FixedUpdate()
    {
        rigid2d.velocity = input * velx * Time.deltaTime;
    }

    public void movimiento()
    {
        Vector2 lookDir = new Vector2(-input.x, input.y);
        angle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg;

        if (rigid2d.rotation<= - 90 && angle >= 90)
        {
            rigid2d.rotation += 360;
            rigid2d.rotation = Mathf.Lerp(rigid2d.rotation, angle, rotInter);
        } else if (rigid2d.rotation >= 90 && angle <= -90)
        {
            rigid2d.rotation -= 360;
            rigid2d.rotation = Mathf.Lerp(rigid2d.rotation, angle, rotInter);
        }
        else
        {
            rigid2d.rotation = Mathf.Lerp(rigid2d.rotation, angle, rotInter);
        }

    }
    public void alimento()
    {

        if (pez.comida == true)
        {
            objetos = 1 ;
            spawnPez.cantidad = 0;
            pez.comida = false;
        }
    }
}
