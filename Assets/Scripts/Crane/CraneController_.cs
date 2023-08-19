using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class CraneController_ : MonoBehaviour
{
    [Header("--- Botones Funcionales ---")]
    public BotonesBotonera referenceBotonesFuncionales;

    [Header("--- Triggers de Funcionamiento ---")]
    public bool cuerdaEnrollando;
    public bool puenteGruaMoviendose;
    public bool gruaActivada;

    [Header("--- Movimiento Trans y Horizo ---")]

    public GameObject vigasPuente;
    public GameObject carroPuente;
    public float velocidadMovimiento;
    private float directionX;
    private float directionZ;


    [Header("-frenos-")]
    public float gradoDecremento;//SI ES MAS FRENA EN SECO, SI NO ES LERP ES MAS LENTO Y POR ENDE FRENA CON RETRASO
    public float gradoIncremento;//SI ES MAS FRENA EN SECO, SI NO ES LERP ES MAS LENTO Y POR ENDE FRENA CON RETRASO


    [Header("--- Movimiento Cuerda ---")]
    public GameObject cuerda;
    public GameObject cuerda2;
    public GameObject cuerda3;

    ObiRopeCursor cursor;
    ObiRopeCursor cursor2;
    ObiRopeCursor cursor3_AnclaAccesorio;


    ObiRope rope;
    ObiRope rope2;
    ObiRope roper3_AnclaAccesorio;


    public float minLength = 1.5f;
    public float maxLength = 13;
    public float speedCuerda = 0f;
    public float MaxspeedCuerda;

    public void activar_desactivar_Script(bool input) 
    {
        this.enabled = input;//PARA DESCACTIVARLO DESPUES DE QUE TERMINE SU START
    }
    void Start()
    {
        rope = cuerda.GetComponent<ObiRope>();
        rope2 = cuerda2.GetComponent<ObiRope>();
        cursor = cuerda.GetComponent<ObiRopeCursor>();
        cursor2 = cuerda2.GetComponent<ObiRopeCursor>();
        roper3_AnclaAccesorio = cuerda3.GetComponent<ObiRope>();
        cursor3_AnclaAccesorio = cuerda3.GetComponent<ObiRopeCursor>();

        activar_desactivar_Script(false);
    }

    void Update()
    {
        activacionCrane();
        if (gruaActivada) 
        {
            cuerdasController();
            movimientoController();
        }

    }
    public void activacionCrane() 
    {
        if (Input.GetKeyDown(KeyCode.Keypad0) && referenceBotonesFuncionales.botonesFuncionales[0]) 
        {
            gruaActivada = !gruaActivada;
        }
    }
    public void cuerdasController() 
    {
        cuerdaEnrollando = true;

        if (Input.GetKey(KeyCode.Keypad7) && referenceBotonesFuncionales.botonesFuncionales[1])   //DOWN
        {
            if (rope.restLength < maxLength || rope2.restLength < maxLength)
            {
                float speedCuerda_ = speedCuerda * Time.deltaTime;

                cursor.ChangeLength(rope.restLength + speedCuerda_);
                cursor2.ChangeLength(rope2.restLength + speedCuerda_);
                cursor3_AnclaAccesorio.ChangeLength(roper3_AnclaAccesorio.restLength + speedCuerda_);
            }
        }

        else if (Input.GetKey(KeyCode.Keypad8) && referenceBotonesFuncionales.botonesFuncionales[2])     //UP
        {
            if (rope.restLength > minLength || rope2.restLength > minLength)
            {
                float speedCuerda_ = speedCuerda * Time.deltaTime;
                cursor.ChangeLength(rope.restLength - speedCuerda_);
                cursor2.ChangeLength(rope2.restLength - speedCuerda_);
                cursor3_AnclaAccesorio.ChangeLength(roper3_AnclaAccesorio.restLength - speedCuerda_);
            }
        }

        else
        {
            cuerdaEnrollando = false;
        }
    }

    public void movimientoController() 
    {
        puenteGruaMoviendose = true;
        if (Input.GetKey(KeyCode.Keypad2) && referenceBotonesFuncionales.botonesFuncionales[5]) //adelante
        {
            directionZ = Mathf.Lerp(directionZ, 1, gradoIncremento);


            velocidadMovimiento = Mathf.Lerp(velocidadMovimiento, 1.5f, 0.005f);//TRATAMOS DE QUE EL MOVIMIENTO EN SI TENGA UN LERP, PERO EL QUE MOFICAMOS SERA EL LERP DE DRECEMENTO E INCREMENTO. EL LERP DE VELOCIDAD SOLO ES PARA DAR
            //EL EFECTO
        }

        else if (Input.GetKey(KeyCode.Keypad1) && referenceBotonesFuncionales.botonesFuncionales[6])     //atras
        {
            directionZ = Mathf.Lerp(directionZ, -1, gradoIncremento);

            velocidadMovimiento = Mathf.Lerp(velocidadMovimiento, 1.5f, 0.005f);
        }

        else if (Input.GetKey(KeyCode.Keypad5) && referenceBotonesFuncionales.botonesFuncionales[4])     //derecha
        {
            directionX = Mathf.Lerp(directionX, -1, gradoIncremento);

            velocidadMovimiento = Mathf.Lerp(velocidadMovimiento, 1.5f, 0.005f);
        }

        else if (Input.GetKey(KeyCode.Keypad4) && referenceBotonesFuncionales.botonesFuncionales[3])     //izquierda
        {
            directionX = Mathf.Lerp(directionX, 1, gradoIncremento);

            velocidadMovimiento = Mathf.Lerp(velocidadMovimiento, 1.5f, 0.005f);
        }

        else 
        {
            puenteGruaMoviendose = false;

            directionX = Mathf.Lerp(directionX, 0, gradoDecremento);
            directionZ = Mathf.Lerp(directionZ, 0, gradoDecremento);
            velocidadMovimiento = Mathf.Lerp(velocidadMovimiento, 1f, 0.3f);
        }

        vigasPuente.transform.position += Vector3.right * Time.deltaTime * velocidadMovimiento * directionX;
        carroPuente.transform.position += Vector3.forward * Time.deltaTime * velocidadMovimiento * directionZ;
    }
}
