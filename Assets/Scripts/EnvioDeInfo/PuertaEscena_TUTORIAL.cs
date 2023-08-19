using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaEscena_TUTORIAL : Notifier
{
    public GameObject[] planes;
    void Start()
    {
        this.funcMiddle.AddListener(activarPlanes);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.GameManagerInstance.loadNextScene();
        }
    }


    public void activarPlanes() 
    {
        for (int i = 0; i < planes.Length; i++)
        {
            planes[i].gameObject.SetActive(true);
        }
    }
}
