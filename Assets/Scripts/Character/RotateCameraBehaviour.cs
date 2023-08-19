using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraBehaviour : MonoBehaviour
{
    public float sensivity;
    void Update()
    {
        this.transform.Rotate(Vector3.up, sensivity);
    }
}
