using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanwichController : MonoBehaviour
{
    //
    public bool inicioIzaje;
    public float tiempoDeIzaje;



    //ANGULO
    public Transform pivote;

    [Header("ANGULO")]

    public float maxAnguloParaPoderIzar;
    public float maxAnguloParaCrearPendulo;

    [Header("PENDULO")]
    public bool bool_contadorUnicoCadaXSeconds;
    public int contadorPendulos;


    [Header("IZAJE")]
    public bool enContactoConCarga;
    public bool cargaAnclada;
    public GameObject baseSandwich;
    public PutTriggerRacks triggerRacks;

    public int contadorDeIzajesNoAlineados;

    public Tubo currentTubo;


    public ParticleSystem particulasPendulo;
    public ParticleSystem particulasNoAlineado;

    public float anguloConCarga;
    public bool alineado;
    void Start()
    {
        inicioIzaje = false;
        bool_contadorUnicoCadaXSeconds = true;
        baseSandwich.gameObject.SetActive(false);
    }

    void Update()
    {
        if (inicioIzaje)
        {
            tiempoDeIzaje += Time.deltaTime;
            //falta cambiar valor de tabla final
        }

        //ESLINGAR TUBOS
        if ((OVRInput.GetDown(OVRInput.RawButton.B)||Input.GetKeyDown(KeyCode.I)))
        {
            if (!cargaAnclada)
            {
                anguloConCarga = angleBetweenCargaYCuerda(currentTubo.transform);

                Debug.Log("RIGHT ANGLE " + Vector3.Angle((transform.right - currentTubo.transform.right).normalized, Vector3.right));
                Debug.Log("FORWARD ANGLE " + Vector3.Angle((transform.forward - currentTubo.transform.forward).normalized, Vector3.forward));

                if (enContactoConCarga && (angleBetweenCargaYCuerda(currentTubo.transform) < maxAnguloParaPoderIzar || 180 - angleBetweenCargaYCuerda(currentTubo.transform) < maxAnguloParaPoderIzar))
                {
                    triggerRacks.activate_deactivate(currentTubo);
                    currentTubo.activeDesactiveBaseCollider(false);
                    baseSandwich.gameObject.SetActive(true);
                    cargaAnclada = true;
                }
                else
                {
                    SuggestionManager.instance.activeByAMoment(SuggestEnum.AdimentoNoAlineado);//PANEL DE TEXTO SE ACTIVA
                    particulasNoAlineado.Play();
                    Debug.Log("el aditamento deve estar alineado con la carga");
                    contadorDeIzajesNoAlineados++;
                }
            }
            else 
            {
                baseSandwich.gameObject.SetActive(false);
                cargaAnclada = false;

                currentTubo.activeDesactiveBaseCollider(true);
                currentTubo = null;

                cargaAnclada = false;
            }

        }



        //PENDULOS
        
        if (cargaAnclada && angleBetweenCargaYCuerda(pivote.transform) > maxAnguloParaCrearPendulo)
        {
            if (bool_contadorUnicoCadaXSeconds == true)
            {

                StartCoroutine(esperarParaRegistrarOtroPendulo());
            }
        }




    }

    float angleBetweenCargaYCuerda(Transform pos)
    {
        return Vector3.Angle((pos.position - this.transform.position).normalized, this.transform.up);
    }
    //float angleBetweenCargaYCuerda() 
    //{
    //    return Vector3.Angle((pivote.position - this.transform.position).normalized, this.transform.up);
    //}

    IEnumerator esperarParaRegistrarOtroPendulo()
    {
        particulasPendulo.Play();
        bool_contadorUnicoCadaXSeconds = false;
        contadorPendulos++;
        yield return new WaitForSeconds(10);
        bool_contadorUnicoCadaXSeconds = true;
    }





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tubo") && !cargaAnclada) 
        {
            inicioIzaje = true;

            currentTubo = collision.gameObject.GetComponent<Tubo>();
            enContactoConCarga = true;
            SuggestionManager.instance.activeSuggestion(SuggestEnum.IzajeConX);//PANEL DE TEXTO ACTIVADO
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tubo") && !cargaAnclada)
        {
            enContactoConCarga = false;
            SuggestionManager.instance.deactiveSuggestion(SuggestEnum.IzajeConX);
        }
    }
}
