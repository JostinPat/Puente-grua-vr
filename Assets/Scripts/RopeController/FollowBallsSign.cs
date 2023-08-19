using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBallsSign : MonoBehaviour
{
    public Transform posTrget;
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, posTrget.position + Vector3.up*0.2f, 0.5f);
    }
}
