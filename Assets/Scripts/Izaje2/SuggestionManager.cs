using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuggestionManager : MonoBehaviour
{
    public static SuggestionManager instance;
    [SerializeField] Suggests[] sugerencias = new Suggests[2];

    [SerializeField] bool canActiveByAMoment = true;


    private void Awake()
    {
        instance = this;
    }
    public void activeSuggestion(SuggestEnum suggest) 
    {
        for (int i = 0; i < sugerencias.Length; i++)
        {
            if(sugerencias[i].mySuggest == suggest) 
            {
                sugerencias[i].activePanel();
            }
        }
    }

    public void deactiveSuggestion(SuggestEnum suggest) 
    {
        for (int i = 0; i < sugerencias.Length; i++)
        {
            if (sugerencias[i].mySuggest == suggest)
            {
                sugerencias[i].deactivePanel();
            }
        }
    }


    public void activeByAMoment(SuggestEnum suggest) 
    {
        for (int i = 0; i < sugerencias.Length; i++)
        {
            if (canActiveByAMoment && sugerencias[i].mySuggest == suggest)
            {
                StartCoroutine(activeByAMomentCorroutine(sugerencias[i]));
            }
        }
    }

    IEnumerator activeByAMomentCorroutine(Suggests sugerencia) 
    {
        canActiveByAMoment = false;
        sugerencia.activePanel();

        yield return new WaitForSeconds(3);

        canActiveByAMoment = true;
        sugerencia.deactivePanel();
    }
}
