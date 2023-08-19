using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzajeBobinasMarrones : Container
{
    public PuertaEscenaIzaje1 cronometroControlBobinasMarrones;
    public List<GameObject> bobinasFakes;

    private void Start()
    {

        llamarSoloUnaVez = true;
    }

    
    public override void reactionAfterBeingFull()
    {
        StartCoroutine(ComprobacionFinaldeBobinas());
    }

    IEnumerator ComprobacionFinaldeBobinas() 
    {

        yield return new WaitForSeconds(10);

        if (llamarSoloUnaVez && this.objetosContenidos.Count == this.cantidadMaximaParaAccion) 
        {
            llamarSoloUnaVez = false;

            //foreach (var item in this.objetosContenidos)
            //{
            //    Destroy(item.gameObject);
            //}

            //this.objetosContenidos.Clear();
            
            foreach (var item in this.bobinasFakes)
            {
                item.gameObject.SetActive(false);
            }

            this.UpdateWINText();
            cronometroControlBobinasMarrones.ProcesobobinasMarrones = false;//paramos el cronometro
        }
        
    }
}
