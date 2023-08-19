using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableObjectObserve : InteractuableObject
{
    public OrbitingCamera cameraOrbiting;
    public Transform pivoteParaCamara;
    new void Start()
    {
        base.Start();
        this.myType = TypeInteractionObject.observable;
        //cameraOrbiting = FindObjectOfType<OrbitingCamera>();
        if (pivoteParaCamara == null) //VERIFCAMOS SI TIENE UN PIVOTE POR DEFECTO
        {
            pivoteParaCamara = this.gameObject.transform;
        }
    }
        
    public override void FirstActionWith()
    {
        MenuController.MenuControllerInstance.UI_forObjects.overrideText("Dejar de Examinar (TAB)");


        FocusCamera(pivoteParaCamara);
    }

    public override void drop()
    {
        base.drop();
        MenuController.MenuControllerInstance.UI_forObjects.deleteTextsUI();


        this.camaraPlayer.sensitivity = 2;
        this.movimientoPlayer.enabled = true;
        cameraOrbiting.Tarjet = null;
        cameraOrbiting.activateDesactivateCamera();
    }

    public void FocusCamera(Transform tarjet)
    {
        this.camaraPlayer.sensitivity = 0;
        this.movimientoPlayer.enabled = false;
        cameraOrbiting.activateDesactivateCamera();
        cameraOrbiting.Tarjet = tarjet;
    }

}
