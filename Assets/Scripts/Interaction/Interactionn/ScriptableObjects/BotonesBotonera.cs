using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BotonesData", menuName = "ScriptableObjects/BotonesDeBotonera")]
public class BotonesBotonera : ScriptableObject
{
    public List<bool> botonesFuncionales;
    public bool desactivamosBotones;
}
