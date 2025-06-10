using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PkPlayerRun : PkPlayerMovement
{
    KeyCode slideKeyCode;
    public PkPlayerRun(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider playerCollider, KeyCode slideKeyCode) : base(fsm, transform, speed, rb, playerCollider)
    {
        this.slideKeyCode = slideKeyCode;
    }
    public override void Update()
    {
        InputDirectional = ReadInput();
        if (InputDirectional.sqrMagnitude == 0f)
        {
            Fsm.SetState<PkPlayerIdle>();
        }
        if(Input.GetKeyDown(slideKeyCode))
        {
            Fsm.SetState<PkPlayerSlide>();
        }
    }
    public override void FixedUpdate()
    {
        CanMove(InputDirectional);
    }
}
