using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//El radio del character es: 0.02
//LayerTeleportable . AÑADIR ESTE LAYER Y ASIGNAR AL SUELO
//LineRenderer . SE AGREGA AUTOMATICAMENTE SOLO CAMBIAR AJUSTES
//ControllerPivotPosition . asignar el game objeto dentro de OVRCAMERARIG/RIGHT HAND ANCHOR/ OVRCONTROLLERPREFAB/ RIGHT HAND LO QUE SEA
//Player . OVR GAME OBJECT
//Para que funcione se cambio la tasa de refresco -> ProjectSettings/Time/FixedTime=1/90
[RequireComponent(typeof(LineRenderer))]
public class Teleport : MonoBehaviour
{
    [Header("Ray")]
    public int rayLenght = 50;
    bool aboutToTeleport = false;
    Vector3 teleportPos;
    public LayerMask layerTeleportable;//


    [Header("Required Components")]
    public CharacterController characterController;
    public LineRenderer myLine;//

    [Header("Required Transforms")]
    public Transform controllerPivotPosition;//
    public GameObject player;//

    public GameObject cylinder;

    private void Start()
    {
        if (!characterController) characterController = GetComponent<CharacterController>();
        cylinder = Instantiate(cylinder);
        cylinder.gameObject.transform.position = Vector3.one * 100;
    }

    void Update()
    {
        //text1.text = "POSITION PLAYER " + player.gameObject.transform.position.ToString();

        if (OVRInput.Get(OVRInput.Button.One))
        {
            RaycastHit hit;

            if (Physics.Raycast(controllerPivotPosition.position, controllerPivotPosition.forward, out hit, rayLenght, layerTeleportable))//layer hace que no podamos apuntar fuera del suelo para no caernos
            {
                //visual
                myLine.SetPosition(0, controllerPivotPosition.position);
                myLine.SetPosition(1, hit.point);
                cylinder.gameObject.transform.position = hit.point;

                aboutToTeleport = true;
                teleportPos = hit.point;
                //text2.text = "POINT POSITION " + teleportPos.ToString();


            }

        }


        if (OVRInput.GetUp(OVRInput.Button.One) && aboutToTeleport)
        {
            //visual
            cylinder.gameObject.transform.position = Vector3.one*100;
            myLine.SetPosition(0, Vector3.zero);
            myLine.SetPosition(1, Vector3.zero);



            characterController.enabled = false;
            player.gameObject.transform.position = teleportPos;
            aboutToTeleport = false;
            player.gameObject.transform.position = new Vector3(teleportPos.x, player.gameObject.transform.position.y + 1f, teleportPos.z);
            characterController.enabled = true;

        }
    }

}