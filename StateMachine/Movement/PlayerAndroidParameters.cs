using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndroidParameters : PlayerParametrs
{
    [SerializeField] protected Joystick joystick;
    [SerializeField] protected ControllerPanel cameraControllerPanel;
    [SerializeField] protected ButtonPanel buttonControllerPanel;
    protected PanelSens panelSens;
}
