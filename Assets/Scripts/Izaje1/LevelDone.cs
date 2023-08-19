using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDone : MonoBehaviour
{
    public int doneTasks;
    public int taskToDo = 2;
    public GameObject anim;
    public GameObject panel;

    public void FinalAnimation()
    {
        doneTasks++;
        if (doneTasks == taskToDo)
        {
            panel.gameObject.SetActive(true);
            anim.gameObject.SetActive(true);
        }

    }
}
