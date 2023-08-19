using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AccesoriosData", menuName = "ScriptableObjects/Accesorios")]
public class AccesoriosData : ScriptableObject
{
    public int ID;
    public string nombre;
    public string falla;

    public string myTextUI;

    public bool examinado;


}
