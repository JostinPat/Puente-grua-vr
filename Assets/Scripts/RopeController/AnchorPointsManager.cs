using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//ESTE SCRIPT ES PARA EL GAMEOBJECT QUE CONTIENE A TODOS LOS CUBOS O ANCLAS
public class AnchorPointsManager : MonoBehaviour
{
    public List<Rigidbody> rbs;
    public float maxSpeed = 12;
    public bool readyForSimulation;


    #region "testing1"
    //test
    //public float speed;
    //public Transform tarjet;
    //public Transform tarjet2;
    //Vector3 currentTarget;
    #endregion
    void Start()
    {
        rbs = this.GetComponentsInChildren<Rigidbody>().ToList();//todos los cubos con mesh de esfera 
        StartCoroutine(LoadinLevel());


        #region "testing2"
        //test
        //currentTarget = tarjet.position;
        #endregion

    }

    void Update()
    {
        CheckAnchorsVelocities();

        #region "testing3"
        //test
        //if (Vector3.Distance(tarjet.position, transform.position)<1) 
        //{
        //    currentTarget = tarjet2.position;
        //}

        //if (Vector3.Distance(tarjet2.position, transform.position) < 1)
        //{
        //    currentTarget = tarjet.position;
        //}

        //rb.velocity = (currentTarget - this.transform.position).normalized * speed;

        //Debug.Log("VELOCITY : " + rb.velocity);
        //Debug.Log("MAGNITUDE : " + rb.velocity.magnitude);
        #endregion


    }

    //Limita los velocities para que no se vayan a la shit
    public void CheckAnchorsVelocities()
    {
        if (readyForSimulation)
        {
            for (int i = 0; i < rbs.Count; i++)
            {
                if (rbs[i].velocity.magnitude > maxSpeed)
                {
                    rbs[i].velocity = Vector3.ClampMagnitude(rbs[i].velocity, maxSpeed);
                }
            }
        }
    }

    //desactiva kinematics y activa dspues de un segundo sino se buggea por alguna razon
    public IEnumerator LoadinLevel()
    {
        readyForSimulation = false;
        for (int i = 0; i < rbs.Count; i++)
        {
            rbs[i].isKinematic = true;
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < rbs.Count; i++)
        {
            rbs[i].isKinematic = false;
        }
        readyForSimulation = true;
    }

    public void KINEMATIC_Activate(Rigidbody rigidAnchor)
    {
        rigidAnchor.isKinematic = true;
    }

    public void KINEMATIC_Deactivate(Rigidbody rigidAnchor)
    {
        rigidAnchor.isKinematic = false;
    }

    public void TRIGGER_Activate(Collider coll)
    {
        coll.isTrigger = true;
    }

    public void TRIGGER_Deactivate(Collider coll)
    {
        coll.isTrigger = false;
    }
}
