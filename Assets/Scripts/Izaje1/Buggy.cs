using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Buggy : Container
{
    public PuertaEscenaIzaje1 cronometroControlBobinasAcero;
    [SerializeField] PlayableDirector myPdirector;

    public List<GameObject> bobinasFakes;
    public GameObject bobinaVerde;
    public int contadorDeLlevadas;

    void Start()
    {
        myPdirector = GetComponent<PlayableDirector>();
        llamarSoloUnaVez = true;
    }
    public override void reactionAfterBeingFull()
    {
        myPdirector.Play();
    }

    public void showFakeBobinas() 
    {
        if (llamarSoloUnaVez) 
        {
            llamarSoloUnaVez = false;

            foreach (var item in this.objetosContenidos)
            {
                Destroy(item.gameObject);
            }
            this.objetosContenidos.Clear();
            bobinaVerde.gameObject.SetActive(false);

            foreach (var item in bobinasFakes)
            {
                item.gameObject.SetActive(true);
            }

            contadorDeLlevadas++;

            if (contadorDeLlevadas == 2)
            {
                this.UpdateWINText();

                cronometroControlBobinasAcero.ProcesobobinasDeAcero = false;
            }
        }

    }
    public void hideFakeBobinas() 
    {
        foreach (var item in bobinasFakes)
        {
            item.gameObject.SetActive(false);
        }
        llamarSoloUnaVez = true;
    }


}
