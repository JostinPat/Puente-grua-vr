using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionarEntreInteraccion : MonoBehaviour
{
    int indice;
    public GameObject[] arrayImages;

    public void transition(int entero) 
    {
        arrayImages[indice].gameObject.SetActive(false);
        indice += entero;  
        indice = indice % arrayImages.Length;
        if (indice < 0)
        {
            indice += arrayImages.Length;
        }
        arrayImages[indice].gameObject.SetActive(true);
    }
}
