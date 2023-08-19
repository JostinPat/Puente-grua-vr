using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Notifier : MonoBehaviour, IObserver
{
    public UnityEvent funcMiddle;
    //public UnityEvent funcStart;
    public UnityEvent funcEnd;
    //public int ID;
    public CanvasManager_CallerDialogs referenceCanvas;
    public string dialogoEntrada;
    public string dialogoIntermedio;
    public string dialogoSalida;
    public Sprite imagenDeReferencia;
    public virtual void onNotify()
    {
        Destroy(this);
        Debug.Log("YA HICIERON ESTA ACCION");
    }

}
