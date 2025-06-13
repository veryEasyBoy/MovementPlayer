using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerIdle : AndroidPlayerMovement
{
    public AndroidPlayerIdle(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider colliderCharacter, Joystick joystic, Animator animator, AudioSource audioSource, AudioClip[] audioClip) : base(fsm, transform, speed, rb, colliderCharacter,joystic,animator,audioSource,audioClip) { }
    public override void Update()
    {
        InputDirectional = ReadInput();
        if (InputDirectional.sqrMagnitude != 0f)
        {
           
            Fsm.SetState<AndroidPlayerRun>();
        }
    }
    public override void FixedUpdate()
    {
        StopMove(InputDirectional);
        StopAnimation();
    }
    private void StopAnimation()
    {
        animator.SetLayerWeight(1, 0f);
    }
    private void StopSound()
    {

    }
}
