using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovement : FsmState
{
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
    public virtual void CanMove(Vector2 inputDirection)
    {
        Debug.Log(message: $"Movement {this.GetType()} state[UPDATE]");
        Vector3 movement = transformCharacter.forward * inputDirection.y + transformCharacter.right * inputDirection.x;
        rb.velocity = movement.normalized * speed;
    }
    public virtual void StopMove(Vector2 inputDirection) { }
    /*protected void ChangesState<T>(T state) where T : PlayerMovementRun
    {
        //Fsm.SetState<state>();
    }
    */
    protected abstract Vector2 ReadInput();

}
