using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;


//FUNCIONA PERO HAY MUCHO BLINK, PARPADEA EL OBJETO WTF
public class SnapBotoneraToSurface : MonoBehaviour
{
    [SerializeField] InteractableUnityEventWrapper wrapperBotonera;
    public float AlturaJugador_SnapPoint = 2;
    private Vector3 snapPOS;
    public float speedSnap;

    public bool simulate;//grabbing



    public Rigidbody myRb;

    private void Start()
    {
        wrapperBotonera = this.GetComponent<InteractableUnityEventWrapper>();
        wrapperBotonera.WhenSelect.AddListener(BOOLThisSimulationHelper);
        wrapperBotonera.WhenUnselect.AddListener(BOOLThisSimulationHelper);


        simulate = true;
    }
    public void BOOLThisSimulationHelper() 
    {
        simulate = !simulate;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            if(this.transform.position.y > 2) 
            {
                Debug.Log("no llego");
                myRb.velocity = -Vector3.up*speedSnap;
            }
            else 
            {
                Debug.Log("llegue");
            }
        }
        //if (simulate)
        //{
        //    snapPOS = this.transform.position;
        //    snapPOS.y = 2;

        //    this.transform.position = Vector3.MoveTowards(this.transform.position, snapPOS, speedSnap * Time.deltaTime);
        //}

    }

}
