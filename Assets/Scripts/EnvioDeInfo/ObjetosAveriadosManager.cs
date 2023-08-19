using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjetosAveriadosManager : MonoBehaviour
{
    public List<InteractuableObject> listaObjetosInteractuables;

    public List<InteractuableObject> listaObjetosEXAMINADOS;
    public List<InteractuableObject> listaObjetosNOEXAMINADOS;
    public List<string> nombresDeObjetosNOEXAMINADOS;
    void Start()
    {
        findObjectsInteractuable();
    }
    public void filterExaminedObjects() 
    {
        foreach (InteractuableObject item in listaObjetosInteractuables)
        {
            if (item.myData.examinado)
            {
                listaObjetosEXAMINADOS.Add(item);
            }
            else 
            {
                nombresDeObjetosNOEXAMINADOS.Add(item.myData.nombre);
                listaObjetosNOEXAMINADOS.Add(item);
            }
        }
    }

    public void findObjectsInteractuable() 
    {
        listaObjetosInteractuables = FindObjectsOfType<InteractuableObject>().ToList();

        foreach (InteractuableObject item in listaObjetosInteractuables)
        {
            item.myData.examinado = false;
        }
    }
}
