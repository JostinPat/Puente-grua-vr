using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRopeRotation : MonoBehaviour
{
    public GameObject rope;
    public float speed;

    public bool test;
    void Start()
    {
        
    }

    void Update()
    {
        //SIMULAR ROTACION EN X Y Z BASANDOME EN POSICION

        //Quaternion dir = Quaternion.LookRotation((rope.transform.position - this.transform.position).normalized);
        Vector3 dir = (rope.transform.position - this.transform.position);
        //dir.y = 0;


        //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, dir, speed*Time.deltaTime);

        //this.transform.rotation = Quaternion.FromToRotation(this.transform.position, dir);//Por alguna razon este tiene rota raro
        this.transform.rotation *= Quaternion.FromToRotation(this.transform.up, dir);
    }
}
