using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubo : MonoBehaviour
{
    public GameObject baseCollider;

    public void activeDesactiveBaseCollider(bool input) 
    {
        baseCollider.gameObject.SetActive(input);
    }
}
