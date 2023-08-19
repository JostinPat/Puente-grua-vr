using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Notifier_Movement : Notifier
{
    bool done;

    private void Start()
    {

    }
    public override void onNotify()
    {
        Debug.Log("ya camino y roto");
        base.onNotify();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !done)
        {
            referenceCanvas.activExitAnimation();
            base.onNotify();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !done)
        {
            referenceCanvas.activExitAnimation();
            base.onNotify();
        }
    }
}
