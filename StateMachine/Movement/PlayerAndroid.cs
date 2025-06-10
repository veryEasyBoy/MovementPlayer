using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAndroid : PlayerAndroidParameters
{
    private void Start()
    {
        fsm = new Fsm();
        panelSens = new PanelSens(mousStats.sensetivity, mousStats.playerEulerAngles, playerPosition, mousStats.verticalMaxRangeRotate, transformAimTarget,cameraControllerPanel);
        panelSens.Start();
        fsm.AddState(new AndroidPlayerSlide(fsm, playerPosition, characterStats.Speed, rb, capsuleCollider, joystick, slideStats.DurationRide, slideStats.AccelerationRide,slideStats.StartDurationRide));
        fsm.AddState(new AndroidPlayerIdle(fsm, playerPosition, characterStats.Speed, rb, capsuleCollider, joystick));
        fsm.AddState(new AndroidPlayerRun(fsm, playerPosition, characterStats.Speed, rb, capsuleCollider, joystick,buttonControllerPanel));
        fsm.SetState<AndroidPlayerIdle>();
        
    }
    private void Update()
    {
        fsm.Update();
        panelSens.RotateCharacter();
    }
    private void FixedUpdate()
    {
        fsm.FixedUpdate();
    }
}
