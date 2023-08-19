using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier_Inicial : Notifier
{
    private void Start()
    {
        this.funcMiddle.AddListener(onNotify);
    }

    public override void onNotify()
    {
        StartCoroutine(waitAndNotify());
    }


    IEnumerator waitAndNotify() 
    {
        yield return new WaitForSeconds(10);
        referenceCanvas.activExitAnimation();
        base.onNotify();
    }
}
