using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PkPlayerIdle : PkPlayerMovement
{
    public PkPlayerIdle(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider colliderCharacter) : base(fsm, transform, speed, rb, colliderCharacter) { }
    public override void Update()
    {
        InputDirectional = ReadInput();
        if (InputDirectional.sqrMagnitude != 0f)
        {
            Fsm.SetState<PkPlayerRun>();
        }
    }
    public override void FixedUpdate()
    {
        StopMove(InputDirectional);
    }
}
