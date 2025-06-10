using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerMovement : PlayerMovement
{
    protected Joystick joystick;
    public AndroidPlayerMovement(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider colliderCharacter, Joystick joystick) : base(fsm,transform,speed,rb,colliderCharacter)
    {
        transformCharacter = transform;
        this.rb = rb;
        this.colliderCharacter = colliderCharacter;
        this.speed = speed;
        this.joystick = joystick;
    }
    protected override Vector2 ReadInput()
    {
        var inputHorizontal = joystick.Horizontal;
        var inputVertical = joystick.Vertical;
        var inputDirection = new Vector2(inputHorizontal, inputVertical);
        return inputDirection;
    }
}
