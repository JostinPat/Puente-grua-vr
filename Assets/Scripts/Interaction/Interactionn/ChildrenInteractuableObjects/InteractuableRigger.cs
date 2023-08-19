using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableRigger : InteractuableObject
{
    public PickObject pickObjectReference;

    public bool empezarCaminar;
    public GameObject panelPreguntas;

    public GameObject walk;
    public GameObject idle;
    public Transform tarjet;
    new void Start()
    {
        base.Start();

        idle.gameObject.SetActive(true);
        walk.gameObject.SetActive(false);
        empezarCaminar = false;
        panelPreguntas.SetActive(false);
        this.myType = TypeInteractionObject.observable;
    }

    void Update()
    {
        if (empezarCaminar) 
        {
            this.transform.LookAt(tarjet);
            this.transform.position = Vector3.MoveTowards(transform.position, tarjet.position, 0.01f);
            if (Vector3.Distance(transform.position, tarjet.position) < 0.1f) 
            {
                idle.gameObject.SetActive(true);
                walk.gameObject.SetActive(false);
                empezarCaminar = false;
            }
        }

    }

    public void empezarCaminarFunction() 
    {
        pickObjectReference.interactuableObject = null;
        pickObjectReference.interactuandoConObjeto = false;
        this.drop();
        accionesAntesYDespuesHablar(false);

        idle.gameObject.SetActive(false);
        walk.gameObject.SetActive(true);
        empezarCaminar = true;
    }

    public void accionesAntesYDespuesHablar(bool enUso_)
    {
        this.movimientoPlayer.enabled = !enUso_;
        panelPreguntas.gameObject.SetActive(enUso_);
        if (enUso_ == true)
        {
            this.camaraPlayer.sensitivity = 0;//"bloqueo movimiento de camara" poniendo la sensibilidad en 0 y no se mueve
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            this.camaraPlayer.sensitivity = 2;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public override void FirstActionWith()
    {
        MenuController.MenuControllerInstance.UI_forObjects.overrideText("Dejar de Hablar (TAB)");
        enUso_ = true;
        accionesAntesYDespuesHablar(enUso_);
    }

    public override void drop()
    {
        base.drop();
        MenuController.MenuControllerInstance.UI_forObjects.deleteTextsUI();
        enUso_ = false;
        accionesAntesYDespuesHablar(enUso_);
    }
}
