using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : FsmState
{
    private string AxisHorizontal = "Horizontal";
    private string AxisVertical = "Vertical";
    protected Transform transformCharacter;
    protected CapsuleCollider colliderCharacter;
    protected Rigidbody rb;
    protected Vector2 InputDirectional;
    protected float speed;
    public PlayerMovement(Fsm fsm, Transform transform, float speed, Rigidbody rb,CapsuleCollider colliderCharacter) : base(fsm)
    {
        transformCharacter = transform; 
        this.rb = rb;
        this.colliderCharacter = colliderCharacter;
        this.speed = speed;
    }
    public override void Enter()
    {
       // Debug.Log(message: $" Movement {this.GetType()} state[ENTER]");
    }
    public override void Exit()
    {
        //Debug.Log(message: $"Movement {this.GetType()} state[EXIT]");
    }
    public override void Update()
    {
       // Debug.Log(message: $"Movement {this.GetType()} state[UPDATE]");
        InputDirectional = ReadInput();
    }
    public override void FixedUpdate()
    {
        //Debug.Log(message: $"Movement {this.GetType()} state[FIXEDUPDATE]");
        //StopMove(InputDirectional);
        //CanMove(InputDirectional);
    }
    public virtual void CanMove(Vector2 inputDirection)
    {
       // Vector3 movement = new Vector3(inputDirection.x, 0f, inputDirection.y);
        Vector3 movement = transformCharacter.forward * inputDirection.y +transformCharacter.right * inputDirection.x;
        rb.velocity = movement.normalized*speed;
        Fsm.SetState<PlayerMovementRun>();
    }
    public virtual void StopMove(Vector2 inputDirection)
    {
        if (inputDirection.sqrMagnitude == 0f)
        {
            Fsm.SetState<PlayerIdle>();
        }
    }
    protected Vector2 ReadInput()
    {
        var inputHorizontal = Input.GetAxis(AxisHorizontal);
        var inputVertical = Input.GetAxis(AxisVertical);
        var inputDirection = new Vector2( inputHorizontal, inputVertical);
        return inputDirection;
    }
}
