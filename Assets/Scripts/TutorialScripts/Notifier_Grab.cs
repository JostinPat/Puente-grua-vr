using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class Notifier_Grab : Notifier
{
    public Material materialShader;
    public List<MeshRenderer> botones;
    public MeshRenderer botonera;


    public InteractableUnityEventWrapper wrapper;
    void Start()
    {
        wrapper.WhenSelect.AddListener(removeShader_Botonera);
        wrapper.WhenSelect.AddListener(addShader_Botones);

        wrapper.WhenUnselect.AddListener(addShader_Botonera);
        wrapper.WhenUnselect.AddListener(removeShader_Botones);

    }

    public void addShader_Botones() 
    {
        foreach (MeshRenderer item in botones)
        {
            item.material = materialShader;
        }
    }


    public void addShader_Botonera()
    {
        botonera.material = materialShader;
    }

    public void removeShader_Botones()
    {
        foreach (MeshRenderer item in botones)
        {
            item.material = null;
        }
    }
    public void removeShader_Botonera()
    {
        botonera.material = null;
    }

    public override void onNotify()
    {
        referenceCanvas.activExitAnimation();
        base.onNotify();
    }
}
