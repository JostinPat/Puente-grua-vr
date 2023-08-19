using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AveriaManager : MonoBehaviour
{
    public List<Averia> objetosAveriados;
    void Start()
    {
        /*objetosAveriados = FindObjectsOfType<Averia>().ToList();
        foreach (Averia item in objetosAveriados)
        {
            if (!item.myData.examinado) 
            {
                Debug.Log(item.myData.nombre + "No fue examiando");
            }
            else
            {
                Debug.Log(item.myData.nombre + "fue examiando");
            }
        }*/
    }
    void Update()
    {
        
    }
}
