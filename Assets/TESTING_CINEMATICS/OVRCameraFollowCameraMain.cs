using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRCameraFollowCameraMain : MonoBehaviour
{
    //public Camera cam;
    //void Update()
    //{
    //    this.transform.rotation = cam.transform.rotation;
    //    this.transform.position = cam.transform.position;
    //}
    public OVRCameraFollowing_Settings player;

    private void Start()
    {
        player.SettingsInCinematic();
        player.transform.rotation = this.transform.rotation;
        player.transform.position = this.transform.position;
        player.gameObject.transform.SetParent(this.transform);
    }
}
