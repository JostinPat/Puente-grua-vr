using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [SerializeField] OVRPlayerController referencePlayer;
    [SerializeField] GameObject panelMain;
    public Vector3 offsetFromPlayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        panelMain.gameObject.SetActive(false);
    }


    public void showPanel(GameObject Panel, bool attachToBdy)
    {
        panelMain.gameObject.SetActive(true);
        stopPlayer();
        Panel.gameObject.SetActive(true);//cuando los paneles estan deentro de el

        if (attachToBdy) 
        {
            this.transform.SetParent(referencePlayer.transform);
            this.transform.position = Vector3.zero;
            this.transform.localRotation = Quaternion.identity;
            this.transform.localPosition = offsetFromPlayer;
        }
        else
        {
            this.transform.rotation = referencePlayer.transform.rotation;
            this.transform.position = referencePlayer.transform.position + new Vector3(0, offsetFromPlayer.y,0) + referencePlayer.transform.forward* offsetFromPlayer.z;
        }


    }

    public void closePanel(GameObject Panel)
    {
        resumePlayer();
        Panel.gameObject.SetActive(false);
        panelMain.gameObject.SetActive(false);
        this.transform.SetParent(null);
    }

    public void showCanvas(GameObject Panel) 
    {
        panelMain.gameObject.SetActive(true);
        referencePlayer.Acceleration = 0;
        Panel.transform.rotation = referencePlayer.transform.rotation;

        Panel.transform.position = referencePlayer.transform.position + new Vector3(0, offsetFromPlayer.y, 0) + referencePlayer.transform.forward * offsetFromPlayer.z;

        Panel.transform.SetParent(referencePlayer.transform);
        //this.transform.localPosition = Vector3.zero;
        //this.transform.localRotation = Quaternion.identity;
        //this.transform.localPosition = offsetFromPlayer;
    }

    public void attachToPlayer() 
    {
        this.transform.SetParent(referencePlayer.transform);
        this.transform.position = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
        this.transform.localPosition = offsetFromPlayer;
    }

    public void unAttachToPlayer() 
    {
        this.transform.SetParent(null);
    }



    public void stopPlayer() 
    {
        referencePlayer.Acceleration = 0;
    }

    public void resumePlayer()
    {
        referencePlayer.Acceleration = 0.1f;
    }


    public void PutObjetInFrontOfPlayer(GameObject go)
    {
        go.transform.rotation = referencePlayer.transform.rotation;
        go.transform.position = referencePlayer.transform.position + new Vector3(0, offsetFromPlayer.y, 0) + referencePlayer.transform.forward * offsetFromPlayer.z;
    }

    /*public void active() 
    {
        this.transform.SetParent(referencePlayer.transform);
        this.transform.localPosition = new Vector3(0.3f, 0, 5);
    }*/

}
