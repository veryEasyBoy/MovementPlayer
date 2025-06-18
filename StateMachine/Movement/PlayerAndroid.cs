using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAndroid : PlayerAndroidParameters
{
    private void Start()
    {
        speed = characterStats.Speed;
        GameSetting.sensitivity = mousStats.sensitivity;

        fsm = new Fsm();
        panelSens = new PanelSens(GameSetting.sensitivity, mousStats.playerEulerAngles, playerPosition, mousStats.verticalMaxRangeRotate, transformAimTarget,cameraControllerPanel);
        panelSens.Start();
        fsm.AddState(new AndroidPlayerSlide(fsm, playerPosition, speed, rb, capsuleCollider, joystick, slideStats.DurationRide, slideStats.AccelerationRide,slideStats.StartDurationRide,animator,audioSource,audioClip));
        fsm.AddState(new AndroidPlayerIdle(fsm, playerPosition, speed, rb, capsuleCollider, joystick,animator,audioSource,audioClip));
        fsm.AddState(new AndroidPlayerRun(fsm, playerPosition, speed, rb, capsuleCollider, joystick, buttonUi, buttonControllerPanel,animator,audioSource,audioClip));
        fsm.SetState<AndroidPlayerIdle>();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            SpeedChange?.Invoke();
        panelSens.Update();
        fsm.Update();
        panelSens.RotateCharacter();
    }
    private void FixedUpdate()
    {
        fsm.FixedUpdate();
    }
}

