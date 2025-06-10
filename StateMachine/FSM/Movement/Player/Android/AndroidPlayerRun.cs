using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidPlayerRun : AndroidPlayerMovement
{
    private ButtonPanel buttonControllerPanel;
    public AndroidPlayerRun(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider colliderCharacter, Joystick joystic,ButtonPanel buttonControllerPanel) : base(fsm, transform, speed, rb, colliderCharacter, joystic)
    {
        this.buttonControllerPanel = buttonControllerPanel;
    }
    public override void Update()
    {
        RotateCharacter();
        InputDirectional = ReadInput();
        if (InputDirectional.sqrMagnitude == 0f)
        {
            Fsm.SetState<AndroidPlayerIdle>();
        }
    }
    public override void FixedUpdate()
    {
        CanMove(InputDirectional);
    }
    private void CanSlide()
    {
        Fsm.SetState<AndroidPlayerSlide>();
    }
    public void RotateCharacter()
    {
        if (buttonControllerPanel.Pressed)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == buttonControllerPanel.fingerId)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        CanSlide();
                    }
                }
                
            }

        }
    }

}
