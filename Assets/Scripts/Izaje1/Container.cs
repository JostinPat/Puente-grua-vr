using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Container : MonoBehaviour
{
    public List<MonoBehaviour> objetosContenidos;
    public int cantidadMaximaParaAccion;

    public bool llamarSoloUnaVez;

    public LevelDone levelDone;
    public ParticleSystem particulas_ThumpsUp;
    public TextMeshPro myText;
    public string descriptionText;

    public virtual void reactionAfterBeingFull() 
    {
        Debug.Log("haciendo accion");
    }

    public void UpdateText() 
    {
        myText.text = string.Format("{0}: {1}", descriptionText, objetosContenidos.Count.ToString());
    }
    public void UpdateWINText()
    {
        this.levelDone.FinalAnimation();
        myText.text = descriptionText + " - COMPLETADO";
    }
    public void activeParticles(Transform posBobina) 
    {
        particulas_ThumpsUp.transform.position = posBobina.position + Vector3.forward * 1.5f;
        particulas_ThumpsUp.Play();

    }
}
