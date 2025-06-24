using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidPlayerRun : AndroidPlayerMovement
{
    private ButtonUi buttonUi;
    private ButtonPanel[] buttonPanel;
    private bool canSound = true;
    private enum Button
    {
        Slide
    }
    public AndroidPlayerRun(Fsm fsm, Character Character, Joystick joystic,ButtonUi buttonUi,ButtonPanel[] buttonPanel, Animator animator, AudioSource audioSourc, AudioClip[] audioClip) : base(fsm, Character, joystic,animator,audioSourc,audioClip)
    {
        this.buttonUi = buttonUi;
        this.buttonPanel = buttonPanel;
    }
    public override void Update()
    {
        buttonUi.Button(buttonPanel, (int)Button.Slide, CanSlide);
        InputDirectional = ReadInput();
        if (InputDirectional.sqrMagnitude == 0f)
        {
            Fsm.SetState<AndroidPlayerIdle>();
        }
    }
    public override void FixedUpdate()
    {
        CanMove(InputDirectional);
        StartAnimation();
        StartSound();
    }
    private void CanSlide()
    {
        Fsm.SetState<AndroidPlayerSlide>();
    }
    private void StartAnimation()
    {
        animator.SetLayerWeight(1, 0.05f);
    }
    private void Sound()
    {
        audioSource.pitch = UnityEngine.Random.Range(1f, 2f);
        audioSource.PlayOneShot(audioClip[0], 1f);
    }
    private async UniTask StartSoundUniTask()
    {
        if(canSound)
        {
            canSound = false;
            Sound();
            await UniTask.Delay(250);
            canSound = true;
        }
    }
    private UniTask StartSound() => StartSoundUniTask();

}
