using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDescarga : Container
{
    public CaidasManager caidasManager;
    public SanwichController sandwichRefe;

    public override void reactionAfterBeingFull()
    {
        StartCoroutine(ComprobacionFinal());
    }
    //ACA VEMOS LO QUE PASA CON LA TABLA DE PUNTUACIONES Y REPORUDCIMOS CINEMATICA FINAL
    IEnumerator ComprobacionFinal()
    {
        yield return new WaitForSeconds(10);

        if(this.objetosContenidos.Count == 3) 
        {
            if (this.llamarSoloUnaVez == false)
            {
                LevelScore.instance.setData(sandwichRefe.contadorPendulos, (int)sandwichRefe.tiempoDeIzaje, sandwichRefe.contadorDeIzajesNoAlineados, caidasManager.contadorCaidas);
                this.UpdateWINText();
                this.llamarSoloUnaVez = true;
            }
        }

    }
}
