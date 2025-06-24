using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAndroid : PlayerAndroidParameters
{
    private void Start()
    {
        fsm = new Fsm();
        panelSens = new PanelSens(GameSetting.sensitivity, mousStats.playerEulerAngles, playerPosition, mousStats.verticalMaxRangeRotate, transformAimTarget,cameraControllerPanel);
        panelSens.Start();
        fsm.AddState(new AndroidPlayerSlide(fsm, character, joystick, slideStats, height, animator,audioSource,audioClip));
        fsm.AddState(new AndroidPlayerIdle(fsm, character, joystick,animator,audioSource,audioClip));
        fsm.AddState(new AndroidPlayerRun(fsm, character, joystick, buttonUi, buttonControllerPanel,animator,audioSource,audioClip));
        fsm.SetState<AndroidPlayerIdle>(); 
    }
    private void Update()
    {
        panelSens.Update();
        fsm.Update();
        panelSens.RotateCharacter();
    }
    private void FixedUpdate()
    {
        fsm.FixedUpdate();
    }
    public void UpdateSpeed(ref float speed)
    {
        character.speed = speed;
        fsm = new Fsm();
        fsm.AddState(new AndroidPlayerSlide(fsm, character, joystick, slideStats, height, animator, audioSource, audioClip));
        fsm.AddState(new AndroidPlayerIdle(fsm, character, joystick, animator, audioSource, audioClip));
        fsm.AddState(new AndroidPlayerRun(fsm, character, joystick, buttonUi, buttonControllerPanel, animator, audioSource, audioClip));
        fsm.SetState<AndroidPlayerIdle>();
    }
}

