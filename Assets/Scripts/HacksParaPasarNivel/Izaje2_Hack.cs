using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Izaje2_Hack : MonoBehaviour
{
    public Rigidbody[] tubosR;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.RawButton.Y)) 
        {
            for (int i = 0; i < tubosR.Length; i++)
            {
                tubosR[i].isKinematic = !tubosR[i].isKinematic;
            }
        }
    }
}
