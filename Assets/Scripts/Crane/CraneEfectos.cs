using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneEfectos : MonoBehaviour
{
    public GameObject cable;
    CraneController_ myCraneController;

    [Header("---- Audio ----")]
    public AudioClip cableEnrollado;
    public float volume;
    public AudioClip puenteGruaMovimiento;
    void Start()
    {
        myCraneController = GetComponent<CraneController_>();

        if(GameManager.GameManagerInstance.soundManagerInstance.myAudioSources.Count == 0)
            GameManager.GameManagerInstance.soundManagerInstance.playDifferentSounds(new List<AudioClip>() { cableEnrollado, puenteGruaMovimiento });
    }

    void Update()
    {
        if (myCraneController.cuerdaEnrollando)
        {
            GameManager.GameManagerInstance.soundManagerInstance.activeSound(0);
            cable.gameObject.transform.Rotate(Vector3.right, 5f);
        }
        else 
        {
            GameManager.GameManagerInstance.soundManagerInstance.desactiveSound(0);
        }


        if (myCraneController.gruaActivada) 
        {
            GameManager.GameManagerInstance.soundManagerInstance.activeSound(1);
        }

        else
        {
            GameManager.GameManagerInstance.soundManagerInstance.desactiveSound(1);
        }
    }
}
