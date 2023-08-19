using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddForceBobina : MonoBehaviour
{
    public GameObject bobinaEmpujadora;
    public GameObject tacoFake1;
    public GameObject tacoFake2;
    public Vector3 moveToward;
    public float distance;

    public bool empezarContador;
    public float segundos;
    public GameObject contador;
    public TextMeshPro textContador;

    private void Start()
    {
        moveToward = bobinaEmpujadora.transform.position + bobinaEmpujadora.transform.forward * distance;
    }

    private void Update()
    {
        if (empezarContador) 
        {
            segundos -= Time.deltaTime;
            textContador.text = segundos.ToString("0.00") + " para caida";
            if(segundos <= 0) 
            {
                forceeeeee();
                empezarContador = false;
                contador.gameObject.SetActive(false);
            }
            else 
            {
                contador.gameObject.SetActive(true);
            }
        }
    }
    public void empezarContadorFunction()
    {
        contador.gameObject.SetActive(true);
        tacoFake1.gameObject.SetActive(true);
        tacoFake2.gameObject.SetActive(true);
        empezarContador = true;
    }

    public void detenerContadorFunction() 
    {
        contador.gameObject.SetActive(false);
        empezarContador = false;
    }
    public void forceeeeee() 
    {
        bobinaEmpujadora.transform.position = Vector3.MoveTowards(bobinaEmpujadora.transform.position, moveToward, 1);
    }
}
