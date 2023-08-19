using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveriaBotonera : Averia
{
    public HideButton referenceHideButton;
    new void Start()
    {
        base.Start();

        Debug.Log(fallar && GameManager.GameManagerInstance.secuenciaNiveles != 0);

        if (fallar && GameManager.GameManagerInstance.secuenciaNiveles != 0)//ESTO DEL GAMEMANAGER PARA PODAMOS TESTEAR CON TRANQUILIDAD ANAHSIE
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
        referenceHideButton.dejarAveriado();
    }

    public override void restauracionFunction()
    {
        referenceHideButton.activarTodosBotones();
    }
}
