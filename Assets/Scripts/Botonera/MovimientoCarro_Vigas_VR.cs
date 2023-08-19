using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DirectionMovement { front, back, right, left, down, up, none };
public class MovimientoCarro_Vigas_VR : MonoBehaviour
{
    [Header("------Game objects------")]
    public Transform carro;


    [Header("------Propiedades de movimiento------")]
    public float timpoDe_Incrementacion = 0.02f;
    public float timpoDe_Decrementacion = 0.1f;
    public float incremento;
    public float velocidad = 1;
    public bool moving;
    public string directionMovement;

    [Header("------Restricciones de movimiento------")]
    public bool canMove;


    void Update()
    {
        
        if (canMove && moving) 
        {
            RiseVelocity();
            MovementFunction();

        }
        else if(canMove && !moving) 
        {
            DecreceVelocity();
            MovementFunction();
        }

        else if (!canMove && !moving)
        {
            DecreceVelocity();
            MovementFunction();
        }


        //PC
        if (Input.GetKey(KeyCode.A))
        {
            canMove = true;
            moving = true;
            directionMovement = "left";
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            canMove = false;
            moving = false;
            directionMovement = "left";
        }



        if (Input.GetKey(KeyCode.D))
        {
            canMove = true;
            moving = true;
            directionMovement = "right";
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            canMove = false;
            moving = false;
            directionMovement = "right";
        }

        if (Input.GetKey(KeyCode.W))
        {
            canMove = true;
            moving = true;
            directionMovement = "front";
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            canMove = false;
            moving = false;
            directionMovement = "front";
        }


        if (Input.GetKey(KeyCode.S))
        {
            canMove = true;
            moving = true;
            directionMovement = "back";
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            canMove = false;
            moving = false;
            directionMovement = "back";
        }
    }

    void MovementFunction() 
    {
        switch (directionMovement)
        {
            case "back":
                this.transform.position += -Vector3.right * incremento * Time.deltaTime * velocidad;
                break;

            case "front":
                this.transform.position += Vector3.right * incremento * Time.deltaTime * velocidad;
                break;

            case "left":
                carro.transform.position += Vector3.forward * incremento * Time.deltaTime * velocidad;
                break;

            case "right":
                carro.transform.position += -Vector3.forward * incremento * Time.deltaTime * velocidad;
                break;

            default:
                break;
        }
    }
    public void setDirection(string dir) 
    {
        //DirectionMovement tmp = (DirectionMovement)Enum.Parse(typeof(DirectionMovement), dir, true);
        directionMovement = dir;
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

        if (directionMovement == "front") 
        {
            if (this.transform.position.x > 29)
            {
                
                velocidad = 0.5f;

                if (this.transform.position.x > 32)
                {
                    velocidad = 0;
                }
            }
            else
            {
                velocidad = 1;
            }
        }


        else if (directionMovement == "back")
        {
            if (this.transform.position.x < -29)
            {
                velocidad = 0.5f;

                if (this.transform.position.x < -32)
                {
                    velocidad = 0;
                }
            }
            else
            {
                velocidad = 1;
            }
        }


        else if (directionMovement == "left")
        {
            if (carro.transform.position.z > 9)
            {
                velocidad = 0.5f;

                if (carro.transform.position.z > 12)
                {
                    velocidad = 0;
                }
            }
            else
            {
                velocidad = 1;
            }
        }

        else if(directionMovement == "right") 
        {
            if (carro.transform.position.z < -9)
            {
                velocidad = 0.5f;

                if (carro.transform.position.z < -12)
                {
                    velocidad = 0;
                }
            }
            else
            {
                velocidad = 1;
            }
        }


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
