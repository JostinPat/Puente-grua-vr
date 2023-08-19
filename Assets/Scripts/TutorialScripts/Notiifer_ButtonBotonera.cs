using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notiifer_ButtonBotonera : Notifier
{
   
    public override void onNotify()
    {

        referenceCanvas.activExitAnimation();

        base.onNotify();
    }
}
