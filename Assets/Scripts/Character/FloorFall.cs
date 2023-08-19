using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFall : MonoBehaviour
{
    public Vector3 posicionInicial;
    public GameObject referencePlayer;

    private void Start()
    {
        referencePlayer = this.transform.parent.gameObject;
        posicionInicial = referencePlayer.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fallGround"))
        {
            Debug.Log("wn culia trigger");
            this.transform.parent.gameObject.transform.position = posicionInicial;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("fallGround"))
    //    {
    //        Debug.Log("wn culia collision");
    //        this.transform.parent.gameObject.transform.position = posicionInicial;
    //    }
    //}

}
