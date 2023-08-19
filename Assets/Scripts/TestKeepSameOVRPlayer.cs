using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestKeepSameOVRPlayer : MonoBehaviour
{

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
