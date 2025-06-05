using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerParametrs
{
    private void Start()
    {
        fsm = new Fsm();
        mouseSens = new MouseSens(mousStats.sensetivity,mousStats.playerEulerAngles,playerPosition,mousStats.verticalMaxRangeRotate,transformAimTarget);
        mouseSens.Start();
        fsm.AddState(new PlayerIdle(fsm,playerPosition, characterStats.Speed, rb,capsuleCollider));
        fsm.AddState(new PlayerMovementRun(fsm,playerPosition, characterStats.Speed, rb, capsuleCollider));

        fsm.SetState<PlayerIdle>();
    }
    private void Update()
    {
        fsm.Update();
        mouseSens.RotateMouse();
    }
    private void FixedUpdate()
    {
        fsm.FixedUpdate();
    }

}
