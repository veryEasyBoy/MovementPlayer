using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerSlide : AndroidPlayerMovement
{
    private bool canSlide = true;
    private float durationRide;
    private float startDurationRide;
    private float accelerationRide;
    private float height;
    public AndroidPlayerSlide(Fsm fsm, Character Character, Joystick joystick, PlayerSlideStats slideStats, float height, Animator animator, AudioSource audioSourc,AudioClip[] audioClip) : base(fsm, Character,joystick,animator, audioSourc, audioClip)
    {
        this.height = height;
        startDurationRide = slideStats.StartDurationRide;
        durationRide = slideStats.DurationRide;
        accelerationRide = slideStats.AccelerationRide;
    }
    public override void FixedUpdate()
    {
        InputDirectional = ReadInput();
        CanMove(InputDirectional);
        if (canSlide)
        {
            durationRide = startDurationRide;
            StartSound();
            UniTask slide = StartSlideUniTask(InputDirectional, durationRide, accelerationRide, colliderCharacter, transformCharacter);
        }
    }
    private async UniTask StartSlideUniTask(Vector2 inputDirection, float durationRide, float accelerationRide, CapsuleCollider colliderCharacter, Transform transformCharacter)
    {
        while (durationRide > 0.5f)
        {
            canSlide = false;
            colliderCharacter.center = new Vector3(0, 1f, 0);
            colliderCharacter.height = 0.1f;
            Vector3 movement = transformCharacter.forward * inputDirection.y + transformCharacter.right * inputDirection.x;
            rb.AddForce(movement.normalized * accelerationRide * durationRide);
            durationRide -= 0.01f;
            await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
            //await UniTask.Delay(2);
        }
        if (InputDirectional.sqrMagnitude == 0f)
        {
            Fsm.SetState<AndroidPlayerIdle>();
        }
        if (InputDirectional.sqrMagnitude != 0f)
        {
            Fsm.SetState<AndroidPlayerRun>();
        }
        colliderCharacter.center = new Vector3(0, 0.8f, 0);
        colliderCharacter.height = 1.6f;
        transformCharacter.position = new Vector3(transformCharacter.position.x, height, transformCharacter.position.z);
        canSlide = true;
    }
    private void Sound()
    {
        audioSource.pitch = Random.Range(1f, 2f);
        audioSource.PlayOneShot(audioClip[1], 1f);
    }
    private async UniTask StartSoundUniTask()
    {
        if (canSlide)
        {
            Sound();
            await UniTask.Delay(0);
        }
    }
    private UniTask StartSound() => StartSoundUniTask();
}
