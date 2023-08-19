using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class WriteCheckList : MonoBehaviour
{
    public LaserPointer pointer;
    public GameObject panelchecklist;
    public TMP_InputField inputField;

    public Teleport playerTeleport;
    public InputField_Native keyboard;


    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two)) 
        {
            Write();
        }
    }

    public void Write() 
    {
        GameObject instancia = Instantiate(inputField.gameObject);

        TMP_InputField created = instancia.GetComponent<TMP_InputField>();
        created.onSelect.AddListener(text => keyboard.redirectField(created));
        keyboard.myField = created;


        instancia.GetComponent<RectTransform>().localPosition = pointer._endPoint;
        instancia.transform.SetParent(panelchecklist.transform);
        instancia.transform.localScale = Vector3.one;
        instancia.transform.localRotation = Quaternion.identity;
    }
    public void nashei() 
    {

    }
    private void OnEnable()
    {
        playerTeleport.enabled = false;
    }
    private void OnDisable()
    {
        playerTeleport.enabled = true;
    }
}
