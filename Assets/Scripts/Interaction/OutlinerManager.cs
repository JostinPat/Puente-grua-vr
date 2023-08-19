using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class OutlinerManager : MonoBehaviour
{
    public GameObject targetObjectRenderer;//se asignan solas
    public Renderer referenceRenderer;//se asignan solas
    public Material matOutliner;//se asignan solas


    public InteractableUnityEventWrapper wrapper;
    void Start()
    {
        if (targetObjectRenderer)
        {
            referenceRenderer = targetObjectRenderer.GetComponent<MeshRenderer>();

        }

        else
        {
            referenceRenderer = this.gameObject.GetComponent<MeshRenderer>();
        }

        matOutliner = referenceRenderer.material;


        wrapper.WhenSelect.AddListener(desactivarOutliner);
        wrapper.WhenUnselect.AddListener(activarOutliner);
    }

    public void activarOutliner()
    {
        referenceRenderer.material = matOutliner;
    }
    public void desactivarOutliner() 
    {
        referenceRenderer.material = null;
    }
}
