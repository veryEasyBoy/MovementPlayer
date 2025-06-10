using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerIdle : AndroidPlayerMovement
{
    public AndroidPlayerIdle(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider colliderCharacter, Joystick joystic) : base(fsm, transform, speed, rb, colliderCharacter,joystic) { }
    public override void Update()
    {
        InputDirectional = ReadInput();
        if (InputDirectional.sqrMagnitude != 0f)
        {
            Fsm.SetState<AndroidPlayerRun>();
        }
    }
    public override void FixedUpdate()
    {
        StopMove(InputDirectional);
    }
}
