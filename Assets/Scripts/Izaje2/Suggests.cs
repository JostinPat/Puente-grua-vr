using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SuggestEnum 
{
    AdimentoNoAlineado,
    IzajeConX
}
public class Suggests : MonoBehaviour
{
    public SuggestEnum mySuggest;
    [SerializeField] GameObject Panel;

    public void activePanel() 
    {
        Panel.gameObject.SetActive(true);
    }

    public void deactivePanel() 
    {
        Panel.gameObject.SetActive(false);
    }
}
