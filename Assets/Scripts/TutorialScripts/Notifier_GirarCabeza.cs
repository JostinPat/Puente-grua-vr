using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier_GirarCabeza : Notifier
{
    public MeshRenderer [] objetosConShader;
    public Transform cam;
    public bool done;
    private void Update()
    {
        if (!done)
        {
            float angle = Vector3.Angle(cam.transform.forward, this.transform.position - cam.transform.position);

            Debug.Log(angle);
            if (angle < 10)
            {
                onNotify();
                done = true;
            }
        }

    }
    public override void onNotify()
    {
        for (int i = 0; i < objetosConShader.Length; i++)
        {
            objetosConShader[i].material = null;
        }
        referenceCanvas.activExitAnimation();


        base.onNotify();
    }
}
