using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier_Write : Notifier
{
    public GameObject checkList_panel;

    public bool presionoB;
    public bool presionoTriggerPrimary;
    public WriteCheckList reference;



    public bool abrirCanvas;
    public void activarCanvasEscribir()
    {
        if (!abrirCanvas)
        {
            CanvasManager.instance.showPanel(checkList_panel, false);
        }
        else
        {
            CanvasManager.instance.closePanel(checkList_panel);
            if(presionoTriggerPrimary && reference.transform.childCount > 0) 
            {
                onNotify();
            }
        }

        abrirCanvas = !abrirCanvas;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            presionoB = true;
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && presionoB)
        {
            presionoTriggerPrimary = true;
        }
    }
    public override void onNotify()
    {
        referenceCanvas.activExitAnimation();
        base.onNotify();
    }
}
