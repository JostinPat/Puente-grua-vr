using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier_Button : Notifier
{
    bool done;
    public override void onNotify()
    {

        referenceCanvas.activExitAnimation();

        base.onNotify();
    }
}
