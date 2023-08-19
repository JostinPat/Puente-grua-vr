using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveriaRigger : Averia
{
    public GameObject idle;
    public GameObject walk;
    public GameObject trash;
    public GameObject buggy;


    public List<GameObject> cinematica;
    new void Start()
    {
        walk.gameObject.SetActive(false);
        base.Start();
        if (this.fallar && GameManager.GameManagerInstance.secuenciaNiveles != 0)
        {
            fallarFunction();

            base.finalizarSimulacion();//FINALIZAMOPS SIMULACION POR FALLO GRAVE
        }
        else
        {
            restauracionFunction();
        }
    }

    public override void fallarFunction()
    {
        buggy.gameObject.SetActive(false);
    }

    public override void restauracionFunction()
    {
        trash.gameObject.SetActive(false);
        buggy.gameObject.SetActive(true);
    }
}
