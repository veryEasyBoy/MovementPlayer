using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRun : PlayerMovement
{
    public PlayerMovementRun(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider playerCollider) : base(fsm, transform, speed,rb,playerCollider) { }
    public override void Update()
    {
        // Debug.Log(message: $"Run {this.GetType()} state[UPDATE]");

        InputDirectional = ReadInput();
        if (InputDirectional.sqrMagnitude == 0f)
        {
            Fsm.SetState<PlayerIdle>();
        }
    }
    public override void FixedUpdate()
    {
        //Debug.Log(message: $"Run {this.GetType()} state[FIXEDUPDATE]");
        CanMove(InputDirectional);
    }
}
