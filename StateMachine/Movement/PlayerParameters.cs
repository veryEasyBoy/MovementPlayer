using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParametrs : MonoBehaviour
{
    [SerializeField] protected CharacterStats characterStats;
    [SerializeField] protected MousStats mousStats;
   // [SerializeField] protected float speed = 1;
    [SerializeField] protected Transform playerPosition;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected Transform transformAimTarget;
    protected Fsm fsm;
    protected MouseSens mouseSens;
    public Transform PlayerPosition => playerPosition;
    public CapsuleCollider CapsuleCollider => capsuleCollider;
}
