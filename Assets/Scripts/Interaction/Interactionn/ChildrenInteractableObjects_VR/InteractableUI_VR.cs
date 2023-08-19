using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableUI_VR : InteractuableObject_VR
{
    public AccesoriosUIData_VR myData;
    public bool buttonSelected;
    public GameObject Panel;
    public bool attachPanel;
    private void Start()
    {
        base.updateText(myData.pressButtonDialog);
        this.eventWrapperBUTTON.WhenSelect.AddListener(selectButton);
    }
    public void selectButton()
    {
        this.myData.usado = true;
        buttonSelected = !buttonSelected;

        if (buttonSelected)
        {
            openPanel();
            base.updateText(myData.unpressButtonDialog);
        }
        else
        {
            closePanel();
            base.updateText(myData.pressButtonDialog);
        }
    }

    public void openPanel() 
    {
        CanvasManager.instance.showPanel(this.Panel, attachPanel);
    }
    public void closePanel() 
    {
        CanvasManager.instance.closePanel(this.Panel);
    }

}
