using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerIdle : AndroidPlayerMovement
{
    public AndroidPlayerIdle(Fsm fsm, Character Character, Joystick joystic, Animator animator, AudioSource audioSource, AudioClip[] audioClip) : base(fsm, Character,joystic,animator,audioSource,audioClip) { }
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
