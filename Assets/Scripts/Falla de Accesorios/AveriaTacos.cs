using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveriaTacos : Averia
{
    public float force;
    public Rigidbody bobinaTarjet;
    public Rigidbody bobinaTarjet2;
    public Rigidbody bobinaTarjet3;



    public List<GameObject> tacosMalPuestos;
    public List<GameObject> tacosBienColocados;
    new void Start()
    {
        base.Start();
        if (!this.fallar) 
        {
            restauracionFunction();
        }

    }
    public override void fallarFunction()
    {
        bobinaTarjet.isKinematic = false;
        bobinaTarjet2.isKinematic = false;
        bobinaTarjet3.isKinematic = false;
        bobinaTarjet.AddForce(bobinaTarjet.transform.forward * force);
        bobinaTarjet2.AddForce(bobinaTarjet.transform.forward * force);
        bobinaTarjet3.AddTorque(bobinaTarjet.transform.up * 20f);

        this.finalizarSimulacion();
    }
    public override void restauracionFunction()
    {
        foreach (var item in tacosMalPuestos)
        {
            item.gameObject.SetActive(false);
        }

        foreach (var item in tacosBienColocados)
        {
            item.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bobina") && this.fallar) 
        {
            fallarFunction();
        }
    }


}
