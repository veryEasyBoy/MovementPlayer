using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PkPlayerSlide : PkPlayerMovement
{
    private float durationRide;
    private float startDurationRide;
    private float accelerationRide;
    private bool canSlide = true;
    public PkPlayerSlide(Fsm fsm, Transform transform, float speed, Rigidbody rb, CapsuleCollider colliderCharacter,float durationRide,float accelerationRide, float startDurationRide) : base(fsm, transform, speed, rb, colliderCharacter)
    {
        this.startDurationRide = startDurationRide;
        this.durationRide = durationRide;
        this.accelerationRide = accelerationRide;
    }
    public override void Update()
    {
        InputDirectional = ReadInput();
        if (canSlide)
        {
            durationRide = startDurationRide;
            UniTask slide = StartSlideUniTask(InputDirectional,durationRide,accelerationRide, colliderCharacter,transformCharacter);
        }
    }
    private async UniTask StartSlideUniTask(Vector2 inputDirection,float durationRide, float accelerationRide,CapsuleCollider colliderCharacter,Transform transformCharacter)
    {
        while (durationRide > 0.5f)
        {
            canSlide = false;
            colliderCharacter.center = new Vector3(0, 1f, 0);
            colliderCharacter.height = 0.1f;
            Vector3 movement = transformCharacter.forward * inputDirection.y + transformCharacter.right * inputDirection.x;
            rb.AddForce(movement.normalized * accelerationRide * durationRide, ForceMode.Impulse);
            durationRide -= 0.01f;
            Debug.Log(durationRide);
            await UniTask.Delay(1);
        }
        if (InputDirectional.sqrMagnitude == 0f)
        {
            Fsm.SetState<PkPlayerIdle>();
        }
        if (InputDirectional.sqrMagnitude != 0f)
        {
            Fsm.SetState<PkPlayerRun>();
        }
        colliderCharacter.center = new Vector3(0, 0.8f, 0);
        colliderCharacter.height = 1.6f;
        transformCharacter.position = new Vector3(transformCharacter.position.x, 6.16f, transformCharacter.position.z);
        canSlide = true;
    }
}
