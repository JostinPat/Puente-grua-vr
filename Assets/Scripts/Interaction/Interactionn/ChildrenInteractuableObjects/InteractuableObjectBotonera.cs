using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableObjectBotonera : InteractuableObject
{
    public OrbitingCamera cameraOrbiting;
    public Transform pivoteParaCamara;
    public Rigidbody rb;
    public bool watching;

    [Header("Interaccion con botonera")]
    [SerializeField] private CraneController_ craneReference;


    new void Start()
    {
        craneReference = FindObjectOfType<CraneController_>();

        base.Start();
        if (pivoteParaCamara == null) //VERIFCAMOS SI TIENE UN PIVOTE POR DEFECTO
        {
            pivoteParaCamara = this.gameObject.transform;
        }
    }

    void Update()
    {
        
    }
    public override void FirstActionWith(Transform padre)
    {
        craneReference.activar_desactivar_Script(true);


        rb.isKinematic = true;
        this.enUso_ = true;
        MenuController.MenuControllerInstance.UI_forObjects.overrideText("Examinar (F)");
        MenuController.MenuControllerInstance.UI_forObjects.addText("Soltar (TAB)");
        base.FirstActionWith(padre);
    }
    public override void UsarObject()
    {
        craneReference.activar_desactivar_Script(false);



        if (!watching) 
        {
            FocusCamera(pivoteParaCamara);
            watching = true;
        }
            
    }
    public override void drop()
    {
        craneReference.activar_desactivar_Script(false);


        base.drop();
        MenuController.MenuControllerInstance.UI_forObjects.deleteTextsUI();
        rb.isKinematic = false;
        this.enUso_ = false;
        this.transform.SetParent(null);
        if (watching) 
        {
            this.watching = false;
            this.camaraPlayer.sensitivity = 2;
            this.movimientoPlayer.enabled = true;
            cameraOrbiting.Tarjet = null;
            cameraOrbiting.activateDesactivateCamera();
        }
    }
    public void FocusCamera(Transform tarjet)
    {
        this.camaraPlayer.sensitivity = 0;
        this.movimientoPlayer.enabled = false;
        cameraOrbiting.activateDesactivateCamera();
        cameraOrbiting.Tarjet = tarjet;
    }

 
}
