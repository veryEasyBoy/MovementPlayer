using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerMovement
{
    public PlayerIdle(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider colliderCharacter) : base(fsm,transform,speed,rb,colliderCharacter) { }
    public override void Enter()
    {
       // Debug.Log(message: $" Idle {this.GetType()} state[ENTER]");
    }
    public override void Exit()
    {
       // Debug.Log(message: $"Idle {this.GetType()} state[EXIT]");
    }
    public override void Update()
    {
        //Debug.Log(message: $"Idle {this.GetType()} state[UPDATE]");
        InputDirectional = ReadInput();
        if (InputDirectional.sqrMagnitude != 0f)
        {
            Fsm.SetState<PlayerMovementRun>();
        }

    }
    public override void FixedUpdate()
    {
        //Debug.Log(message: $"Idle {this.GetType()} state[FIXEDUPDATE]");

        StopMove(InputDirectional);
    }
}
