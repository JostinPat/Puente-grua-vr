using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideButton : MonoBehaviour
{
    [Header("--- Control de botones ---")]
    public BotonesBotonera ReferencebotonesFuncionales;
    public List<GameObject> botonesGO;

    void Start()
    {
        //Desactivar botones

        if (SceneManager.GetActiveScene().name == "Examinacion_VR")
        {
            Debug.Log("ANASHEII");
            ReferencebotonesFuncionales.desactivamosBotones = false;//Reiniciar config
            ReferencebotonesFuncionales.botonesFuncionales.Clear();//Reiniciar config

            for (int i = 0; i < botonesGO.Count; i++)
            {

                if(i % 2 != 0 && i != 1)
                {
                    botonesGO[i].gameObject.SetActive(false);
                }
                else
                {
                    botonesGO[i].gameObject.SetActive(true);
                }

                ReferencebotonesFuncionales.botonesFuncionales.Add(botonesGO[i].gameObject.activeSelf);
            }

            ReferencebotonesFuncionales.desactivamosBotones = true;
        }
    }


    public void activarTodosBotones() 
    {
        ReferencebotonesFuncionales.botonesFuncionales.Clear();
        for (int i = 0; i < 8; i++)
        {
            botonesGO[i].gameObject.SetActive(true);
            ReferencebotonesFuncionales.botonesFuncionales.Add(true);
        }
    }

    public void dejarAveriado() 
    {
        if (ReferencebotonesFuncionales.desactivamosBotones)
        {
            for (int i = 0; i < ReferencebotonesFuncionales.botonesFuncionales.Count; i++)
            {
                botonesGO[i].gameObject.SetActive(ReferencebotonesFuncionales.botonesFuncionales[i]);
            }
        }
    }
}
