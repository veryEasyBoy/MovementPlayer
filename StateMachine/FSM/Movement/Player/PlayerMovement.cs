using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class PlayerMovement : FsmState
{
    protected Transform transformCharacter;
    protected CapsuleCollider colliderCharacter;
    protected Rigidbody rb;
    protected Vector2 InputDirectional;
    protected float speed;
    public PlayerMovement(Fsm fsm, Character Character) : base(fsm)
    {
        transformCharacter = Character.transform; 
        rb = Character.rb;
        colliderCharacter = Character.colliderCharacter;
        speed = Character.speed;
    }
    public virtual void CanMove(Vector2 inputDirection)
    {
        Debug.Log(message: $"Movement {this.GetType()} state[UPDATE]");
        Vector3 movement = transformCharacter.forward * inputDirection.y + transformCharacter.right * inputDirection.x;
        rb.velocity = movement.normalized * speed;
    }
    public virtual void StopMove(Vector2 inputDirection) { }
    protected abstract Vector2 ReadInput();

}
