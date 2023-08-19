using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Izaje1_Hack : MonoBehaviour
{
    public Rigidbody[] bobinasR;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            for (int i = 0; i < bobinasR.Length; i++)
            {
                bobinasR[i].isKinematic = !bobinasR[i].isKinematic;
            }

        }
    }
}
