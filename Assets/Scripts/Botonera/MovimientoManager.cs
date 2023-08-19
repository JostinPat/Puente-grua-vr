using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovimientoCarro_Vigas_VR))]
[RequireComponent(typeof(MovimientoCuerdas_VR))]
public class MovimientoManager : MonoBehaviour
{
    public MovimientoCarro_Vigas_VR carro_Vigas_VR;
    public MovimientoCuerdas_VR movimientoCuerdas_VR;
    public bool canMove;




    public void setCanMove()
    {
        this.canMove = !this.canMove;
        carro_Vigas_VR.canMove = this.canMove;
        movimientoCuerdas_VR.canMove = this.canMove;
    }
}
