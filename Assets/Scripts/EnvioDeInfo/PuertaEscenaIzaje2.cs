using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaEscenaIzaje2 : MonoBehaviour
{
    public string nombreFile;
    public bool onlyOne;
    public CaidasManager caidasManager;
    public SanwichController controlDeCargasReference;

    public GameObject panelSimuladorTermino;
    public LevelDone levelDoneReference;
    //ESTO PASA CUANDO CRUZAMOS LA PUERTA, hace el excel, en examinacion si manda el correo


    private void Update()
    {
        if(levelDoneReference.doneTasks == 1 && !onlyOne) 
        {
            panelSimuladorTermino.gameObject.SetActive(true);
            sendData();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Player") && !onlyOne)
        //{
        //    panelSimuladorTermino.gameObject.SetActive(true);
        //    sendData();
        //}
    }
    public void sendData() 
    {
        if (!onlyOne) 
        {
            ExcelWriter.CreateFile(nombreFile);

            ExcelWriter.WriteCVS("**** ESTADISTICAS EN DEL SEGUNDO NIVEL ****");
            ExcelWriter.WriteCVS(" ");

            ExcelWriter.WriteCVS("**** Tiempo para traslado de las cargas ****");
            ExcelWriter.WriteCVS(controlDeCargasReference.tiempoDeIzaje.ToString());

            ExcelWriter.WriteCVS("**** Numero de caidas de la carga ****");
            ExcelWriter.WriteCVS(caidasManager.contadorCaidas.ToString());

            ExcelWriter.WriteCVS("**** Numero de intentos de izaje con el aditamento NO alineado con la carga ****");
            ExcelWriter.WriteCVS(controlDeCargasReference.contadorDeIzajesNoAlineados.ToString());

            ExcelWriter.WriteCVS("**** Numero de intentos de pendulos con la carga****");
            ExcelWriter.WriteCVS(controlDeCargasReference.contadorPendulos.ToString());


            ExcelWriter.WriteCVS(" ");

            onlyOne = true;

            //MenuController.MenuControllerInstance.showFinalScreen();
            //SCREEN FINAL

        }
    }
}
