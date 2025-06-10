using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSens 
{
    private float sensetivity;
    private Vector3 playerEulerAngles;
    private Transform playerPosition;
    private float verticalMaxRangeRotate;
    private Transform transAimTarget;
    private ControllerPanel cameraControllerPanel;
    public void Start()
    {
        playerEulerAngles = playerPosition.eulerAngles;
    }
    public PanelSens(float sensetivity, Vector3 playerEulerAngles, Transform playerPosition, float verticalMaxRangeRotate, Transform transAimTarget,ControllerPanel cameraControllerPanel)
    {
        this.sensetivity = sensetivity;
        this.playerEulerAngles = playerEulerAngles;
        this.playerPosition = playerPosition;
        this.verticalMaxRangeRotate = verticalMaxRangeRotate;
        this.transAimTarget = transAimTarget;
        this.cameraControllerPanel = cameraControllerPanel;
    }
    public void RotateCharacter()
    {
        float mousY;
        float mousX;
        if (cameraControllerPanel.Pressed)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == cameraControllerPanel.fingerId)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        mousY = touch.deltaPosition.y * sensetivity / 2;
                        mousX = touch.deltaPosition.x * sensetivity;
                        playerPosition.Rotate(Vector3.up * Time.deltaTime * mousX);

                        float h = mousY * Time.deltaTime;
                        playerEulerAngles.x = Mathf.Clamp(playerEulerAngles.x + h, -verticalMaxRangeRotate + 55, verticalMaxRangeRotate);
                        transAimTarget.position = new Vector3(transAimTarget.position.x, playerEulerAngles.x, transAimTarget.position.z);
                    }
                    if (touch.phase == TouchPhase.Stationary)
                    {
                        mousY = 0;
                        mousX = 0;
                    }
                }
            }

        }
    }
}
