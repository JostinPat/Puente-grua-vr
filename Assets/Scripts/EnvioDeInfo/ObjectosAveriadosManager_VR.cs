using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectosAveriadosManager_VR : MonoBehaviour
{
    public List<InteractuableObject_VR> listaObjetosInteractuables;

    public List<InteractableStardard_VR> listaObjetos_EXAMINADOS;
    public List<InteractableStardard_VR> listaObjetos_NO_REPORTADOS;
    public List<InteractableStardard_VR> listaObjetos_NO_EXAMINADOS;
    public List<InteractableUI_VR> listaObjetos_NO_USADO;


    public List<string> nombresDeObjetosNOEXAMINADOS;
    void Start()
    {
        findObjectsInteractuable();
    }

    public void filterExaminedObjects()
    {
        foreach (InteractuableObject_VR item in listaObjetosInteractuables)
        {

            if (item is InteractableStardard_VR)//ver type
            {
                InteractableStardard_VR tmp = item as InteractableStardard_VR;//cast

                if (tmp.myData.examinado)
                {
                    listaObjetos_EXAMINADOS.Add(tmp);
                }

                else
                {
                    nombresDeObjetosNOEXAMINADOS.Add(tmp.myData.nombre);
                    listaObjetos_NO_EXAMINADOS.Add(tmp);
                }

                if (!tmp.myData.reported)
                {
                    listaObjetos_NO_REPORTADOS.Add(tmp);
                }
            }

            else if (item is InteractableUI_VR)
            {
                InteractableUI_VR tmp = item as InteractableUI_VR;

                //tmp.myData.usado = false;

                if (!tmp.myData.usado)
                {
                    listaObjetos_NO_USADO.Add(tmp);
                }
            }

        }
    }

    public void findObjectsInteractuable()
    {
        listaObjetosInteractuables = FindObjectsOfType<InteractuableObject_VR>().ToList();

        foreach (InteractuableObject_VR item in listaObjetosInteractuables)
        {
            if(item is InteractableStardard_VR) 
            {
                InteractableStardard_VR tmp = item as InteractableStardard_VR;
                tmp.myData.examinado = false;
                tmp.myData.reported = false;
            }
            else if(item is InteractableUI_VR) 
            {
                InteractableUI_VR tmp = item as InteractableUI_VR;
                tmp.myData.usado = false;
            }

        }
    }
}
