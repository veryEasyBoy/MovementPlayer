using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAndroidParameters : PlayerParametrs
{
    [SerializeField] protected Joystick joystick;
    [SerializeField] protected ControllerPanel cameraControllerPanel;
    [SerializeField] protected ButtonPanel[] buttonControllerPanel;
    [SerializeField] protected ButtonUi buttonUi;
    protected PanelSens panelSens;
}
