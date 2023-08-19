using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Boton_EnviarCorreo : MonoBehaviour
{
    public Button enviarCorreo;
    public Button salir;
    void Start()
    {
        enviarCorreo.onClick.AddListener(ExcelWriter.sendMail);
        salir.onClick.AddListener(GameManager.GameManagerInstance.exitSimulator);
        //Debug.Log("anasheiii");
    }
}
