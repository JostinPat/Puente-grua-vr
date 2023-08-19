using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public GameObject container;
    public TextMeshProUGUI prefabText;
    public void createGameOverScreen(List<string>listaNombres) 
    {
        for (int i = 0; i < listaNombres.Count; i++)
        {
            TextMeshProUGUI temp = Instantiate(prefabText, container.transform);
            temp.text = "* " + listaNombres[i];
        }
    }
}
