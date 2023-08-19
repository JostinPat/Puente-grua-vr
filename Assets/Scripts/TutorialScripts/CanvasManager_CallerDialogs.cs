using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CanvasManager_CallerDialogs : MonoBehaviour
{
    [SerializeField] OVRPlayerController oVRPlayerController;
    [SerializeField] Animator anim;
    [SerializeField] TextMeshProUGUI texto_TUTO;
    [SerializeField] Image image_TUTO;

    [SerializeField] ParticleSystem particle;

    [SerializeField] Notifier[] _observers;
    private int id_Observer;


    private void Start()
    {

        setVariables();
        activeStartAnimation();

    }

    void addOne_ID_Observer()
    {
        id_Observer++;
        if (id_Observer > _observers.Length)
        {
            //aca acaba todo el tutorial
        }
    }
    public void activeStartAnimation()
    {
        //if(id_Observer == _observers.Length) 
        //{
        //    Debug.LogError("NO HAY MAS OBSERVERS");
        //    return;
        //}

        anim.SetTrigger("Entry");
        oVRPlayerController.EnableLinearMovement = false;
        oVRPlayerController.EnableRotation = false;

        _observers[id_Observer].enabled = true;
        updateMessage(_observers[id_Observer].dialogoEntrada, _observers[id_Observer].imagenDeReferencia);


        //_observers[id_Observer].funcStart.Invoke();
    }

    public void activeMiddleAnimation()
    {
        
        updateMessage(_observers[id_Observer].dialogoIntermedio);
        oVRPlayerController.EnableLinearMovement = true;
        oVRPlayerController.EnableRotation = true;



        _observers[id_Observer].funcMiddle.Invoke();
    }

    public void activExitAnimation()
    {
        _observers[id_Observer].funcEnd.Invoke();
        particle.transform.position = oVRPlayerController.gameObject.transform.position + oVRPlayerController.gameObject.transform.forward * 2;
        particle.Play();

        updateMessage(_observers[id_Observer].dialogoSalida);
        addOne_ID_Observer();
        anim.SetTrigger("Exit");



        //anim.SetBool("next", true);


        StartCoroutine(waitSecondsAndStart(5, activeStartAnimation));      
    }

    void setVariables()
    {
        //_observers = FindObjectsOfType<Notifier>();
        foreach (Notifier item in _observers)
        {
            item.referenceCanvas = this;
            item.enabled = false;
        }
        id_Observer = 0;
    }
    void updateMessage(string message, Sprite img = null)
    {
        if (message != "")
        {
            texto_TUTO.text = message;
        }

        if (img != null)
        {
            image_TUTO.sprite = img;
        }
    }


    IEnumerator waitSecondsAndStart(float seconds, Action func) 
    {
        yield return new WaitForSeconds(seconds);
        func();
    }


}
