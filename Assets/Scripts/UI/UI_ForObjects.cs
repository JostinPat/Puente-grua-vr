using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class UI_ForObjects : MonoBehaviour
{
    public GameObject child;
    public GameObject prefabText;

    public int indice;
    public TextMeshProUGUI[] poolTexts;

    private void Start()
    {
        Assert.AreNotEqual(poolTexts.Length, 0);
        //Verificar si los textos en la UI estan referenciados en el script


        foreach (var item in poolTexts)
        {
            item.gameObject.SetActive(false);
        }
    }
    /*private GameObject instaces;
    private TextMeshProUGUI textPrefab;
    private RectTransform transformPrefab;*/
    public void overrideText(string text) 
    {
        if(indice > 0)
            poolTexts[indice-1].text = text;
    }
    public void addText(string text) 
    {
        Assert.AreNotEqual(indice, poolTexts.Length);
        //Verificamos si el indice, la variable que activa y desactiva los textos no supera nunca la cantidad maxima de textos

        poolTexts[indice].gameObject.SetActive(true);
        Assert.IsTrue(poolTexts[indice].gameObject.activeSelf, "texto de la UI activado");

        poolTexts[indice].text = text;
        indice++;
        indice = indice % poolTexts.Length;
    }

    public void deleteTextsUI() 
    {
        for (int i = 0; i < indice; i++)
        {
            poolTexts[i].gameObject.SetActive(false);
        }
        indice = 0;

        Assert.IsFalse(poolTexts[0].gameObject.activeSelf, "todos los textos desactivados");
        //Verificacion de desactivacion de textos, para evitar el mal posicionamiento en la proxima llamada a overrideText o addText
    }
}
