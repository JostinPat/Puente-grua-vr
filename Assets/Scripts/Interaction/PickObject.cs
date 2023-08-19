using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    public InteractuableObject interactuableObject;

    public bool interactuandoConObjeto;
    public bool viendoBotonera;
    void Update()
    {
        if (interactuableObject != null) 
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                interactuableObject.drop();
                interactuableObject = null;
                interactuandoConObjeto = false;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                interactuableObject.UsarObject();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 && !interactuableObject)
        {
            interactuableObject = other.gameObject.GetComponent<InteractuableObject>();


            MenuController.MenuControllerInstance.UI_forObjects.addText(interactuableObject.myData.myTextUI.ToString() + " (E)");
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            //UI.instance.showMessage(other.gameObject.GetComponent<PickObject>().id);

            if (interactuableObject != null && Input.GetKeyDown(KeyCode.E) && !interactuandoConObjeto)
            {
                interactuandoConObjeto = true;
                firstActionofObjects(interactuableObject);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8 && interactuableObject != null)
        {
            if (!interactuandoConObjeto) 
            {
                interactuandoConObjeto = false;
                interactuableObject = null;
                MenuController.MenuControllerInstance.UI_forObjects.deleteTextsUI();
            }
        }
    }



    public void firstActionofObjects(InteractuableObject a) 
    {
        if (a.myType == TypeInteractionObject.interactuable)
        {
            a.FirstActionWith(this.transform);//se va a la mano
        }
        else if (a.myType == TypeInteractionObject.observable) 
        {
            a.FirstActionWith();
        }
    }

}
