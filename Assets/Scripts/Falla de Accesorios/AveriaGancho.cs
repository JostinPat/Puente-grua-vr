using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveriaGancho : Averia
{
    public GameObject ganchoRectoModel;
    public Collider colliderRecto;

    public GameObject ganchoDobladoModel;
    public Collider colliderDoblado;
    public PhysicMaterial iceMaterialCollider;
    public Animator anim;
    new void Start()
    {
        base.Start();
        if (this.fallar && GameManager.GameManagerInstance.secuenciaNiveles != 0)
        {
            this.fallarFunction();
            this.finalizarSimulacion();
        }
        else
        {
            restauracionFunction();
        }
    }
    void Update()
    {
        
    }

    public override void fallarFunction()
    {
        Debug.Log("fallarrrr");
        colliderRecto.enabled = false;
        ganchoRectoModel.gameObject.SetActive(false);
        ganchoDobladoModel.gameObject.SetActive(true);
    }
    public override void restauracionFunction()
    {
        Destroy(ganchoDobladoModel);
    }

    IEnumerator fallaInminente() 
    {
        yield return new WaitForSeconds(8);
        anim.enabled = true;
        yield return new WaitForSeconds(1);
        colliderDoblado.material = iceMaterialCollider;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.fallar && other.gameObject.CompareTag("Bobina")&& GameManager.GameManagerInstance.secuenciaNiveles != 0) 
        {
            StartCoroutine(fallaInminente());
        }
    }
}
