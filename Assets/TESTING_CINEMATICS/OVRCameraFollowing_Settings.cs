using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRCameraFollowing_Settings : MonoBehaviour
{
    public CharacterController characterController;
    public OVRPlayerController vRPlayerController;
    public Teleport teleport;
    public GameObject colliderGO;


    private Vector3 startPosition;
    private Quaternion startRotation;
    private void Start()
    {
        vRPlayerController = FindObjectOfType<OVRPlayerController>();
        characterController = vRPlayerController.gameObject.GetComponent<CharacterController>();
        teleport = vRPlayerController.gameObject.GetComponent<Teleport>();
        colliderGO = vRPlayerController.gameObject.transform.GetChild(3).gameObject;

        startPosition = vRPlayerController.transform.position;
        startRotation = vRPlayerController.transform.rotation;

        SettingsInCinematic();
        vRPlayerController.gameObject.transform.rotation = this.transform.rotation;
        vRPlayerController.gameObject.transform.position = this.transform.position;
        vRPlayerController.gameObject.gameObject.transform.SetParent(this.transform);
    }
    public void SettingsInCinematic() 
    {
        colliderGO.gameObject.SetActive(false);

        teleport.enabled = false;

        vRPlayerController.EnableLinearMovement = false;
        vRPlayerController.EnableRotation = false;

        characterController.enabled = false;
    }


    public void SettingsAfterCinematic()
    {
        vRPlayerController.gameObject.gameObject.transform.SetParent(null);
        vRPlayerController.gameObject.transform.position = startPosition + Vector3.up*5;
        vRPlayerController.gameObject.transform.rotation = startRotation;


        colliderGO.gameObject.SetActive(true);

        teleport.enabled = true;

        vRPlayerController.EnableLinearMovement = true;
        vRPlayerController.EnableRotation = true;

        characterController.enabled = true;
    }
}
