using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingCamera : MonoBehaviour
{
    public Transform Tarjet;
    public float sensitivity;
    public float sensitivityRueda;
    public Vector3 mouseDelta = Vector3.zero;
    public Vector3 amount = Vector3.zero;
    public Vector3 camPos = Vector3.zero;

    public Camera componentCamera;
    public bool activado;
    void Start()
    {
        componentCamera = this.GetComponent<Camera>();
        componentCamera.enabled = false;
        amount.z = 10;
    }
    private void LateUpdate()
    {
        if (Tarjet != null) 
        {
            mouseDelta.Set(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"), -Input.GetAxisRaw("Mouse ScrollWheel"));

            amount += mouseDelta * sensitivity;
            amount.z = Mathf.Clamp(amount.z, 5, 50);
            amount.y = Mathf.Clamp(amount.y, -90, 90);

            camPos = Quaternion.AngleAxis(amount.x, Vector3.up) * Quaternion.AngleAxis(amount.y, Vector3.right) * Vector3.forward;

            camPos *= amount.z * sensitivityRueda;

            camPos += Tarjet.transform.position;

            transform.position = camPos;

            transform.LookAt(Tarjet.transform);
        }
    }

    public void activateDesactivateCamera() 
    {
        activado = !activado;
        componentCamera.enabled = activado;
    }
}
