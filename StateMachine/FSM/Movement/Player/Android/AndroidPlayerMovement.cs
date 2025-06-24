using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerMovement : PlayerMovement
{
    protected Joystick joystick;
    protected Animator animator;
    protected AudioSource audioSource;
    protected AudioClip[] audioClip;
    public AndroidPlayerMovement(Fsm fsm, Character Character, Joystick joystick, Animator animator, AudioSource audioSource, AudioClip[] audioClip) : base(fsm, Character)
    {
        transformCharacter = Character.transform;
        rb = Character.rb;
        colliderCharacter = Character.colliderCharacter;
        speed = Character.speed;
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
