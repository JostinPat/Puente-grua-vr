using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContenedorBasuras : MonoBehaviour
{
    public List<GameObject> contendores;
    public int numeroContenedores;
    public float segundos;
    public bool startContador;
    public TextMeshPro text;
    public GameObject TextoContainer;
    public void activeContador()
    {
        startContador = true;
    }
    void Update()
    {
        if (startContador)
        {
            segundos -= Time.deltaTime;
            text.text = segundos.ToString("0.00");
            if (segundos <= 0)
            {
                startContador = false;
                TextoContainer.gameObject.SetActive(false);
            }
            else
            {
                TextoContainer.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Basura")) 
        {
            numeroContenedores--;
        }
    }
}
