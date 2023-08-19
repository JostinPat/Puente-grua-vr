using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableDocuments : InteractuableObject
{
    public GameObject ImagenCheckList;


    public GameObject inputFieldPrefab;
    public GameObject ObjetoPanel;
    public RectTransform PanelRectTransform;
    new void Start()
    {
        base.Start();
        ObjetoPanel = GameObject.FindGameObjectWithTag("Panel");
        PanelRectTransform = ObjetoPanel.GetComponent<RectTransform>();
        this.myType = TypeInteractionObject.interactuable;
    }

    void Update()
    {
        if (this.enUso_) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(Input.mousePosition);
                Vector2 screenPos2d = new Vector2(screenPos.x, screenPos.y);
                Vector2 anchoPos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(PanelRectTransform, screenPos2d, Camera.main, out anchoPos);

                GameObject instancia = Instantiate(inputFieldPrefab, Vector3.zero, Quaternion.identity);
                instancia.transform.SetParent(ObjetoPanel.transform);
                instancia.GetComponent<RectTransform>().localPosition = anchoPos;
                instancia.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                instancia.transform.SetParent(ImagenCheckList.transform);
            }
        }
        
    }
    public override void FirstActionWith(Transform padre)
    {
        MenuController.MenuControllerInstance.UI_forObjects.overrideText("Escribir (F)");
        MenuController.MenuControllerInstance.UI_forObjects.addText("Soltar (TAB)");


        base.FirstActionWith(padre);
    }

    public override void drop()
    {
        //DESACTIVAMOS EL SCRIPT DE MENU
        MenuController.MenuControllerInstance.enabled = true;



        base.drop();
        MenuController.MenuControllerInstance.UI_forObjects.deleteTextsUI();
        this.enUso_ = false;
        accionesAntesYDespuesUsarDocumento(enUso_);

        this.transform.SetParent(null);
    }

    public override void UsarObject()
    {
        //DESACTIVAMOS EL SCRIPT DE MENU
        MenuController.MenuControllerInstance.enabled = false;

        this.enUso_ = true;
        accionesAntesYDespuesUsarDocumento(enUso_);
    }

    public void accionesAntesYDespuesUsarDocumento(bool enUso_)
    {
        this.movimientoPlayer.enabled = !enUso_;
        ImagenCheckList.SetActive(enUso_);
        if (enUso_ == true)
        {
            this.camaraPlayer.offsetConCheckList = -20;//ponemos la camara apuntando hacia arriba ya sabes por ese problemita uwu BUGGGGGGGGGGG
            this.camaraPlayer.sensitivity = 0;//"bloqueo movimiento de camara" poniendo la sensibilidad en 0 y no se mueve
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else 
        {
            this.camaraPlayer.offsetConCheckList = 0;
            this.camaraPlayer.sensitivity = 2;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
