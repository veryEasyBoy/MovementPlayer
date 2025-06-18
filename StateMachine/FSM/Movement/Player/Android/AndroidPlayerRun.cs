using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidPlayerRun : AndroidPlayerMovement
{
    private ButtonUi buttonUi;
    private ButtonPanel[] buttonPanel;
    private bool canSound = true;

    private enum Button
    {
        Slide,
        BoostSpeed
    }
    public AndroidPlayerRun(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider colliderCharacter, Joystick joystic,ButtonUi buttonUi,ButtonPanel[] buttonPanel, Animator animator, AudioSource audioSourc, AudioClip[] audioClip) : base(fsm, transform, speed, rb, colliderCharacter, joystic,animator,audioSourc,audioClip)
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
    public void ButtonBustSpeed(float speed)
    {
        
    }
    private void StartAnimation()
    {
        animator.SetLayerWeight(1, 0.05f);
    }
    private void Sound()
    {
        audioSource.pitch = Random.Range(1f, 2f);
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
