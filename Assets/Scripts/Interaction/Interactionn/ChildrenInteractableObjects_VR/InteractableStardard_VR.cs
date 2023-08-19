using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableStardard_VR : InteractuableObject_VR
{
    public AccesoriosStandardData_VR myData;

    private void Start()
    {
        base.updateText(myData.pressButtonDialog);
        this.eventWrapperBUTTON.WhenSelect.AddListener(selectButton);


    }
    public void selectButton()
    {
        this.myData.reported = !this.myData.reported;
        this.myData.examinado = true;

        if (this.myData.reported) 
        {
            base.updateText(myData.unpressButtonDialog);

        }
        else
        {
            base.updateText(myData.pressButtonDialog);
        }

    }

    public void deselectButton()
    {

    }
}
