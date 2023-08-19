using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidasManager : MonoBehaviour
{
    public string tagDeObjetoACaer;
    public int contadorCaidas;
    public bool seCuentaComoCaida;

    public ParticleSystem particula;
    void Start()
    {
        seCuentaComoCaida = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagDeObjetoACaer))
        {
            if (seCuentaComoCaida)
            {
                StartCoroutine(seCayoBobina());
            }
        }
    }

    IEnumerator seCayoBobina() 
    {
        contadorCaidas++;
        LevelScore.instance.updateScores(ScoreData_Enum.Caidas, contadorCaidas);
        particula.Play();
        seCuentaComoCaida = false;
        yield return new WaitForSeconds(20);
        seCuentaComoCaida = true;
    }

}
