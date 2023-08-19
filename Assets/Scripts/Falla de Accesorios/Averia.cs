using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Averia : MonoBehaviour
{
    public AccesoriosData myData;
    public bool fallar;

    static bool onlyOneSimulationEnd;
    public void Start()
    {
        fallar = myData.examinado ? false : true;
    }

    public virtual void restauracionFunction() 
    {

    }
    public virtual void fallarFunction() 
    {

    }

    public void finalizarSimulacion() 
    {
        if (!onlyOneSimulationEnd) 
        {
            Debug.Log(myData.nombre + "llame a la falla");
            StartCoroutine(endSimulation());
            onlyOneSimulationEnd = true;
        }

    }
    private IEnumerator endSimulation() 
    {
        yield return new WaitForSecondsRealtime(12);
        MenuController.MenuControllerInstance.showGameOverScreen();
    }
}
