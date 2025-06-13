using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerMovement : PlayerMovement
{
    protected Joystick joystick;
    protected Animator animator;
    protected AudioSource audioSource;
    protected AudioClip[] audioClip;
    public AndroidPlayerMovement(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider colliderCharacter, Joystick joystick, Animator animator, AudioSource audioSource, AudioClip[] audioClip) : base(fsm,transform,speed,rb,colliderCharacter)
    {
        transformCharacter = transform;
        this.rb = rb;
        this.colliderCharacter = colliderCharacter;
        this.speed = speed;
        this.joystick = joystick;
        this.animator = animator;
        this.audioSource = audioSource;
        this.audioClip = audioClip;
    }
    protected override Vector2 ReadInput()
    {
        var inputHorizontal = joystick.Horizontal;
        var inputVertical = joystick.Vertical;
        var inputDirection = new Vector2(inputHorizontal, inputVertical);
        return inputDirection;
    }
}
