using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respuesta : MonoBehaviour
{
    public InteractuableRigger rigger;

    public Walking_Rigger_Action rigger_;
    public bool respuestaCorrecta;
    public static bool primeraRespuesta;
    void Start()
    {
        primeraRespuesta = false;
    }
    public void presionLaCorrecta() 
    {
        if (!primeraRespuesta)
        {
            Debug.Log(respuestaCorrecta);
            if (respuestaCorrecta)
            {
                //rigger.empezarCaminarFunction();
                rigger_.empezarCaminarFunction();
            }
            else 
            {

            }
            primeraRespuesta = true;
            //logica de enviar los datos al excel supongo
        }
        else 
        {

        }
    }
}
