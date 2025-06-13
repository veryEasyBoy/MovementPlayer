using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerParametrs
{
    private void Start()
    {
        fsm = new Fsm();
        
        mouseSens = new MouseSens(mousStats.sensitivity,mousStats.playerEulerAngles,playerPosition,mousStats.verticalMaxRangeRotate,transformAimTarget);
        mouseSens.Start();
        fsm.AddState(new PkPlayerSlide(fsm, playerPosition, characterStats.Speed, rb, capsuleCollider,slideStats.DurationRide,slideStats.AccelerationRide,slideStats.StartDurationRide));
        fsm.AddState(new PkPlayerIdle(fsm,playerPosition, characterStats.Speed, rb,capsuleCollider));
        fsm.AddState(new PkPlayerRun(fsm,playerPosition, characterStats.Speed, rb, capsuleCollider, characterStats.slide));

        fsm.SetState<PkPlayerIdle>();
    }
    private void Update()
    {
        fsm.Update();
        mouseSens.RotateCharacter();
    }
    private void FixedUpdate()
    {
        fsm.FixedUpdate();
    }

}
