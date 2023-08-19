using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking_Rigger_Action : MonoBehaviour
{
    public GameObject walk;
    public GameObject idle;
    public Transform tarjet;
    public bool empezarCaminar;
    void Start()
    {
        idle.gameObject.SetActive(true);
        walk.gameObject.SetActive(false);
        empezarCaminar = false;
    }

    void Update()
    {
        if (empezarCaminar)
        {
            this.transform.LookAt(tarjet);
            this.transform.position = Vector3.MoveTowards(transform.position, tarjet.position, 0.01f);
            if (Vector3.Distance(transform.position, tarjet.position) < 0.1f)
            {
                idle.gameObject.SetActive(true);
                walk.gameObject.SetActive(false);
                empezarCaminar = false;
            }
        }

    }

    public void empezarCaminarFunction() 
    {
        empezarCaminar = true;
        idle.gameObject.SetActive(false);
        walk.gameObject.SetActive(true);
    }
}
