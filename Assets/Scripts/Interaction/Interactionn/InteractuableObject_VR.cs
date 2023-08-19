using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction;
public class InteractuableObject_VR : MonoBehaviour
{
    public TypeInteractionObject myType;
    public TextMeshPro textInSign;
    public InteractableUnityEventWrapper eventWrapperOBJECT;
    public InteractableUnityEventWrapper eventWrapperBUTTON;

    public virtual void updateText(string text) 
    {
        textInSign.text = text;
    }
}
