using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PkPlayerRun : PkPlayerMovement
{
    KeyCode slideKeyCode;
    public PkPlayerRun(Fsm fsm, Character Character, KeyCode slideKeyCode) : base(fsm, Character)
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
