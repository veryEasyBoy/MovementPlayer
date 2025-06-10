using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PkPlayerMovement : PlayerMovement
{
    private string AxisHorizontal = "Horizontal";
    private string AxisVertical = "Vertical";
    public PkPlayerMovement(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider playerCollider) : base(fsm, transform, speed, rb, playerCollider) { }
    protected override Vector2 ReadInput()
    {
        var inputHorizontal = Input.GetAxis(AxisHorizontal);
        var inputVertical = Input.GetAxis(AxisVertical);
        var inputDirection = new Vector2(inputHorizontal, inputVertical);
        return inputDirection;
    }
}
