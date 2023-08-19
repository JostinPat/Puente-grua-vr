using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuertaEscenaIzaje1 : MonoBehaviour
{

    public GameOverScreen gameOverScreen;
    public string nombreFile;

    public bool onlyOne;


    //VARIABLES DE CONTROL
    public CaidasManager caidasManager;

    public bool ProcesobobinasMarrones;
    public float contadorBobinasMarrones;

    public bool ProcesobobinasDeAcero;
    public float contadorBobinasDeAcero;


    private void Start()
    {
        gameOverScreen = MenuController.MenuControllerInstance.GetComponent<GameOverScreen>();
        ProcesobobinasMarrones = false;
        ProcesobobinasDeAcero = false;
        contadorBobinasMarrones = 0;
        contadorBobinasDeAcero = 0;


        //gameOverScreenCreation();
    }

    private void Update() 
    {
        if (ProcesobobinasDeAcero) 
        {
            contadorBobinasDeAcero += Time.deltaTime;
            LevelScore.instance.updateScores(ScoreData_Enum.T_traslado, (int)contadorBobinasDeAcero);
        }

        if (ProcesobobinasMarrones) 
        {
            contadorBobinasMarrones += Time.deltaTime;
            LevelScore.instance.updateScores(ScoreData_Enum.T_apilado, (int)contadorBobinasMarrones);
        }
    }
    public void gameOverScreenCreation() 
    {
        List<Averia> objetosAveriados = FindObjectsOfType<Averia>().ToList();
        List<string> nombreDeNoExaminados = new List<string>();
        foreach (var item in objetosAveriados)
        {
            if (item.myData.examinado == false)
            {
                nombreDeNoExaminados.Add(item.myData.nombre);
            }
        }
        gameOverScreen.createGameOverScreen(nombreDeNoExaminados);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && onlyOne == false)
        {
            SendData();
        }
    }

    public void SendData() 
    {
        ExcelWriter.CreateFile(nombreFile);



        ExcelWriter.WriteCVS("**** ESTADISTICAS EN EL PRIMER NIVEL ****");
        ExcelWriter.WriteCVS(" ");
        ExcelWriter.WriteCVS("**** Tiempo para traslado y apilamiento de bobinas de acero ****");
        ExcelWriter.WriteCVS(contadorBobinasDeAcero.ToString());

        ExcelWriter.WriteCVS("**** Tiempo para traslado y apilamiento de bobinas de laminado en caliente ****");
        ExcelWriter.WriteCVS(contadorBobinasMarrones.ToString());

        ExcelWriter.WriteCVS("**** Numero de caidas de bobinas ****");
        ExcelWriter.WriteCVS(caidasManager.contadorCaidas.ToString());

        ExcelWriter.WriteCVS(" ");
        GameManager.GameManagerInstance.loadNextScene();
        onlyOne = true;
    }
}
