using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier_Menu : Notifier
{
    bool done;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.Start) && !done) 
        {
            done = true;
            onNotify();
        }
    }
    public override void onNotify()
    {
        referenceCanvas.activExitAnimation();
        base.onNotify();
    }

}
