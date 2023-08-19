using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCuerdas_VR : MonoBehaviour
{
    [Header("------Game objects------")]
    public GameObject cuerda;
    public GameObject cuerda2;
    public GameObject cuerda3;
    ObiRopeCursor cursor;
    ObiRopeCursor cursor2;
    ObiRopeCursor cursor3_AnclaAccesorio;


    ObiRope rope;
    ObiRope rope2;
    ObiRope roper3_AnclaAccesorio;


    [Header("------Propiedades de movimiento------")]
    public float minLength = 1.5f;
    public float maxLength = 13;
    public float timpoDe_Incrementacion = 0.02f;
    public float timpoDe_Decrementacion = 0.1f;
    public float incremento;
    public float velocidad = 1;
    public bool moving;
    public string directionMovement;

    [Header("------Restricciones de movimiento------")]
    public bool canMove;

    void Start()
    {
        rope = cuerda.GetComponent<ObiRope>();
        rope2 = cuerda2.GetComponent<ObiRope>();
        cursor = cuerda.GetComponent<ObiRopeCursor>();
        cursor2 = cuerda2.GetComponent<ObiRopeCursor>();
        roper3_AnclaAccesorio = cuerda3.GetComponent<ObiRope>();
        cursor3_AnclaAccesorio = cuerda3.GetComponent<ObiRopeCursor>();
    }


    void Update()
    {
        if (canMove && moving)
        {
            RiseVelocity();
            MovementFunction();

        }
        else if (canMove && !moving)
        {
            DecreceVelocity();
            MovementFunction();
        }

        else if (!canMove && !moving)
        {
            DecreceVelocity();
            MovementFunction();
        }




        if (Input.GetKey(KeyCode.R))
        {
            canMove = true;
            moving = true;
            directionMovement = "up";
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            canMove = false;
            moving = false;
            directionMovement = "up";
        }


        if (Input.GetKey(KeyCode.F))
        {
            canMove = true;
            moving = true;
            directionMovement = "down";
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            canMove = false;
            moving = false;
            directionMovement = "down";
        }

    }

    void MovementFunction()
    {
        switch (directionMovement)
        {
            case "up":
                if (rope.restLength > minLength || rope2.restLength > minLength)
                {
                    float speedCuerda_ = incremento * Time.deltaTime * velocidad;

                    cursor.ChangeLength(rope.restLength - speedCuerda_);
                    cursor2.ChangeLength(rope2.restLength - speedCuerda_);
                    cursor3_AnclaAccesorio.ChangeLength(roper3_AnclaAccesorio.restLength - speedCuerda_);
                }


                break;

            case "down":
                if (rope.restLength < maxLength && rope2.restLength < maxLength)
                {
                    float speedCuerda_ = incremento * Time.deltaTime * velocidad;

                    cursor.ChangeLength(rope.restLength + speedCuerda_);
                    cursor2.ChangeLength(rope2.restLength + speedCuerda_);
                    cursor3_AnclaAccesorio.ChangeLength(roper3_AnclaAccesorio.restLength + speedCuerda_);
                }

                break;

            default:
                break;
        }
    }

    public void setDirection(string dir)
    {
        //DirectionMovement tmp = (DirectionMovement)Enum.Parse(typeof(DirectionMovement), dir, true);
        directionMovement = dir.ToLower();
    }

    public void setMoving(bool moving)
    {
        this.moving = moving;
    }

    void RiseVelocity()
    {
        //primera forma
        //velocidad += Time.deltaTime;
        //velocidad += Mathf.Pow(velocidad, 2)*0.01f;
        //velocidad = Mathf.Clamp(velocidad, 0, 1);

        //segunda forma
        incremento = Mathf.Lerp(incremento, 1, timpoDe_Incrementacion);
    }

    void DecreceVelocity()
    {
        //primera forma
        //velocidad = 0;

        //segunda forma
        incremento = Mathf.Lerp(incremento, 0, timpoDe_Decrementacion);//siempre la decrementacion tiene que ser mayor que la incrmenetacion
    }

}
