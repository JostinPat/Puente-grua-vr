using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PuertaEscenaExaminacion : MonoBehaviour
{
    //EXCEL
    public string nombreFile;
    public GameObject objetoDondeSeGuardanLosTextosParaExcel;
    //public ObjetosAveriadosManager objetosAveriadosManager_;
    public ObjectosAveriadosManager_VR objetosAveriadosManager_VR;

    public bool onlyOne;

    //test
    public GameObject cubo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && onlyOne == false)
        {
            createAndSendData();
            onlyOne = true;
            GameManager.GameManagerInstance.loadNextScene();
        }
    }

    [ContextMenu("Create excel data - FUNCTION")]
    public void createAndSendData() 
    {
        objetosAveriadosManager_VR.filterExaminedObjects();
        ExcelWriter.CreateFile(nombreFile);


        ExcelWriter.WriteCVS("**** OBJETOS EXAMINADOS POR EL OPERARIO ****");

        for (int i = 0; i < objetosAveriadosManager_VR.listaObjetos_EXAMINADOS.Count; i++)
        {
            string texto = objetosAveriadosManager_VR.listaObjetos_EXAMINADOS[i].myData.nombre;
            string texto2 = objetosAveriadosManager_VR.listaObjetos_EXAMINADOS[i].myData.falla;

            string formated = string.Format("Nombre del accesorio: {0} || Falla: {1}", texto, texto2);
            ExcelWriter.WriteCVS(formated);
        }
        ExcelWriter.WriteCVS(" ");



        ExcelWriter.WriteCVS("**** OBJETOS NO EXAMINADOS POR EL OPERARIO ****");

        for (int i = 0; i < objetosAveriadosManager_VR.listaObjetos_NO_EXAMINADOS.Count; i++)
        {
            string texto = objetosAveriadosManager_VR.listaObjetos_NO_EXAMINADOS[i].myData.nombre;
            string texto2 = objetosAveriadosManager_VR.listaObjetos_NO_EXAMINADOS[i].myData.falla;

            string formated = string.Format("Nombre del accesorio: {0} || Falla: {1}", texto, texto2);
            ExcelWriter.WriteCVS(formated);
        }
        ExcelWriter.WriteCVS(" ");




        ExcelWriter.WriteCVS("**** OTRAS METRICAS ****");

        string formatedRigger = "Operario interactuo con rigger";
        string formatedChecklist = "Operario no uso el checklist";

        for (int i = 0; i < objetosAveriadosManager_VR.listaObjetos_NO_USADO.Count; i++)
        {
            if (!objetosAveriadosManager_VR.listaObjetos_NO_USADO[i].myData.usado)
            {
                if (objetosAveriadosManager_VR.listaObjetos_NO_USADO[i].myData.nombre == "Rigger")
                {
                    formatedRigger = "Operario no interactuo con el rigger";
                    ExcelWriter.WriteCVS(formatedRigger);
                }
                else if (objetosAveriadosManager_VR.listaObjetos_NO_USADO[i].myData.nombre == "Checklist")
                {
                    formatedChecklist = "Operario no uso el checklist";
                    ExcelWriter.WriteCVS(formatedChecklist);
                }
            }
        }
        ExcelWriter.WriteCVS(" ");




        ExcelWriter.WriteCVS("**** ANOTACIONES EN EL CHECKLIST ****");

        for (int i = 0; i < objetoDondeSeGuardanLosTextosParaExcel.transform.childCount; i++)//CARGO LOS TEXTOS EN EL EXCECL
        {
            string texto = objetoDondeSeGuardanLosTextosParaExcel.transform.GetChild(i).GetComponent<TMP_InputField>().text;
            ExcelWriter.WriteCVS(texto);
        }
        ExcelWriter.WriteCVS(" ");


        //ExcelWriter.sendMail();//para el programa tal vez en un thread paralelo


        objetosAveriadosManager_VR.listaObjetosInteractuables.Clear();
        objetosAveriadosManager_VR.listaObjetos_EXAMINADOS.Clear();
        objetosAveriadosManager_VR.listaObjetos_NO_EXAMINADOS.Clear();

    }

}
