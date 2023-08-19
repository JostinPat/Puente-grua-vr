using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveStaticCanvasCinematic : MonoBehaviour
{
    public GameObject panelCinematica;
    public GameObject cinematica;
    public Animator anim;

    [SerializeField] bool canShow;

    void Start()
    {
        showCinematic();
    }


    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X) && canShow)
        {
            canShow = false;
            showCinematic();
        }
    }

    void showCinematic() 
    {
        panelCinematica.gameObject.SetActive(true);
        cinematica.gameObject.SetActive(true);
        anim.Play("Recorded");
        StartCoroutine(afterShowCinmeatic());
    }


    IEnumerator afterShowCinmeatic() 
    {
        yield return new WaitForSeconds(15);
        panelCinematica.gameObject.SetActive(false);
        cinematica.gameObject.SetActive(false);
        canShow = true;
    }

}
