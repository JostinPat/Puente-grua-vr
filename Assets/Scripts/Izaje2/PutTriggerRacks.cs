using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTriggerRacks : MonoBehaviour
{
    public List<BoxCollider> colliders;
    public List<Rigidbody> rigidsCargas;
    public void activate_deactivate(Tubo current) 
    {
        StartCoroutine(activate_deactivateIEnumator(current));
    }

    IEnumerator activate_deactivateIEnumator(Tubo current)
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].isTrigger = true;
        }

        for (int i = 0; i < rigidsCargas.Count; i++)
        {
            if(rigidsCargas[i].gameObject != current.gameObject) 
            {
                rigidsCargas[i].isKinematic = true;
            }
        }

        yield return new WaitForSeconds(20);

        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].isTrigger = false;
        }

        for (int i = 0; i < rigidsCargas.Count; i++)
        {
            rigidsCargas[i].isKinematic = false;
        }
    }



}
