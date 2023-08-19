using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBobinas : MonoBehaviour
{
    //ANGULO
    public Transform pivote;
    public GameObject currentBobina;
    [Header("ANGULO")]
    public float angulo;
    public float maxAngle;

    //PENDULOS
    public float contador_ParaInciarConteo;
    public int cantidadDePendulos;
    public ParticleSystem particula;

    //EMPEZO PROCESOS
    public PuertaEscenaIzaje1 puertaIzaje;

    public bool soloUnaVez;


    void Start()
    {
        cantidadDePendulos = 0;
        soloUnaVez = true;
    }

    void Update()
    {
        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bobina"))
        {
            currentBobina = null;
            contador_ParaInciarConteo = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        contador_ParaInciarConteo += Time.deltaTime;
        if (contador_ParaInciarConteo > 10 && currentBobina != null) 
        {
            angulo = Vector3.Angle((pivote.position - currentBobina.transform.position).normalized, this.transform.up);
            if (angulo > maxAngle)
            {
                StartCoroutine(cantidadPendulosFunction());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bobina"))
        {
            if (puertaIzaje.ProcesobobinasDeAcero == false && other.gameObject.GetComponent<Content>().tagContainer == "ContenedorBuggy")
            {
                puertaIzaje.ProcesobobinasDeAcero = true;

            }
            else if (puertaIzaje.ProcesobobinasMarrones == false && other.gameObject.GetComponent<Content>().tagContainer == "ContenedorBobinaMarron")
            {
                puertaIzaje.ProcesobobinasMarrones = true;
            }
            else
            {

            }

            currentBobina = other.gameObject;
        }
    }
    

    IEnumerator cantidadPendulosFunction() 
    {
        if (soloUnaVez) 
        {
            soloUnaVez = false;
            cantidadDePendulos++;
            LevelScore.instance.updateScores(ScoreData_Enum.Pendulos, cantidadDePendulos);
            particula.Play();
            yield return new WaitForSeconds(20);
            soloUnaVez = true;
        }

    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(pivote.position, currentBobina.transform.position);
    }
}
