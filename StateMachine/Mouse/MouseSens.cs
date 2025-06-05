using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSens
{
    private float sensetivity;
    private Vector3 playerEulerAngles;
    private Transform playerPosition;
    private float verticalMaxRangeRotate;
    private Transform transAimTarget;
    public MouseSens(float sensetivity, Vector3 playerEulerAngles,Transform playerPosition, float verticalMaxRangeRotate, Transform transAimTarget)
    {
        this.sensetivity = sensetivity;
        this.playerEulerAngles = playerEulerAngles;
        this.playerPosition = playerPosition;
        this.verticalMaxRangeRotate = verticalMaxRangeRotate;
        this.transAimTarget = transAimTarget;
    }
    public void Start()
    {
        playerEulerAngles = playerPosition.eulerAngles;
    }
    public void RotateMouse()
    {
        float mousX = Input.GetAxis("Mouse X");
        float mousY = Input.GetAxis("Mouse Y");
        Vector3 direction3 = new Vector3(0, mousY, 0);
        if (direction3.magnitude > Mathf.Abs(0.1f))
        {
            float h = sensetivity * Input.GetAxis("Mouse Y") * Time.deltaTime;
            playerEulerAngles.x = Mathf.Clamp(playerEulerAngles.x + h, -verticalMaxRangeRotate + 55, verticalMaxRangeRotate);
            transAimTarget.position = new Vector3(transAimTarget.position.x, playerEulerAngles.x, transAimTarget.position.z);
        }
        Vector3 direction2 = new Vector3(0, 0, -mousX);

        if (direction2.magnitude > Mathf.Abs(0.1f))
            playerPosition.Rotate(Vector3.up * Time.deltaTime * sensetivity * mousX);
    }
}
